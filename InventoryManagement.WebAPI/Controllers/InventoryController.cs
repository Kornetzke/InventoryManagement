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
    public class InventoryController : BaseAPIController
    {

        private readonly IInventoryService inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            this.inventoryService = inventoryService;
        }

        // GET: api/Inventory
        public IEnumerable<InventoryViewModel> Get()
        {
            IEnumerable<InventoryViewModel> inventoryViewModels;
            IEnumerable<Inventory> inventory = inventoryService.GetAll();

            inventoryViewModels = Mapper.Map<IEnumerable<Inventory>, IEnumerable<InventoryViewModel>>(inventory);

            return inventoryViewModels;
        }

        // GET: api/Inventory/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Inventory
        public IHttpActionResult Post([FromBody]Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            inventoryService.Create(inventory);
            inventory = inventoryService.GetByID(inventory.ID);

            //statusService.Save();
            InventoryViewModel inventoryView = Mapper.Map<Inventory, InventoryViewModel>(inventory);

            return CreatedAtRoute("DefaultApi", new { id = inventory.ID }, inventoryView);
        }

        // PUT: api/Inventory/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Inventory/5
        public void Delete(int id)
        {
        }
    }
}
