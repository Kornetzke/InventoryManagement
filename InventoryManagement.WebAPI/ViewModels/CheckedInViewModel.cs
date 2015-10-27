using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.WebAPI.ViewModels
{
    public class CheckedInViewModel
    {
        public int ReservationID { get; set; }
        public DateTime CheckInDate { get; set; }
        public string OperatorEmplid { get; set; }
        public string Comment { get; set; }

        //public virtual ReservationViewModel Reservation { get; set; }
    }
}