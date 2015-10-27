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
    public class InventoryService : ServiceBase<Inventory>, IInventoryService
    {
        public InventoryService(IInventoryRepository Repository, IUnitOfWork UnitOfWork) : base(Repository, UnitOfWork) { }

        public override Validation Validate(Inventory entity)
        {
            throw new NotImplementedException();
        }
    }

    public interface IInventoryService : IServiceBase<Inventory>
    {

    }
}
