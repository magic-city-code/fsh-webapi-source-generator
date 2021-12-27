using MagicCityCode.FitFoodieApi.Domain.Common.Contracts;

namespace MagicCityCode.FitFoodieApi.Domain.Catalog.Events;

public class ProductCreatedEvent : DomainEvent
{
    public ProductCreatedEvent(Product product)
    {
        Product = product;
    }

    public Product Product { get; }
}