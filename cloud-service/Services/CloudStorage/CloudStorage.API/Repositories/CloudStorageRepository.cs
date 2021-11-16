using CloudStorage.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudStorage.API.Repositories
{
    public class CloudStorageRepository : ICloudStorageRepository
    {
        private readonly IDistributedCache _redisCache;

        

        public CloudStorageRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }

        //RobotStatus
        public async Task<RobotStatus> GetRobotStatus(string key)
        {
            string robotStatus = await _redisCache.GetStringAsync(key);
            if (String.IsNullOrEmpty(robotStatus))
                return null;

            return JsonConvert.DeserializeObject<RobotStatus>(robotStatus);

        }

        public async Task<RobotStatus> UpdateRobotStatus(RobotStatus robotStatus)
        {
            await _redisCache.SetStringAsync(robotStatus.Key, JsonConvert.SerializeObject(robotStatus));

            return await GetRobotStatus(robotStatus.Key);
        }

        public async Task DeleteRobotStatus(string key)
        {
            await _redisCache.RemoveAsync(key);
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
