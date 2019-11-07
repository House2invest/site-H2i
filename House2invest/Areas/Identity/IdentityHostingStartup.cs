using Microsoft.AspNetCore.Hosting;
[assembly: HostingStartup(typeof(House2Invest.Areas.Identity.IdentityHostingStartup))]
namespace House2Invest.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => { });
        }
    }
}