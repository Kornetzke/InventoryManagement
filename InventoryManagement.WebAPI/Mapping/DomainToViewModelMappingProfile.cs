using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using InventoryManagement.Model.DomainModels;
using InventoryManagement.WebAPI.ViewModels;

namespace InventoryManagement.WebAPI.Mapping
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Property, PropertyViewModel>();
            Mapper.CreateMap<Status, StatusViewModel>();
            Mapper.CreateMap<Inventory, InventoryViewModel>();
            Mapper.CreateMap<Equipment, EquipmentViewModel>();
            Mapper.CreateMap<Group, GroupViewModel>();
            Mapper.CreateMap<Reservation, ReservationViewModel>()
                .ForMember(reservationViewModel => reservationViewModel.IsCheckedIn, map => map.MapFrom(reservation => reservation.CheckIn != null ? true : false));
            Mapper.CreateMap<CheckIn, CheckedInViewModel>();
           
        }
    }
}