using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.DAL.Infrastructure;
using InventoryManagement.DAL.Repositories;
namespace InventoryManagement.Test.MockObjects
{
    public abstract class MockBaseRepository<T> : IRepository<T> where T : class
    {
        protected List<T> entityList;

        public MockBaseRepository(List<T> entityList)
        {
            this.entityList = entityList;
        }

        public abstract void Add(T entity);

        public abstract void Update(T entity);

        public virtual void Delete(T entity)
        {
            entityList.Remove(entity);
        }

        public virtual void Delete(Func<T, bool> where)
        {
            IEnumerable<T> TList = GetWhere(where);// as List<T>;
            if (TList != null)
            {
                for (int i = TList.Count() - 1; i >= 0; i--)
                {
                    Delete(TList.ElementAt(i));
                }
            }
        }

        public abstract T GetById(int id);

        public virtual IEnumerable<T> GetAll()
        {
            return entityList;
        }

        public virtual IEnumerable<T> GetWhere(Func<T, bool> where)
        {
            return entityList.Where(where);
        }
    }
}
