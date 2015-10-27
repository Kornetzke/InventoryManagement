using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InventoryManagement.Service;
using InventoryManagement.Model.DomainModels;
using System.Data.Entity.Infrastructure;
using InventoryManagement.WebAPI.ViewModels;
using AutoMapper;
using InventoryManagement.Service.DataValidation;
using Newtonsoft.Json;

namespace InventoryManagement.WebAPI.Controllers
{

    public class StatusController : BaseAPIController
    {

        private readonly IStatusService statusService;

        public StatusController(IStatusService StatusService)
        {
            this.statusService = StatusService;
        }

        // GET: api/Status
        public IEnumerable<Status> Get(string Description = null, bool? IsDisabling = null)
        {

            IEnumerable<Status> StatusList =
                statusService.GetWhere(s =>
                Description != null ? s.Description == Description : true &&
                IsDisabling != null ? s.IsDisabling == IsDisabling : true);

            IEnumerable<StatusViewModel> statusViewModels = Mapper.Map<IEnumerable<Status>, IEnumerable<StatusViewModel>>(StatusList);

            return StatusList;
        }

        // GET: api/Status/5
        public IHttpActionResult Get(int id)
        {
            Status status = statusService.GetByID(id);
            if (status == null)
                return NotFound();
            return Ok(status);
        }

        // POST: api/Status
        public IHttpActionResult Post(Status status)
        {
            IHttpActionResult returnResult = null;

            AddServiceValidationToModelState(statusService.Validate(status));

            if (ModelState.IsValid)
            {
                statusService.Create(status);
                returnResult = CreatedAtRoute("DefaultApi", new { id = status.ID }, status);
            }
            else
            {
                returnResult = BadRequest(ModelState);
            }
            return returnResult;
        }

        // PUT: api/Status/5
        public IHttpActionResult Put(int id, [FromBody]Status status)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != status.ID)
            {
                return BadRequest();
            }

            if (statusService.GetByID(id) == null)
            {
                return NotFound();
            }

            //statusService.Update(status);
            try
            {
                statusService.Update(status);
                //statusService.Save();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return InternalServerError();
                throw;
            }


            return Ok(status);

        }

        // DELETE: api/Status/5
        public IHttpActionResult Delete(int id)
        {
            Status status = statusService.GetByID(id);
            if (status == null)
            {
                return NotFound();
            }
            statusService.Delete(status);
            //statusService.Save();
            return Ok(status);
        }

        // Blah: api/Blah/{id}
        [Route("api/Status/Blah"), HttpGet]
        public IHttpActionResult Blah()
        {
            return Ok();
        }


    }
}
