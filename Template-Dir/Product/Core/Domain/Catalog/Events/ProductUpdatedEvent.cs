using MagicCityCode.FitFoodieApi.Domain.Common.Contracts;

namespace MagicCityCode.FitFoodieApi.Domain.Catalog.Events;

public class ProductUpdatedEvent : DomainEvent
{
    public ProductUpdatedEvent(Product product)
    {
        Product = product;
    }

    public Product Product { get; }
}