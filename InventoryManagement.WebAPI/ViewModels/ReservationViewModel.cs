using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.WebAPI.ViewModels
{
    public class ReservationViewModel
    {
        public int ID { get; set; }

        public string CustomerNameFirst { get; set; }


        public string CustomerNameLast { get; set; }


        public string CustomerEmail { get; set; }


        public string CustomerPhone { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string StudentOrg { get; set; }
        public string ConferenceGroup { get; set; }
        public string Comment { get; set; }


        public int EquipmentID { get; set; }
        //public EquipmentViewModel Equipment { get; set; }
        //public CheckedInViewModel CheckIn { get; set; }
        public bool IsCheckedIn { get; set; }
    }
}