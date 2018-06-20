using AutoMapper;
using MachineAccounting.DataContext.Models;
using MachineAccounting.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MachineAccounting.Web.Heplers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Machine, MachineEditViewModel>()
                .ForMember(m => m.MachineTypeList,  cfg => cfg.Ignore())
                .ForMember(m => m.StorageList,  cfg => cfg.Ignore());
            CreateMap<MachineEditViewModel, Machine>();
            CreateMap<Storage, SelectListItem>()
                .ForMember(s=> s.Value , cfg => cfg.MapFrom(st => st.Id.ToString()))
                .ForMember(s=> s.Text , cfg => cfg.MapFrom(st => st.Name));
            CreateMap<MachineType, SelectListItem>()
                .ForMember(s => s.Value, cfg => cfg.MapFrom(st => st.Id.ToString()))
                .ForMember(s => s.Text, cfg => cfg.MapFrom(st => st.Name));
        }
    }
}
