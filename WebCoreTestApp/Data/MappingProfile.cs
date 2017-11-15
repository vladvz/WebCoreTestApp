using AutoMapper;
using WebCoreTestApp.Data.Entities;
using WebCoreTestApp.ViewModels;

namespace WebCoreTestApp.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id))
                .ReverseMap();

            CreateMap<OrderItem, OrderItemViewModel>()
                .ReverseMap();
        }
    }
}
