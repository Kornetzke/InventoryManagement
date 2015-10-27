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
    public class ReservationRepository : RepositoryBase<Reservation>, IReservationRepository
    {
        public ReservationRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public override Reservation GetById(int id)
        {
            return dbSet.AsNoTracking().Where(r => r.ID == id).FirstOrDefault();
        }
    }
    public interface IReservationRepository : IRepository<Reservation>
    {

    }
}
