using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryManagement.Model.DomainModels;
using InventoryManagement.WebAPI.ViewModels;

namespace InventoryManagement.WebAPI.Mapping
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return base.ProfileName;
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<StatusViewModel, Status>()
                .ForMember(s => s.Description, map => map.MapFrom(vm => vm.Description))
                .ForMember(s => s.IsDisabling, map => map.MapFrom(vm => vm.IsDisabling));
        }
    }
}