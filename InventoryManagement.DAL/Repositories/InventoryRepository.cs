using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Model.DomainModels;
using InventoryManagement.DAL.Infrastructure;
using System.Data.Entity;

namespace InventoryManagement.DAL.Repositories
{
    public class InventoryRepository : RepositoryBase<Inventory>, IInventoryRepository
    {
        public InventoryRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public override Inventory GetById(int id)
        {
            return dbSet.AsNoTracking().Where(i => i.ID == id).FirstOrDefault();
        }
    }
    public interface IInventoryRepository : IRepository<Inventory>
    {

    }
}
