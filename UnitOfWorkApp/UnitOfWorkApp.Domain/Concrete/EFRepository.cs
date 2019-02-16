using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace UnitOfWorkApp.Domain.Concrete
{
    public class EFRepository<T> where T : class
    {
        protected bool NoSave;
        protected EFDbContext Context;

        public EFRepository(EFDbContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// when working with a collection, enable/disable before sending over the wire
        /// </summary>
        public bool SkipSaveChanges
        {
            get => NoSave;
            set => NoSave = value;
        }

        /// <summary>
        /// Save changes on an update
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        /// <summary>
        /// Get all records
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return Context.Set<T>().AsQueryable<T>();
        }

        /// <summary>
        /// Get all records, use lambda predicate to filter
        /// </summary>
        /// <param name="predicate">lambda expression</param>
        /// <returns></returns>
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).AsQueryable<T>(); ;
        }

        /// <summary>
        /// Get the Entity by Identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns></returns>
        public T GetEntity(int id)
        {
            return Context.Set<T>().Find(id);
        }

        /// <summary>
        /// Get the Entity by a lambda predicate
        /// </summary>
        /// <param name="predicate">lambda expression</param>
        /// <returns></returns>
        public T GetEntity(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().FirstOrDefault(predicate);
        }

        /// <summary>
        /// Add an Entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        public T AddEntity(T entity)
        {
            Context.Set<T>().Add(entity);

            if (!NoSave)
            {
                Context.SaveChanges();
            }

            return entity;
        }

        /// <summary>
        /// Update an Entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public void UpdateEntity(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;

            if (!NoSave)
            {
                Context.SaveChanges();
            }
        }

        /// <summary>
        /// Delete an Entity by an Identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns></returns>
        public T DeleteEntity(int id)
        {
            T entity = Context.Set<T>().Find(id);

            if (entity == null)
            {
                return null;
            }

            Context.Set<T>().Remove(entity);

            if (!NoSave)
            {
                Context.SaveChanges();
            }

            return entity;
        }

        public DbSqlQuery<T> SqlQuery(string sql, params object[] parameters)
        {
            return Context.Set<T>().SqlQuery(sql, parameters);
        }
    }
}