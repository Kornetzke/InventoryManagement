using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Model.DomainModels;
using InventoryManagement.DAL.Repositories;
using InventoryManagement.DAL.Infrastructure;
using InventoryManagement.Service.DataValidation;

namespace InventoryManagement.Service
{
    public class EquipmentService : ServiceBase<Equipment>, IEquipmentService
    {
        public EquipmentService(IEquipmentRepository EquipmentRepository, IUnitOfWork UnitOfWork) : base(EquipmentRepository,UnitOfWork){
            
        }

        public override Validation Validate(Equipment entity)
        {
            throw new NotImplementedException();
        }

    }

    public interface IEquipmentService : IServiceBase<Equipment>
    {

    }
}
