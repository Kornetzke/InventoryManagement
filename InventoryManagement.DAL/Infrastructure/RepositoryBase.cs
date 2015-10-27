using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.DAL.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        #region Properties
        private InventoryManagementContext dataContext;
        protected readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected InventoryManagementContext DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }
        #endregion

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        #region Implementation
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T updateEntity)
        {
            dbSet.Attach(updateEntity);
            dataContext.Entry(updateEntity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Attach(entity);
            dbSet.Remove(entity);
        }

        public virtual void Delete(Func<T, bool> where)
        {
            IEnumerable<T> TList = GetWhere(where);
            if (TList != null)
            {
                for (int i = TList.Count() - 1; i >= 0; i--)
                {
                    Delete(TList.ElementAt(i));
                }
            }
        }

        
        public virtual T GetById(int id)
        {
            //return dbSet.Find(id);
            throw new NotImplementedException();
        }
         

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public virtual IEnumerable<T> GetWhere(Func<T, bool> where)
        {
            return dbSet.AsNoTracking().Where(where).ToList();
        }

        #endregion

    }

    public interface IRepository<T> where T : class
    {
        // Marks an entity as new
        void Add(T entity);
        // Marks an entity as modified
        void Update(T entity);
        // Marks an entity to be removed
        void Delete(T entity);
        void Delete(Func<T, bool> where);
        // Get an entity by int id
        T GetById(int id);
        // Gets all entities of type T
        IEnumerable<T> GetAll();
        // Gets entities using delegate
        IEnumerable<T> GetWhere(Func<T, bool> where);

    }
}
