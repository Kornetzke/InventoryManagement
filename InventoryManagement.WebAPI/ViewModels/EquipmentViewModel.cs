using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.WebAPI.ViewModels
{
    public class EquipmentViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }

    }
}