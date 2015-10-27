using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.WebAPI.ViewModels
{
    public class StatusViewModel
    {
        public int ID { get; set; }
        public String Description { get; set; }
        public bool IsDisabling { get; set; }

    }
}