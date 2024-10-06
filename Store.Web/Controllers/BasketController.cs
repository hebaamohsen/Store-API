using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Service.BasketService;
using Store.Service.BasketService.Dtos;

namespace Store.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : BaseController
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerBasketDto>> GetBasketAsync(string id)
            => Ok(await _basketService.GetBasketAsync(id));

        [HttpPost]
        public async Task<ActionResult<CustomerBasketDto>> UpdateBasketAsync(CustomerBasketDto input)
            => Ok(await _basketService.UpdateBasketAsync(input));

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteBasketAsync(string id)
            => Ok(await _basketService.DeleteBasketAsync(id));
    }
}
