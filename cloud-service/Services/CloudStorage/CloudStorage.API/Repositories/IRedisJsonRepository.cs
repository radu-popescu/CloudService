using RedisJson.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisJson.API.Repositories
{
    public interface IRedisJsonRepository
    {
        //RobotStatus
        Task<RobotStatus> GetRobotStatus(string key);

        Task<RobotStatus> UpdateRobotStatus(RobotStatus robotStatus);

        Task DeleteRobotStatus(string key);

        //CloudStatus
        Task<CloudStatus> GetCloudStatus(string key);

        Task<CloudStatus> UpdateCloudStatus(CloudStatus cloudStatus);

        Task DeleteCloudStatus(string key);
    }
}
