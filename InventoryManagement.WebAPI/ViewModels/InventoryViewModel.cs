using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryManagement.Model.DomainModels;

namespace InventoryManagement.WebAPI.ViewModels
{
    public class InventoryViewModel
    {
        public int ID { get; set; }

        public int StatusID { get; set; }

        public int EquipmentID { get; set; }

        public StatusViewModel Status { get; set; }
        public EquipmentViewModel Equipment { get; set; }

    }
}