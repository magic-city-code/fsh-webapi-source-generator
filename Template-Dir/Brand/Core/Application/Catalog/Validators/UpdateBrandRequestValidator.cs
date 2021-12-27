using MagicCityCode.FitFoodieApi.Application.Common.Validators;
using MagicCityCode.FitFoodieApi.Shared.DTOs.Catalog;
using FluentValidation;

namespace MagicCityCode.FitFoodieApi.Application.Catalog.Validators;

public class UpdateBrandRequestValidator : CustomValidator<UpdateBrandRequest>
{
    public UpdateBrandRequestValidator()
    {
        RuleFor(p => p.Name).MaximumLength(75).NotEmpty();
    }
}