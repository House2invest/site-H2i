using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
//using Microsoft.Azure.EventHubs;
//using Microsoft.ServiceBus.Messaging;
using System.Text;
using System.Threading.Tasks;


namespace House2Invest
{
    public class Program
    {
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHostBuilderExtensions.UseStartup<Startup>(WebHost.CreateDefaultBuilder(args));
        }

        public static void Main(string[] args)
        {
            WebHostExtensions.Run(CreateWebHostBuilder(args).Build());
        }
    }
}

