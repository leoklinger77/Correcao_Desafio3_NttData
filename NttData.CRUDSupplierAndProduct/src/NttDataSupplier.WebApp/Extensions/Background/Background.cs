using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace NttDataSupplier.WebApp.Extensions.Background
{
    public class Background : BackgroundService
    {

        public Background() { }
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {   
                foreach (FileInfo file in new DirectoryInfo(Directory.GetCurrentDirectory() + "/wwwroot/ReportSheets_Temp").GetFiles())
                    file.Delete();

                foreach (FileInfo file in new DirectoryInfo(Directory.GetCurrentDirectory() + "/wwwroot/images/temp").GetFiles())
                    file.Delete();

                await Time();
            }            
        }

        private async Task Time()
        {
            await Task.Delay(TimeSpan.FromSeconds(7));
        }
    }
}
