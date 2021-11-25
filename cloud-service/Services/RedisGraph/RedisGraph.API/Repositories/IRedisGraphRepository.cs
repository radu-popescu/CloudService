using RedisGraph.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisGraph.API.Repositories
{
    public interface IRedisGraphRepository
    {
        //RobotStatus
        Task<RobotStatus> GetRobotStatus(string key);

        Task<RobotStatus> UpdateRobotStatus(RobotStatus robotStatus);

        Task DeleteRobotStatus(string key);
    }
}
