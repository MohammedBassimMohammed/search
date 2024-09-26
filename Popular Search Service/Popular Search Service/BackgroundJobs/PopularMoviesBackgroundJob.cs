
//using Microsoft.EntityFrameworkCore;
//using Popular_Search_Service.Data;

//namespace Popular_Search_Service.BackgroundJobs
//{
//    public class PopularMoviesBackgroundJob : BackgroundService
//    {
//        private readonly ApplicationDbContext _dbcontext;
//        public PopularMoviesBackgroundJob(ApplicationDbContext dbcontext)
//        {
//            _dbcontext = dbcontext;
//        }
//        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
//        {
//            try
//            {
//                while (!stoppingToken.IsCancellationRequested)
//                {
//                    var checktimetodelet = _dbcontext.Searches.Where(d => d.Search_Time < DateTime.Now.AddHours(3).AddDays(-30)).ToList();
//                    //Console.WriteLine("BackgroundService is running !!!");
//                    await Task.Delay(TimeSpan.FromSeconds(2), stoppingToken);
//                    _dbcontext.Searches.RemoveRange(checktimetodelet);
//                    _dbcontext.SaveChanges();
//                }
//            }
//            catch (OperationCanceledException)
//            {
//                Console.WriteLine("BackgroundService stop");
//            }
//        }
//    }
//}
