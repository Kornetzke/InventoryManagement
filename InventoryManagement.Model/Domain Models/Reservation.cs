using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Model.DomainModels
{
    public class Reservation
    {
        public int ID { get; set; }
        [Required]
        public string CustomerNameFirst { get; set; }

        [Required]
        public string CustomerNameLast { get; set; }

        [Required,DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; }

        [Required,DataType(DataType.PhoneNumber)]
        public string CustomerPhone { get; set; }

        [Required]
        public DateTime? CreationDate { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }

        [Required]
        public DateTime? EndDate { get; set; }

        public string StudentOrg { get; set; }
        public string ConferenceGroup { get; set; }
        public string Comment { get; set; }

        [Required]
        public int InventoryID { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual CheckIn CheckIn { get; set; }
    }
}
