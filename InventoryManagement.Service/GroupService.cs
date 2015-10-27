using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Model.DomainModels;
using InventoryManagement.DAL.Infrastructure;
using InventoryManagement.DAL.Repositories;
using InventoryManagement.Service.DataValidation;

namespace InventoryManagement.Service
{
    public class GroupService : ServiceBase<Group>, IGroupService
    {
        public GroupService(IGroupRepository Repository, IUnitOfWork UnitofWork) : base(Repository, UnitofWork) { }

        public override Validation Validate(Group entity)
        {
            throw new NotImplementedException();
        }
    }

    public interface IGroupService : IServiceBase<Group> { }
}
