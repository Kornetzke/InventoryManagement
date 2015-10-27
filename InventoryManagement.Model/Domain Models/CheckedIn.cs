using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Model.DomainModels
{
    public class CheckIn
    {

        [Key,ForeignKey("Reservation")]
        public int ReservationID { get; set; }
        public DateTime CheckInDate { get; set; }
        public string OperatorEmplid { get; set; }
        public string Comment { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}
