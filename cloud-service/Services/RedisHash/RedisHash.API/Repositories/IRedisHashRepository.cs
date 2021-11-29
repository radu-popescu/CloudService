using RedisHash.API.Entities;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisHash.API.Repositories
{
    public interface IRedisHashRepository
    {
        //RobotStatus

        Task<RedisValue[]> GetRobotStatus(string key);

        Task<RobotStatus> UpdateRobotStatus(RobotStatus robotStatus);

        Task DeleteRobotStatus(string key);
    }
}
