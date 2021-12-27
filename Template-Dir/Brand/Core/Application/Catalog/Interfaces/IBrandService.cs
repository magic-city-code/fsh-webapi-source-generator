using MagicCityCode.FitFoodieApi.Application.Common.Interfaces;
using MagicCityCode.FitFoodieApi.Application.Wrapper;
using MagicCityCode.FitFoodieApi.Shared.DTOs.Catalog;

namespace MagicCityCode.FitFoodieApi.Application.Catalog.Interfaces;

public interface IBrandService : ITransientService
{
    Task<PaginatedResult<BrandDto>> SearchAsync(BrandListFilter filter);

    Task<Result<Guid>> CreateBrandAsync(CreateBrandRequest request);

    Task<Result<Guid>> UpdateBrandAsync(UpdateBrandRequest request, Guid id);

    Task<Result<Guid>> DeleteBrandAsync(Guid id);

    Task<Result<string>> GenerateRandomBrandAsync(GenerateRandomBrandRequest request);

    Task<Result<string>> DeleteRandomBrandAsync();
}