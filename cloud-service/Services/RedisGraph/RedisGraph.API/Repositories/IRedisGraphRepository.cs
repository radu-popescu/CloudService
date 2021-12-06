using RedisGraph.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisGraph.API.Repositories
{
    /// <summary>
    /// This interface will acomodate the method-signatures of the methods required for the crud operations, 
    /// -no implementation required.
    /// </summary>
    public interface IRedisGraphRepository
    {
        //RobotStatus CRUD operations
        Task<RobotStatus> GetRobotStatus(string key);

        Task<RobotStatus> UpdateRobotStatus(RobotStatus robotStatus);

        Task DeleteRobotStatus(string key);
    }
}
