using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.G02.Shared.DTOs.Products;

namespace Store.G02.Services.Abstractions.Products
{
    public interface IProductService
    {
         Task<IEnumerable<ProductResponse>> GetAllProductsAsync();

         Task <ProductResponse> GetProductByIdAsync(int id);
        Task<IEnumerable<BrandTypeResponse>> GetAllBrandsAsync();

        Task<IEnumerable<BrandTypeResponse>> GetAllTypesAsync();
    }
}
