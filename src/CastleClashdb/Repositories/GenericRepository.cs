using CastleClashdb.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastleClashdb.Repositories
{
    public class GenericRepository: IGenericRepository
    {
        private ApplicationDbContext db;

        public GenericRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Generic query method
        /// </summary>
        public IQueryable<T> Query<T>() where T : class
        {
            return db.Set<T>().AsQueryable();
        }
        /// <summary>
        /// Add new entity
        /// </summary>
        public T Add<T>(T item) where T : class
        {
            db.Set<T>().Add(item);
            SaveChanges();
            return item;
        }
        /// <summary>
        /// Update an existing entity
        /// </summary>
        public void Update<T>(T entityToUpdate) where T : class
        {
            db.Set<T>().Update(entityToUpdate);
            this.SaveChanges();
        }
        /// <summary>
        /// Delete an existing entity
        /// </summary>
        public void Delete<T>(T entityToDelete) where T : class
        {
            db.Set<T>().Remove(entityToDelete);
            this.SaveChanges();
        }
        /// <summary>
        /// Execute stored procedures and dynamic sql
        /// </summary>
        public IQueryable<T> SqlQuery<T>(string sql, params object[] parameters) where T : class
        {
            return db.Set<T>().FromSql(sql, parameters);
        }
        /// <summary>
        /// Save changes to the database
        /// </summary>
        public void SaveChanges()
        {
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
