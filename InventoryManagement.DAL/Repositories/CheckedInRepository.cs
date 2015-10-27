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
    public class CheckInRepository : RepositoryBase<CheckIn>, ICheckInRepository
    {
        public CheckInRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public override CheckIn GetById(int id)
        {
            return dbSet.AsNoTracking().Where(c => c.ReservationID == id).FirstOrDefault();
        }

    }
    public interface ICheckInRepository : IRepository<CheckIn>
    {

    }
}
