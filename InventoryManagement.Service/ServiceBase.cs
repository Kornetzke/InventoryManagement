using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.DAL.Repositories;
using InventoryManagement.DAL.Infrastructure;
using InventoryManagement.Model.DomainModels;
using System.Linq.Expressions;
using InventoryManagement.Service.DataValidation;

namespace InventoryManagement.Service
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : class
    {
        protected readonly IRepository<T> Repository;
        protected readonly IUnitOfWork UnitOfWork;

        protected ServiceBase(IRepository<T> Repository, IUnitOfWork UnitOfWork)
        {
            this.Repository = Repository;
            this.UnitOfWork = UnitOfWork;
        }


        public virtual IEnumerable<T> GetAll()
        {
            return Repository.GetAll();
        }

        public virtual IEnumerable<T> GetWhere(Func<T, bool> where)
        {
            return Repository.GetWhere(where);
        }

        public virtual T GetByID(int ID)
        {
            return Repository.GetById(ID);
        }

        public virtual void Create(T t)
        {
            //Validation validate = Validate(t);
            //if (validate.IsValid())
            {
                Repository.Add(t);
                UnitOfWork.Commit();
            }
            //return validate;
        }

        public virtual void Update(T t)
        {
            //Validation validate = Validate(t);
            //if (validate.IsValid())
            {
                Repository.Update(t);
                UnitOfWork.Commit();
            }
            //return validate;
        }

        public virtual void Delete(T t)
        {
            Repository.Delete(t);
            UnitOfWork.Commit();
        }

        public virtual void DeleteWhere(Func<T, bool> where)
        {
            Repository.Delete(where);
            UnitOfWork.Commit();
        }

        public abstract Validation Validate(T entity);

        public virtual void Save()
        {
            UnitOfWork.Commit();
        }
    }

    public interface IServiceBase<T>
    {
        IEnumerable<T> GetAll();
        T GetByID(int ID);

        void Create(T t);

        void Update(T t);

        void Delete(T t);
        void DeleteWhere(Func<T, bool> where);

        void Save();

        Validation Validate(T entity);

        IEnumerable<T> GetWhere(Func<T, bool> where);

    }
}
