namespace MagicCityCode.FitFoodieApi.Shared.DTOs.Catalog;

public class BrandDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}