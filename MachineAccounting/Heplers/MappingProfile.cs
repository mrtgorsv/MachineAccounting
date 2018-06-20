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

            CreateMap<MachineOrder, MachineOrderViewModel>()
                .ForMember(s => s.MachineName, cfg => cfg.MapFrom(st => st.Machine.Name));
            CreateMap<Machine, MachineOrderViewModel>()
                .ForMember(s => s.OrderId, cfg => cfg.Ignore())
                .ForMember(s => s.MachineName, cfg => cfg.MapFrom(st => st.Name))
                .ForMember(s => s.Amount, cfg => cfg.Ignore())
                .ForMember(s => s.Rest, cfg => cfg.MapFrom(st => st.Rest))
                .ForMember(s => s.MachineId, cfg => cfg.MapFrom(st => st.Id));
            CreateMap<MachineOrderViewModel, MachineOrder>()
                .ForMember(s => s.Machine, cfg => cfg.Ignore())
                .ForMember(s => s.Order, cfg => cfg.Ignore())
                .ForMember(s => s.Count, cfg => cfg.MapFrom(mo => mo.Amount));
        }
    }
}
