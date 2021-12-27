using MagicCityCode.FitFoodieApi.Application.Common.Interfaces;
using MagicCityCode.FitFoodieApi.Domain.Catalog;
using MagicCityCode.FitFoodieApi.Infrastructure.Persistence.Contexts;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace MagicCityCode.FitFoodieApi.Infrastructure.Seeders;

public class ProductSeeder : IDatabaseSeeder
{
    private readonly ISerializerService _serializerService;
    private readonly ApplicationDbContext _db;
    private readonly ILogger<ProductSeeder> _logger;

    public ProductSeeder(ISerializerService serializerService, ILogger<ProductSeeder> logger, ApplicationDbContext db)
    {
        _serializerService = serializerService;
        _logger = logger;
        _db = db;
    }

    public void Initialize()
    {
        Task.Run(async () =>
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (!_db.Products.Any())
            {
                _logger.LogInformation("Started to Seed Products.");

                // Here you can use your own logic to populate the database.
                // As an example, I am using a JSON file to populate the database.
                string brandData = await File.ReadAllTextAsync(path + "/seeders/product.json");
                var items = _serializerService.Deserialize<List<Product>>(brandData);

                if (items != null)
                {
                    foreach (var item in items)
                    {
                        await _db.Products.AddAsync(item);
                    }
                }

                await _db.SaveChangesAsync();
                _logger.LogInformation("Seeded Products.");
            }
        }).GetAwaiter().GetResult();
    }
}