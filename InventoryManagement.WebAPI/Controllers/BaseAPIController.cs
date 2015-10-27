using InventoryManagement.Service.DataValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace InventoryManagement.WebAPI.Controllers
{
    public abstract class BaseAPIController : ApiController
    {

        protected void AddServiceValidationToModelState(Validation serviceValidation)
        {
            if (!serviceValidation.IsValid())
            {
                foreach (KeyValuePair<string, List<string>> error in serviceValidation.Errors)
                    foreach(string errorStr in error.Value)
                        ModelState.AddModelError(error.Key, errorStr);
            }
        }
    }
}