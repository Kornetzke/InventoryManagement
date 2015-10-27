using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Model.DomainModels;
using InventoryManagement.DAL.Infrastructure;
using InventoryManagement.DAL.Repositories;
using System.Diagnostics;
using InventoryManagement.Service.DataValidation;

namespace InventoryManagement.Service
{
    public class StatusService : ServiceBase<Status>, IStatusService
    {
        public StatusService(IStatusRepository Repository, IUnitOfWork UnitofWork) : base(Repository, UnitofWork) { }

        /*
        public IEnumerable<Status> GetWhere(string Description = null, bool? IsDisabling = null){

            IEnumerable<Status> StatusList;


            StatusList = this.Repository.GetWhere(s => 
                Description != null ? s.Description == Description : true &&
                IsDisabling != null ? s.IsDisabling == IsDisabling : true);

            return StatusList;
        }         
        */

        public override Validation Validate(Status entity)
        {
            Validation validate = new Validation();

            if (entity == null)
            {
                validate.AddError("status", "Status can not be null");
            }
            else
            {
                if (entity.Description == null || entity.Description.Length < 1)
                    validate.AddError("status.Description", "Description length required to be greater than 1");

                if (entity.IsDisabling == null || entity.IsDisabling.Equals(false))
                    validate.AddError("status.IsDisabling", "IsDisabling required to be true");

            }

            return validate;
        }

    }

    public interface IStatusService : IServiceBase<Status>
    {
    }
}
