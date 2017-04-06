using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using NulahStatus.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text.RegularExpressions;

namespace NulahStatus
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            // ConfigBuilder Stuff
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile("appsettings.dev.json", optional: true, reloadOnChange: false);
            IConfigurationRoot config = builder.Build();

            AppSetting _settings = new AppSetting();
            config.GetSection("ConnectionStrings").Bind(_settings);
            */

            var redisInfo = RedisStore.Connection.GetServer(RedisStore.RedisCache.IdentifyEndpoint()).Info();
            var infoToStatus = redisInfo.SelectMany(x => x.ToDictionary(y => y.Key, y => y.Value)).ToDictionary(x => x.Key, x => x.Value);

            // builds the PoCO based on the response
            //var statusToClassString = string.Join("\n", infoToStatus.Select(x => $"public string {x.Key.Substring(0,1).ToUpper()+ Regex.Replace(x.Key.Substring(1,x.Key.Length-1),"_[a-z]",m => m.Value.ToUpper()).Replace("_","")} {{get;set;}}"));

            RedisStatus redisStatus = new RedisStatus
            {
                UsedMemory = int.Parse(infoToStatus["used_memory"]),
                UsedMemoryRss = int.Parse(infoToStatus["used_memory_rss"]),
                UsedMemoryPeak = int.Parse(infoToStatus["used_memory_peak"]),
                UptimeInSeconds = int.Parse(infoToStatus["uptime_in_seconds"]),
                TotalConnectionsReceived = int.Parse(infoToStatus["total_connections_received"]),
                TotalCommandsProcessed = int.Parse(infoToStatus["total_commands_processed"]),
                TotalSystemMemory = int.Parse(infoToStatus["total_system_memory"]),
                ExpiredKeys = int.Parse(infoToStatus["expired_keys"]),
                KeyspaceHits = int.Parse(infoToStatus["keyspace_hits"]),
                KeyspaceMisses = int.Parse(infoToStatus["keyspace_misses"]),
                UsedCpuSys = float.Parse(infoToStatus["used_cpu_sys"]),
                UsedCpuUser = float.Parse(infoToStatus["used_cpu_user"]),
                UsedCpuSysChildren = float.Parse(infoToStatus["used_cpu_sys_children"]),
                UsedCpuUserChildren = float.Parse(infoToStatus["used_cpu_user_children"]),
                Updated = DateTime.UtcNow
            };

            RedisStore.RedisCache.ListLeftPush("Nulah-Redis-Status", JsonConvert.SerializeObject(redisStatus));
            RedisStore.RedisCache.ListTrim("Nulah-Redis-Status", 0, 2016); // probably the number of 5 minute blocks in a week (7*24*60)/5
        }
    }
}