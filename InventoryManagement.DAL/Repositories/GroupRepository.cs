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
    public class GroupRepository : RepositoryBase<Group>, IGroupRepository
    {
        public GroupRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public override Group GetById(int id)
        {
            return dbSet.AsNoTracking().Where(g => g.ID == id).FirstOrDefault();
        }
    }
    public interface IGroupRepository : IRepository<Group>
    {

    }
}
