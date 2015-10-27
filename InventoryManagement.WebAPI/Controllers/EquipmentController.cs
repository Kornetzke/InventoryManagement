using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InventoryManagement.Service;
using InventoryManagement.Model.DomainModels;
using InventoryManagement.WebAPI.ViewModels;
using AutoMapper;

namespace InventoryManagement.WebAPI.Controllers
{
    public class EquipmentController : BaseAPIController
    {

        private readonly IEquipmentService EquipmentService;

        public EquipmentController(IEquipmentService EquipmentService)
        {
            this.EquipmentService = EquipmentService;
        }

        // GET: api/Equipment
        public IEnumerable<EquipmentViewModel> Get()
        {
            IEnumerable<Equipment> equipmentList = EquipmentService.GetAll();
            IEnumerable<EquipmentViewModel> equipmentViewModelList = Mapper.Map<IEnumerable<Equipment>, IEnumerable<EquipmentViewModel>>(equipmentList);

            return equipmentViewModelList;
        }

        // GET: api/Equipment/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Equipment
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Equipment/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Equipment/5
        public void Delete(int id)
        {
        }
    }
}
