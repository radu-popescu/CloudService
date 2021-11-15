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

        public async Task<RobotStatus> GetRobotStatus(string key)
        {
            string status = await _redisCache.GetStringAsync(key);
            if (String.IsNullOrEmpty(status))
                return null;

            return JsonConvert.DeserializeObject<RobotStatus>(status);

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

    }
}
