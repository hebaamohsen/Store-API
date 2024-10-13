using AutoMapper;
using Store.Data.Entities.OrderEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.OrderService.Dtos
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<ShippingAddress,AddressDto>().ReverseMap();
            CreateMap<Order,OrderDetailsDto>()
                .ForMember(dest => dest.DeliveryMethodName, options => options.MapFrom(src => src.DeliveryMethod.ShortName))
                .ForMember(dest => dest.ShippingPrice, options => options.MapFrom(src => src.DeliveryMethod.Price));

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.productItemId, options => options.MapFrom(src => src.productItem.ProductId))
                .ForMember(dest => dest.ProductName, options => options.MapFrom(src => src.productItem.ProductName))
                 .ForMember(dest => dest.ProductUrl, options => options.MapFrom<OrderItemPictureUrlResolver>()).ReverseMap();


        }
    }
}
