using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using InventoryManagement.Service;
using InventoryManagement.Model.DomainModels;
using InventoryManagement.WebAPI.ViewModels;
using InventoryManagement.Service.DataValidation;

namespace InventoryManagement.WebAPI.Controllers
{
    public class ReservationsController : BaseAPIController
    {

        private readonly IReservationService reservationService;
        private readonly ICheckInService CheckInService;

        public ReservationsController(IReservationService ReservationService)
        {
            this.reservationService = ReservationService;
        }
        // GET: api/Reservation
        public IEnumerable<ReservationViewModel> Get()
        {
            IEnumerable<Reservation> reservationList = reservationService.GetAll();
            IEnumerable<ReservationViewModel> reservationViewModelList = Mapper.Map<IEnumerable<Reservation>, IEnumerable<ReservationViewModel>>(reservationList);

            return reservationViewModelList;
        }

        // GET: api/Reservation/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Reservation
        public IHttpActionResult Post([FromBody]Reservation reservation)
        {
            IHttpActionResult returnResult = null;


            AddServiceValidationToModelState(reservationService.Validate(reservation));

            if (ModelState.IsValid)
            {
                reservationService.Create(reservation);
                returnResult = CreatedAtRoute("DefaultApi", new { id = reservation.ID }, reservation);
            }
            else
            {
                returnResult = BadRequest(ModelState);
            }
            return returnResult;
        }

        // PUT: api/Reservation/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Reservation/5
        public void Delete(int id)
        {
        }

        // Get: api/Reservation/id/CheckIn
        [Route("api/Reservation/{id:int}/CheckIn"), HttpGet]
        public CheckedInViewModel CheckIn(int id)
        {
            return Mapper.Map<CheckIn, CheckedInViewModel>(CheckInService.GetByID(id));
        }

        // Post: api/Reservation/id/CheckIn
        [Route("api/Reservation/{id:int}/CheckIn"), HttpPost]
        public IHttpActionResult CheckIn(int id, CheckIn checkIn)
        {
            return Ok(Mapper.Map<CheckIn, CheckedInViewModel>(CheckInService.GetByID(id)));
        }
    }
}
