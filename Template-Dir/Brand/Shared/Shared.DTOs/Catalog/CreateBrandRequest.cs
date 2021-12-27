namespace MagicCityCode.FitFoodieApi.Shared.DTOs.Catalog;

public class CreateBrandRequest : IMustBeValid
{
    public string Name { get; set; }
    public string Description { get; set; }
}