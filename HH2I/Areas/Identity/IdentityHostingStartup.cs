namespace House2Invest.Areas.Identity
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Runtime.CompilerServices;

    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices(delegate (WebHostBuilderContext context, IServiceCollection services) {
            });
        }

        
    }
}

