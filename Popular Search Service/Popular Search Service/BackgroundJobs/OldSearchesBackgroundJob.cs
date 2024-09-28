using Popular_Search_Service.Data;
using Popular_Search_Service.Models.Entities;

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



                    var oldSearches = dbContext.Searches.Where(d => d.Search_Time < DateTime.Now.AddMinutes(-1).ToUniversalTime()).Select(s => s.User_Selection).ToList();
                    var deletedMovieSearches = oldSearches.Select(name => new OldSearches { Old_Searches = name });
                    dbContext.OldSearches.AddRange(deletedMovieSearches);


                    var checktimetodelet = dbContext.Searches.Where(d => d.Search_Time < DateTime.Now.AddMinutes(-1).ToUniversalTime()).ToList();
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
