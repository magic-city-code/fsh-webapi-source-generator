using MagicCityCode.FitFoodieApi.Shared.DTOs.Filters;

namespace MagicCityCode.FitFoodieApi.Shared.DTOs.Catalog;

public class ProductListFilter : PaginationFilter
{
    public Guid? BrandId { get; set; }
    public decimal? MinimumRate { get; set; }
    public decimal? MaximumRate { get; set; }
}