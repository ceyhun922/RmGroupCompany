using RmWebApi.Services.Interfaces;

namespace RmWebApi.Services;

public class GoogleReviewSyncService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public GoogleReviewSyncService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _scopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IGoogleReviewService>();
            await service.SyncFromApifyAsync();
            await Task.Delay(TimeSpan.FromDays(7), stoppingToken);
        }
    }
}