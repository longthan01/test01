using System;
using System.Collections.Generic;
using System.Text;
using StackExchange.Redis;

namespace redistest
{
    class RedisManager
    {
        static RedisManager()
        {
            RedisManager.lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("localhost");
            });
        }

        private static Lazy<ConnectionMultiplexer> lazyConnection;

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}
