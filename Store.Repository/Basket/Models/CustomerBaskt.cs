using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Basket.Models
{
    public class CustomerBaskt
    {
        public string? Id { get; set; }
        public int? DeliveryMethodId { get; set; }
        public decimal ShippingPrice { get; set; }
        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
    }
}
