using RedisJson.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;
using NReJSON;

namespace RedisJson.API.Repositories
{
    /// <summary>
    /// This class implements the methods from the IRedisJsonRepository
    /// </summary>
    public class RedisJsonRepository : IRedisJsonRepository
    {
        
        private readonly IDistributedCache _redisCache;
        private readonly IConnectionMultiplexer _redis;

       
        public RedisJsonRepository(IDistributedCache redisCache, IConnectionMultiplexer redis)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
            _redis = redis ?? throw new ArgumentNullException(nameof(redis));
        }



        /// <summary>
        /// Implementation of GET method
        /// </summary>
        /// <param name="key"></param>
        /// <returns>asynchronously a Task of type RobotStatus for the given key</returns>
        public async Task<RobotStatus> GetRobotStatus(string key)
        {
            IDatabase db = _redis.GetDatabase();
             
            string robotStatus = (string)await db.JsonGetAsync(key);
            if (String.IsNullOrEmpty(robotStatus))
                return null;
            
            return JsonConvert.DeserializeObject<RobotStatus>(robotStatus);

        }

        /// <summary>
        /// This method will cover CREATE and UPDATE operations
        /// </summary>
        /// <param name="robotStatus"></param>
        /// <param name="key"></param>
        /// <returns>asynchronously a Task of type RobotStatus for the given key</returns>
        public async Task<RobotStatus> UpdateRobotStatus(RobotStatus robotStatus, string key)
        {
            IDatabase db =  _redis.GetDatabase();

            await db.JsonSetAsync(key, JsonConvert.SerializeObject(robotStatus));

            return await GetRobotStatus(key);
        }

        /// <summary>
        /// Implementation of DELETE method
        /// </summary>
        /// <param name="key"></param>
        /// <returns>deletes the record for the given key</returns>
        public async Task DeleteRobotStatus(string key)
        {
            IDatabase db = _redis.GetDatabase();

            await db.JsonDeleteAsync(key);
        }

        //CloudStatus
        public async Task<CloudStatus> GetCloudStatus(string key)
        {
            string cloudStatus = await _redisCache.GetStringAsync(key);
            if (String.IsNullOrEmpty(cloudStatus))
                return null;

            return JsonConvert.DeserializeObject<CloudStatus>(cloudStatus);

        }

        public async Task<CloudStatus> UpdateCloudStatus(CloudStatus cloudStatus)
        {
            await _redisCache.SetStringAsync(cloudStatus.Key, JsonConvert.SerializeObject(cloudStatus));

            return await GetCloudStatus(cloudStatus.Key);
        }

        public async Task DeleteCloudStatus(string key)
        {
            await _redisCache.RemoveAsync(key);
        }
    }
}
