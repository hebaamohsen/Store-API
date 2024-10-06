using AutoMapper;
using Store.Repository.Basket;
using Store.Repository.Basket.Models;
using Store.Service.BasketService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.BasketService
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepositry _basketRepositry;
        private readonly IMapper _mapper;

        public BasketService(IBasketRepositry basketRepositry, IMapper mapper)
        {
            _basketRepositry = basketRepositry;
            _mapper = mapper;
        }
        public async Task<bool> DeleteBasketAsync(string basketId)
       => await _basketRepositry.DeleteBasketAsync(basketId);

        public async Task<CustomerBasketDto> GetBasketAsync(string basketId)
        {
            var basket = await _basketRepositry.GetBasketAsync(basketId);

            if (basket == null)
                return new CustomerBasketDto();

            var mappedBasket = _mapper.Map<CustomerBasketDto>(basket);

            return mappedBasket;
        }

        public async Task<CustomerBasketDto> UpdateBasketAsync(CustomerBasketDto input)
        {
           if(input.Id is null)
               input.Id = GenerateRandomBasketId();

            var customerBasket = _mapper.Map<CustomerBaskt>(input);
            var updatedBasket = await _basketRepositry.UpdateBasketAsync(customerBasket);
            var mappedUpdatedBasket = _mapper.Map<CustomerBasketDto>(updatedBasket);
            return mappedUpdatedBasket;

        }

        private string GenerateRandomBasketId()
        {

            Random random = new Random();
            int randomDigits = random.Next(1000, 10000);

            return $"BS-{randomDigits}";
        }
    }
}
