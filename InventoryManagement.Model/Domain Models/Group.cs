using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Model.DomainModels
{
    public class Group
    {
        public Group()
        {
            Equipments = new HashSet<Equipment>();
        }
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Sequence { get; set; }
        [Required]
        public int Page { get; set; }
        [Required]
        public bool IsDisplayable { get; set; }

        public virtual ICollection<Equipment> Equipments { get; set; }

    }
}
