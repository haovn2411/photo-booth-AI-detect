﻿using StackExchange.Redis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teachable_Machine_Model_Handler_with_Redis.Services
{
    public class RedisListener
    {
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _database;

        public RedisListener(string redisConnectionString)
        {
            _redis = ConnectionMultiplexer.Connect(redisConnectionString);
            _database = _redis.GetDatabase();
        }

        public byte[] ListenForData(string Key)
        {
            byte[] imageInRedis = _database.StringGet(Key);
            return imageInRedis;
        }
    }
}
