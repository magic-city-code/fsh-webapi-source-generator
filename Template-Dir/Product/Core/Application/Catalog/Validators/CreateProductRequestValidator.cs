using MagicCityCode.FitFoodieApi.Application.Common.Validators;
using MagicCityCode.FitFoodieApi.Application.Storage;
using MagicCityCode.FitFoodieApi.Shared.DTOs.Catalog;
using FluentValidation;

namespace MagicCityCode.FitFoodieApi.Application.Catalog.Validators;

public class CreateProductRequestValidator : CustomValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(p => p.Name).MaximumLength(75).NotEmpty();
        RuleFor(p => p.Rate).GreaterThanOrEqualTo(1).NotEqual(0);
        RuleFor(p => p.Image).SetValidator(new FileUploadRequestValidator());
        RuleFor(p => p.BrandId).NotEmpty().NotNull();
    }
}