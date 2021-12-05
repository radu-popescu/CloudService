using RedisJson.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisJson.API.Repositories
{
    /*
     * This interface will acomodate the signatures of the functions required for the crud operations, 
     * -no implementation required.
     * <param> string key
     * <param> robotStatus object instance
     */
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
