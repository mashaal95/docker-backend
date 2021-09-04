using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Backend_KubesProject_DotNet
{
    public class AppConfig
    {
        public string DatabaseConnectionString { get; set; } = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=development";
        public static AppConfig Build()
        {
            var config = new AppConfig();

            DotNetEnv.Env.Load();

            new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .Build()
            .Bind("AppConfig", config);

            return config;
        }
    }
}
