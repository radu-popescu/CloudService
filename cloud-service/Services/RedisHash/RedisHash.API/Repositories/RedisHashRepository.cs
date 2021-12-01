using Microsoft.Extensions.Caching.Distributed;
using RedisHash.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;
using Newtonsoft.Json;
using System.Reflection;


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


        public async Task<RobotStatus> GetRobotStatus(string key)
        {

            RobotStatus robotStatus = new RobotStatus();
            var db = _redis.GetDatabase();

            HashEntry[] hashValues = await db.HashGetAllAsync(key);
            Type robotStatusType = robotStatus.GetType();

            PropertyInfo[] properties = robotStatusType.GetProperties();
            foreach (var hashValue in hashValues)
            {
                string name = hashValue.Name.ToString();
                PropertyInfo propInfo = properties.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
                
                if (propInfo == null)
                {
                    continue;
                }
                else if (propInfo.PropertyType == typeof(string))
                {
                    propInfo.SetValue(robotStatus, (string)hashValue.Value);
                }
                else if ( propInfo.PropertyType == typeof(bool)) 
                {
                    propInfo.SetValue(robotStatus, Convert.ToBoolean(hashValue.Value));
                }
            }
            return robotStatus;
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
