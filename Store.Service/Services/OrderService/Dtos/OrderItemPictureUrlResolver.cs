using AutoMapper;
using Microsoft.Extensions.Configuration;
using Store.Data.Entities.OrderEntities;


namespace Store.Service.Services.OrderService.Dtos
{
    public class OrderItemPictureUrlResolver : IValueResolver<OrderItem, OrderItemDto, string>
    {
        private readonly IConfiguration _configuration;

        public OrderItemPictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.productItem.PictureUrl))
                return $"{_configuration["BaseUrl"]}/{source.productItem.PictureUrl}";
            return null;
        }
    }
}
