﻿using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace TelegramBot.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .UseUrls("http://localhost:5001/")
                .Build();

            host.Run();
        }
    }
}
