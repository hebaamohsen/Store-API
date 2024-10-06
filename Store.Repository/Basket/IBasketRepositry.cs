using Store.Repository.Basket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Basket
{
    public interface IBasketRepositry
    {
        Task<CustomerBaskt> GetBasketAsync(string basketId);
        Task<CustomerBaskt> UpdateBasketAsync(CustomerBaskt basket);
        Task<bool> DeleteBasketAsync(string basketId);

    }
}
