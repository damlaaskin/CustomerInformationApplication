using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Information.QueryHandler.Caching
{
    public class CacheManager : ICacheManager
    {


        public ConnectionMultiplexer ConnectDatabase()
        {
            return ConnectionMultiplexer.Connect("localhost");
        }

        public IDatabase GetDatabase()
        {
            var redis = ConnectDatabase();
            return redis.GetDatabase();
        }
    }
}
