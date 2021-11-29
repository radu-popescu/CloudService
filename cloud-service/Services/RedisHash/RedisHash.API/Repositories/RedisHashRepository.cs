using Microsoft.Extensions.Caching.Distributed;
using RedisHash.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace RedisHash.API.Repositories
{
    public class RedisHashRepository : IRedisHashRepository
    {
        private readonly IDistributedCache _redisCache;

        private readonly IConnectionMultiplexer _redis;

        public RedisHashRepository(IDistributedCache redisCache, IConnectionMultiplexer redis)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
            _redis = redis ?? throw new ArgumentNullException(nameof(redis));
        }


        public async Task<RedisValue[]> GetRobotStatus(string key)
        {
            //RobotStatus robotStatus = new RobotStatus();
            //robotStatus.Key = key;

            var db = _redis.GetDatabase();
            RedisValue[] hashValue = await db.HashValuesAsync(key);

            //hashValue = robotStatus.GetType().GetProperties();
            
            return hashValue;
           
        }

        public Task<RobotStatus> UpdateRobotStatus(RobotStatus robotStatus)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRobotStatus(string key)
        {
            throw new NotImplementedException();
        }
    }
}
