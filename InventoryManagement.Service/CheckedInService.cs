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
    public class CheckInService : ServiceBase<CheckIn>, ICheckInService
    {
        public CheckInService(ICheckInRepository Repository, IUnitOfWork UnitofWork) : base(Repository, UnitofWork) { }
        public override Validation Validate(CheckIn entity)
        {
            throw new NotImplementedException();
        }
    }
    public interface ICheckInService : IServiceBase<CheckIn>
    {

    }
}
