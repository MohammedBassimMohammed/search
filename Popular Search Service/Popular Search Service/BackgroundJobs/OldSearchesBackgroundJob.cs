using Popular_Search_Service.Data;

namespace Popular_Search_Service.BackgroundJobs;


public class OldSearchesBackgroundJob : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    public OldSearchesBackgroundJob(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    var checktimetodelet = dbContext.Searches.Where(d => d.Search_Time < DateTime.Now.AddMinutes(-1).ToUniversalTime()).ToList();
                    //Console.WriteLine("BackgroundService is running !!!");
                    await Task.Delay(TimeSpan.FromSeconds(2), stoppingToken);
                    dbContext.Searches.RemoveRange(checktimetodelet);
                    await dbContext.SaveChangesAsync();
                }
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("BackgroundService stop");
        }
    }
}
