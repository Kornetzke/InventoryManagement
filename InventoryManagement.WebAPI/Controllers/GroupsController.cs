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
    public class GroupsController : BaseAPIController
    {

        private readonly IGroupService GroupService;

        public GroupsController(IGroupService GroupService){
            this.GroupService = GroupService;
        }

        // GET: api/Group
        public IEnumerable<GroupViewModel> Get()
        {
            IEnumerable<Group> groupList = GroupService.GetAll();
            IEnumerable<GroupViewModel> groupViewModelList = Mapper.Map<IEnumerable<Group>, IEnumerable<GroupViewModel>>(groupList);
            return groupViewModelList;
        }

        // GET: api/Group/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Group
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Group/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Group/5
        public void Delete(int id)
        {
        }
    }
}
