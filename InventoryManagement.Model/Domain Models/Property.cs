using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Model.DomainModels
{
    public class Property
    {

        public Property()
        {
            Inventories = new HashSet<Inventory>();
        }
        public int ID { get; set; }
        [Required]
        public string PropertyText { get; set; }
        [Required]
        public string Value { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
