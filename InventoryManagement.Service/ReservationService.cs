using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.DAL.Repositories;
using InventoryManagement.DAL.Infrastructure;
using InventoryManagement.Model.DomainModels;
using InventoryManagement.Service.DataValidation;


namespace InventoryManagement.Service
{
    public class ReservationService : ServiceBase<Reservation>, IReservationService
    {
        private IEquipmentRepository EquipmentRepository;
        private IInventoryRepository InventoryRepository;

        public ReservationService(IReservationRepository Repository, IEquipmentRepository EquipmentRepository, IInventoryRepository InventoryRepository, IUnitOfWork UnitofWork)
            : base(Repository, UnitofWork) {
                this.EquipmentRepository = EquipmentRepository;
                this.InventoryRepository = InventoryRepository;
        }

        public IEnumerable<Reservation> GetConflictingReservations(Reservation res)
        {
            List<Reservation> ConflictingList = new List<Reservation>();

            //gets a list of Inventory that are part of the Equipment Group whose Status is not disabling
            //Gets Inventory whose available for checkout
            
            

            return ConflictingList;
        }

        public override Validation Validate(Reservation res)
        {
            Validation validate = new Validation();


            if (res == null)
                validate.AddError("reservation", "reservation can not be null");
            else
            {
                if (res.InventoryID == 0)
                    validate.AddError("reservation.EquipmentID", "EquipmentID can not be null");
                else
                    if(InventoryRepository.GetById(res.InventoryID) == null)
                        validate.AddError("reservation.EquipmentID","Equipment with ID:"+res.InventoryID + " not found");

                if (String.IsNullOrEmpty(res.CustomerNameFirst))
                    validate.AddError("reservation.CustomerNameFirst", "CustomerNameFirst can not be null");

                if (String.IsNullOrEmpty(res.CustomerNameLast))
                    validate.AddError("reservation.CustomerNameLast", "CustomerNameLast can not be null");

                if (String.IsNullOrEmpty(res.CustomerEmail))
                    validate.AddError("reservation.CustomerEmail", "CustomerEmail can not be null");

                if (String.IsNullOrEmpty(res.CustomerPhone))
                    validate.AddError("reservation.CustomerPhone", "CustomerPhone can not be null");
                
                if (res.CreationDate == null)
                    validate.AddError("reservation.CreationDate", "CreationDate can not be null");

                if (res.StartDate == null)
                    validate.AddError("reservation.StartDate", "StartDate can not be null");

                if (res.EndDate == null)
                    validate.AddError("reservation.EndDate", "EndDate can not be null");
                    
                if(res.StartDate != null && res.EndDate != null && res.StartDate > res.EndDate)
                {
                    validate.AddError("reservation.StartDate", "StartDate must be before EndDate");
                    validate.AddError("reservation.EndDate", "EndDate must be after StartDate");
                }

                if (DataValidationHelper.IsValidEmailAddress(res.CustomerEmail) == false)
                    validate.AddError("reservation.CustomerEmail", "Invalid Email");
                if (DataValidationHelper.IsValidPhoneNumber(res.CustomerPhone) == false)
                    validate.AddError("reservation.CustomerPhone", "Invalid Phone Number");
            }
            return validate;
        }

    }

    public interface IReservationService : IServiceBase<Reservation>
    {
        IEnumerable<Reservation> GetConflictingReservations(Reservation res);
    }
}
