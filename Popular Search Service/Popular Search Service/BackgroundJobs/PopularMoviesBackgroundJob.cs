
namespace Popular_Search_Service.BackgroundJobs
{
    public class PopularMoviesBackgroundJob : BackgroundService
    {
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    Console.WriteLine("BackgroundService is running !!!");
                    await Task.Delay(TimeSpan.FromSeconds(2), stoppingToken);
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("BackgroundService stop");
            }
        }
    }
}
