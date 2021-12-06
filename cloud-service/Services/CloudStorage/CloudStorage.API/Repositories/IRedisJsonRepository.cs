using RedisJson.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisJson.API.Repositories
{
    /// <summary>
    /// This interface will acomodate the method-signatures of the methods required for the crud operations, 
    /// -no implementation required.
    /// </summary>
    public interface IRedisJsonRepository
    {
        //RobotStatus CRUD operations.
        Task<RobotStatus> GetRobotStatus(string key);

        Task<RobotStatus> UpdateRobotStatus(RobotStatus robotStatus, string key);

        Task DeleteRobotStatus(string key);

        //CloudStatus CRUD operations
        Task<CloudStatus> GetCloudStatus(string key);

        Task<CloudStatus> UpdateCloudStatus(CloudStatus cloudStatus);

        Task DeleteCloudStatus(string key);
    }
}
