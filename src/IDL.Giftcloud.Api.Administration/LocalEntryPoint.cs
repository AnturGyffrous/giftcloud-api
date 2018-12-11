﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace IDL.Giftcloud.Api.Administration
{
    public static class LocalEntryPoint
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
