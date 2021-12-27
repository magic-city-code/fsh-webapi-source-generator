using MagicCityCode.FitFoodieApi.Application.Common.Interfaces;
using MagicCityCode.FitFoodieApi.Application.Wrapper;
using MagicCityCode.FitFoodieApi.Shared.DTOs.Catalog;

namespace MagicCityCode.FitFoodieApi.Application.Catalog.Interfaces;

public interface IProductService : ITransientService
{
    Task<Result<ProductDetailsDto>> GetProductDetailsAsync(Guid id);

    Task<Result<ProductDto>> GetByIdUsingDapperAsync(Guid id);

    Task<PaginatedResult<ProductDto>> SearchAsync(ProductListFilter filter);

    Task<Result<Guid>> CreateProductAsync(CreateProductRequest request);

    Task<Result<Guid>> UpdateProductAsync(UpdateProductRequest request, Guid id);

    Task<Result<Guid>> DeleteProductAsync(Guid id);
}