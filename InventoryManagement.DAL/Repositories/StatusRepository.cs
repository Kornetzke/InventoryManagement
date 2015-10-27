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
    public class StatusRepository : RepositoryBase<Status>, IStatusRepository
    {
        public StatusRepository(IDbFactory dbFactory) : base(dbFactory) { }

        
        public override Status GetById(int id)
        {
            return this.dbSet.Where(s => s.ID == id).FirstOrDefault();
            //return this.dbSet.AsNoTracking().Where(s => s.ID == id).FirstOrDefault();
        }
        /*
        public override void Update(int id, Status updateEntity)
        {
            Status status = GetById(id);
            status.Description = updateEntity.Description;
            status.IsDisabling = updateEntity.IsDisabling;
            DbContext.Entry(status).State = EntityState.Modified;
        }
        */
    }
    public interface IStatusRepository : IRepository<Status>
    {

    }
}
