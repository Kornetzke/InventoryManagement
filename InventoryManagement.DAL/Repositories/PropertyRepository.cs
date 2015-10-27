using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.DAL.Infrastructure;
using InventoryManagement.Model.DomainModels;
using System.Data.Entity;

namespace InventoryManagement.DAL.Repositories
{
    public class PropertyRepository : RepositoryBase<Property>, IPropertyRepository
    {
        public PropertyRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public override Property GetById(int id)
        {
            return dbSet.AsNoTracking().Where(p => p.ID == id).FirstOrDefault();
        }
    }
    public interface IPropertyRepository : IRepository<Property>
    {

    }
}
