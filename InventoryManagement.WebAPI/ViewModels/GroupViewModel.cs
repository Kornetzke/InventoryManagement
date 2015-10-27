using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.WebAPI.ViewModels
{
    public class GroupViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Sequence { get; set; }
        public int Page { get; set; }
        public string Description { get; set; }
        public bool IsDisplayed { get; set; }

        public ICollection<EquipmentViewModel> Equipments { get; set; }
    }
}