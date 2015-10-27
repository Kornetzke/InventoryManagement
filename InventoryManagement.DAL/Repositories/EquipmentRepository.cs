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
    public class EquipmentRepository : RepositoryBase<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public override Equipment GetById(int id)
        {
            return dbSet.AsNoTracking().Where(e => e.ID == id).FirstOrDefault();
        }
    }
    public interface IEquipmentRepository : IRepository<Equipment>
    {
        
    }
}
