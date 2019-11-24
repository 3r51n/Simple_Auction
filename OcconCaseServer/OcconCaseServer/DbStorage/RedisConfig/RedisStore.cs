using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Occon.Server.Api.DataStorage.RedisConfig
{
    public class RedisStore
    {
        private static readonly Lazy<ConnectionMultiplexer> LazyConnect;

        static RedisStore()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(System.IO.Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

            ConfigurationOptions ConfOpt = new ConfigurationOptions
            {
                EndPoints = { { "localhost", 6379 } }
            };
            LazyConnect = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(ConfOpt));

        }

        public static ConnectionMultiplexer Connection => LazyConnect.Value;

        public static IDatabase RedisDb => Connection.GetDatabase();
    }
}
