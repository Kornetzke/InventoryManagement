using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Model.DomainModels
{
    public class Status
    {
        public int ID { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool? IsDisabling { get; set; }

        public override bool Equals(object obj)
        {
            bool isEqual = true;

            if (isEqual && obj == null)
                isEqual = false;

            Status status = obj as Status;

            if (isEqual && status == null)
                isEqual = false;

            if (isEqual && (this.ID != status.ID || !this.Description.Equals(status.Description) || this.IsDisabling != status.IsDisabling))
                isEqual = false;


            return isEqual;
        }

    }
}
