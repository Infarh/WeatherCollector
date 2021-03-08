using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeatherCollector.DAL.Context;
using WeatherCollector.DAL.Entities.Base;
using WeatherCollector.Interfaces.Base;
using WeatherCollector.Interfaces.Base.Entities;

namespace WeatherCollector.DAL
{
    public class DbRepository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly WeatherDB _db;

        protected DbSet<T> Set { get; }

        public virtual IEnumerable<T> Items => Set;

        public bool AutoSaveChanges { get; set; } = true;

        public DbRepository(WeatherDB db)
        {
            _db = db;
            Set = _db.Set<T>();
        }

        public T Get(int id)
        {
            var items = Items;
            return items is DbSet<T> set 
                ? set.Find(id) 
                : items.FirstOrDefault(item => item.Id == id);
        }

        public async Task<T> GetAsync(int id, CancellationToken Cancel = default)
        {
            var items = Items;
            return items is DbSet<T> set
                ? await set.FindAsync(new object[] {id}, Cancel).ConfigureAwait(false)
                : items is IQueryable<T> query
                    ? await query.FirstOrDefaultAsync(item => item.Id == id, Cancel).ConfigureAwait(false)
                    : items.FirstOrDefault(item => item.Id == id);
        }

        private T ChangeItemState(T item, EntityState State)
        {
            _db.Entry(item ?? throw new ArgumentNullException(nameof(item))).State = State;
            if (AutoSaveChanges)
                SaveChanges();
            return item;
        }

        private async Task<T> ChangeItemStateAsync(T item, EntityState State, CancellationToken Cancel)
        {
            _db.Entry(item ?? throw new ArgumentNullException(nameof(item))).State = State;
            if (AutoSaveChanges)
                await SaveChangesAsync(Cancel).ConfigureAwait(false);
            return item;
        }

        public T Add(T item) => ChangeItemState(item, EntityState.Added);

        public Task<T> AddAsync(T item, CancellationToken Cancel = default) => ChangeItemStateAsync(item, EntityState.Added, Cancel);

        public T Update(T item) => ChangeItemState(item, EntityState.Modified);

        public Task<T> UpdateAsync(T item, CancellationToken Cancel = default) => ChangeItemStateAsync(item, EntityState.Modified, Cancel);

        public T Delete(T item) => ChangeItemState(item, EntityState.Deleted);

        public Task<T> DeleteAsync(T item, CancellationToken Cancel = default) => ChangeItemStateAsync(item, EntityState.Deleted, Cancel);

        public T Delete(int id)
        {
            var db_item = Set.Local.FirstOrDefault(item => item.Id == id) 
                ?? Set.Select(item => new T { Id = item.Id}).FirstOrDefault(item => item.Id == id);
            return db_item is null 
                ? null 
                : ChangeItemState(db_item, EntityState.Deleted);
        }

        public async Task<T> DeleteAsync(int id, CancellationToken Cancel = default)
        {
            var db_item = Set.Local.FirstOrDefault(item => item.Id == id)
                ?? await Set.Select(item => new T { Id = item.Id }).FirstOrDefaultAsync(item => item.Id == id, Cancel).ConfigureAwait(false);
            return db_item is null
                ? null
                : await ChangeItemStateAsync(db_item, EntityState.Deleted, Cancel).ConfigureAwait(false);
        }

        public void SaveChanges() => _db.SaveChanges();

        public Task SaveChangesAsync(CancellationToken Cancel = default) => _db.SaveChangesAsync(Cancel);
    }

    public class DbRepositoryNamed<T> : DbRepository<T>, IRepositoryNamed<T> where T : Entity, INamedEntity, new()
    {
        public DbRepositoryNamed(WeatherDB db) : base(db) { }

        public T Get(string Name)
        {
            var items = Items;
            return items is IQueryable<T> query
                ? query.FirstOrDefault(item => item.Name == Name)
                : items.FirstOrDefault(item => item.Name == Name);
        }

        public async Task<T> GetAsync(string Name, CancellationToken Cancel = default)
        {
            var items = Items;
            return items is IQueryable<T> query
                ? await query.FirstOrDefaultAsync(item => item.Name == Name, Cancel).ConfigureAwait(false)
                : items.FirstOrDefault(item => item.Name == Name);
        }
    }
}
