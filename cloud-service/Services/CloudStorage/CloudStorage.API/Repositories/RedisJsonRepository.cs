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
    /*
     * In this class we implement the methods from the Interface.
     * @field _redisCache (connection with cache memory)
     * @field _redis (connection with redisJson)
     */
    public class RedisJsonRepository : IRedisJsonRepository
    {
        //asigning fields
        private readonly IDistributedCache _redisCache;

        private readonly IConnectionMultiplexer _redis;

        //initializing fields at startup
        public RedisJsonRepository(IDistributedCache redisCache, IConnectionMultiplexer redis)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
            _redis = redis ?? throw new ArgumentNullException(nameof(redis));
        }



        /*
         * Implementation of GET method
         * <param> string key
         * <param> robotStatus object
         * <param> db connection with db
         */
        public async Task<RobotStatus> GetRobotStatus(string key)
        {
            //geting the data from the cache memory
            IDatabase db = _redis.GetDatabase();
            
            //geting the data record for the specified key 
            string robotStatus = (string)await db.JsonGetAsync(key);
            //checking if there is any data for the asigned key
            if (String.IsNullOrEmpty(robotStatus))
                return null;
            
            //returning and converting the result from the memory, for the given key
            return JsonConvert.DeserializeObject<RobotStatus>(robotStatus);

        }


        public async Task<RobotStatus> UpdateRobotStatus(RobotStatus robotStatus, string key)
        {
            IDatabase db =  _redis.GetDatabase();

            await db.JsonSetAsync(key, JsonConvert.SerializeObject(robotStatus));

            return await GetRobotStatus(key);
        }

        /*
         * Implementation for DELETE method.
         * <param> string key
         * <param> db connection with db
         */
        public async Task DeleteRobotStatus(string key)
        {
            //geting the data from the cache memory
            IDatabase db = _redis.GetDatabase();

            //deleting the robotstatus object for the given key
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
