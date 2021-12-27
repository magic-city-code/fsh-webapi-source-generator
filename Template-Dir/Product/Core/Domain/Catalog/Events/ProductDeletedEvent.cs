using MagicCityCode.FitFoodieApi.Domain.Common.Contracts;

namespace MagicCityCode.FitFoodieApi.Domain.Catalog.Events;

public class ProductDeletedEvent : DomainEvent
{
    public ProductDeletedEvent(Product product)
    {
        Product = product;
    }

    public Product Product { get; }
}