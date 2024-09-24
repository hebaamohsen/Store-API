using AutoMapper;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Service.Services.TheProducts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.TheProducts
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.Repository<ProductBrand,int>().GetAllAsNoTrackingAsync();
            var mappedBrands = _mapper.Map<IReadOnlyList<BrandTypeDetailsDto>>(brands);



            return mappedBrands;
        }

        public async Task<IReadOnlyList<ProductDetailsDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.Repository<Product, int>().GetAllAsNoTrackingAsync();

            var mappedProduct = _mapper.Map<IReadOnlyList<ProductDetailsDto>>(products);

            return mappedProduct;
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.Repository<ProductType, int>().GetAllAsNoTrackingAsync();
            var mappedtypes = _mapper.Map<IReadOnlyList<BrandTypeDetailsDto>>(types);



            return mappedtypes;
        }

        public async Task<ProductDetailsDto> GetProductByIdAsync(int? productId)
        {
            if (productId == null)
                throw new Exception("Id Is Null");
            var product = await _unitOfWork.Repository<Product, int>().GetByIdAsync(productId.Value);

            if (product == null)
                throw new Exception("Product Not Found");

            var mappedProduct = _mapper.Map<ProductDetailsDto>(product);
            return mappedProduct;
        }
    }
}
