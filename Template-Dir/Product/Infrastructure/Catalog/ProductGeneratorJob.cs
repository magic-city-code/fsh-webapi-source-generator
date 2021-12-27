using MagicCityCode.FitFoodieApi.Application.Abstractions.Services.Identity;
using MagicCityCode.FitFoodieApi.Application.Catalog.Interfaces;
using MagicCityCode.FitFoodieApi.Application.Common.Interfaces;
using MagicCityCode.FitFoodieApi.Domain.Catalog;
using MagicCityCode.FitFoodieApi.Domain.Dashboard;
using MagicCityCode.FitFoodieApi.Shared.DTOs.Notifications;
using Hangfire;
using Hangfire.Console.Extensions;
using Hangfire.Console.Progress;
using Hangfire.Server;
using Microsoft.Extensions.Logging;

namespace MagicCityCode.FitFoodieApi.Infrastructure.Catalog;

public class ProductGeneratorJob : IProductGeneratorJob
{
    private readonly IEventService _eventService;
    private readonly ILogger<ProductGeneratorJob> _logger;
    private readonly IRepositoryAsync _repository;
    private readonly IProgressBarFactory _progressBar;
    private readonly PerformingContext _performingContext;
    private readonly INotificationService _notificationService;
    private readonly ICurrentUser _currentUser;
    private readonly IProgressBar _progress;

    public ProductGeneratorJob(
        ILogger<ProductGeneratorJob> logger,
        IRepositoryAsync repository,
        IProgressBarFactory progressBar,
        PerformingContext performingContext,
        INotificationService notificationService,
        ICurrentUser currentUser,
        IEventService eventService)
    {
        _logger = logger;
        _repository = repository;
        _progressBar = progressBar;
        _performingContext = performingContext;
        _notificationService = notificationService;
        _currentUser = currentUser;
        _progress = _progressBar.Create();
        _eventService = eventService;
    }

    private async Task Notify(string message, int progress = 0)
    {
        _progress.SetValue(progress);
        await _notificationService.SendMessageToUserAsync(
            _currentUser.GetUserId().ToString(),
            new JobNotification()
            {
                JobId = _performingContext.BackgroundJob.Id,
                Message = message,
                Progress = progress
            });
    }

    [Queue("notdefault")]
    public async Task GenerateAsync(int nSeed)
    {
        await Notify("Your job processing has started");
        foreach (int index in Enumerable.Range(1, nSeed))
        {
            await _repository.CreateAsync(new Product(name: $"Product Random - {Guid.NewGuid()}", "Funny description"));
            await Notify("Progress: ", nSeed > 0 ? (index * 100 / nSeed) : 0);
        }

        await _repository.SaveChangesAsync();
        await _eventService.PublishAsync(new StatsChangedEvent());
        await Notify("Job successfully completed");
    }

    [Queue("notdefault")]
    [AutomaticRetry(Attempts = 5)]
    public async Task CleanAsync()
    {
        _logger.LogInformation("Initializing Job with Id: {JobId}", _performingContext.BackgroundJob.Id);
        var items = await _repository.GetListAsync<Product>(x => x.Name.Contains("Product Random"), true);
        _logger.LogInformation("Products Random: {ProductsCount} ", items.Count.ToString());

        foreach (var item in items)
        {
            await _repository.RemoveAsync(item);
        }

        int rows = await _repository.SaveChangesAsync();
        await _eventService.PublishAsync(new StatsChangedEvent());
        _logger.LogInformation("Rows affected: {rows} ", rows.ToString());
    }
}