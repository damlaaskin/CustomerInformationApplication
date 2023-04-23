﻿using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Information.QueryHandler.Caching
{
    public interface ICacheManager
    {
        ConnectionMultiplexer ConnectDatabase();
        IDatabase GetDatabase();
    }
}
