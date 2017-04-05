﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NulahStatus.Models
{
    public class AppSetting
    {
        public RedisConnection Redis { get; set; }
    }

    public class RedisConnection
    {
        public string EndPoint { get; set; }
        public string ClientName { get; set; }
        public bool AdminMode { get; set; }
        public string Password { get; set; }
    }
}
