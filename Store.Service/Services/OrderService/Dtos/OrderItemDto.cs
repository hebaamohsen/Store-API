using Store.Data.Entities.OrderEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.OrderService.Dtos
{
    public class OrderItemDto
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int productItemId { get; set; }
        public string ProductName { get; set; }
        public string ProductUrl { get; set; }

        public Guid OrderId { get; set; }
    }
}
