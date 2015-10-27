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
using System.Net.Http.Headers;

namespace InventoryManagement.WebAPI.Controllers
{
    public class CheckedInsController : BaseAPIController
    {
        private readonly ICheckInService CheckedInService;

        public CheckedInsController(ICheckInService CheckedInService)
        {
            this.CheckedInService = CheckedInService;
        }
        // GET: api/CheckedIn
        public IEnumerable<CheckedInViewModel> Get()
        {
            IEnumerable<CheckIn> checkedInList = CheckedInService.GetAll();
            IEnumerable<CheckedInViewModel> checkedInViewModelList = Mapper.Map<IEnumerable<CheckIn>, IEnumerable<CheckedInViewModel>>(checkedInList);

            return checkedInViewModelList;
        }

        // GET: api/CheckedIn/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CheckedIn
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CheckedIn/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CheckedIn/5
        public void Delete(int id)
        {
        }
    }
}
