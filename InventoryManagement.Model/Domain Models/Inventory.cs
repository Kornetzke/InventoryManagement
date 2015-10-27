using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Model.DomainModels
{
    public class Inventory
    {
        public Inventory()
        {
            Properties = new HashSet<Property>();
        }

        public int ID { get; set; }

        [Required]
        public int StatusID { get; set; }

        [Required]
        public int EquipmentID { get; set; }

        public virtual Status Status { get; set; }
        public virtual Equipment Equipment { get; set; }

        public virtual ICollection<Property> Properties { get; set; }

    }
}
