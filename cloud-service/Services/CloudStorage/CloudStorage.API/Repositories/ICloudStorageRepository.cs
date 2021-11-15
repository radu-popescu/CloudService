using CloudStorage.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudStorage.API.Repositories
{
    public interface ICloudStorageRepository
    {
        Task<RobotStatus> GetRobotStatus(string key);

        Task<RobotStatus> UpdateRobotStatus(RobotStatus robotStatus);

        Task DeleteRobotStatus(string key);
    }
}
