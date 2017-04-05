﻿using Microsoft.Extensions.Configuration;
using NulahStatus.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NulahStatus
{
    public class RedisStore
    {
        private static readonly Lazy<ConnectionMultiplexer> LazyConnection;
        private static readonly AppSetting _ApplicationSettings;

        private static Lazy<ConfigurationOptions> configOptions
           = new Lazy<ConfigurationOptions>(() =>
           {
               var configOptions = new ConfigurationOptions();
               configOptions.EndPoints.Add(_ApplicationSettings.Redis.EndPoint);
               configOptions.ClientName = _ApplicationSettings.Redis.ClientName;
               configOptions.ConnectTimeout = 100000;
               configOptions.SyncTimeout = 100000;
               configOptions.AbortOnConnectFail = false;
               configOptions.DefaultDatabase = 1;
               configOptions.Password = _ApplicationSettings.Redis.Password;
               configOptions.AllowAdmin = _ApplicationSettings.Redis.AdminMode;
               return configOptions;
           });

        static RedisStore()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.dev.json", optional: true, reloadOnChange: false);
            IConfigurationRoot config = builder.Build();

            _ApplicationSettings = new AppSetting();
            builder.Build().GetSection("ConnectionStrings").Bind(_ApplicationSettings);
            LazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(configOptions.Value));
        }

        public static ConnectionMultiplexer Connection => LazyConnection.Value;

        public static IDatabase RedisCache => Connection.GetDatabase();
    }
}
