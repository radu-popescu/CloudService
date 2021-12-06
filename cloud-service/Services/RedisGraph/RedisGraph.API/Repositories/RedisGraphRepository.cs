using RedisGraph.API.Entities;
using RedisGraphDotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace RedisGraph.API.Repositories
{
    /// <summary>
    /// This class implements the methods from the IRedisGraphRepository
    /// </summary>
    public class RedisGraphRepository : IRedisGraphRepository
    {
        //RedisGraphClient connectionMultiplexer = ;
        //private readonly RedisGraphClient _redisGraph = new RedisGraphClient("localhost", 6377);
        private readonly IRedisGraphClient _redisGraph = new RedisGraphClient("localhost", 6377);
        

        public RedisGraphRepository()
        {
            //_redisGraph = redisGraph ?? throw new ArgumentNullException(nameof(redisGraph));
        }

        /// <summary>
        /// Implementation of GET method
        /// </summary>
        /// <param name="key"></param>
        /// <returns>asynchronously the robotStatus object with the adjusted resultSet from the Query</returns>
        public async Task<RobotStatus> GetRobotStatus(string key)
        {
            RobotStatus robotStatus = new RobotStatus();
            //query the db for the given key and storing the result in the resultSet object
            ResultSet resultSet = await _redisGraph.Query(key, "MATCH (s:status) RETURN s.actorid, s.active, s.poweroff, s.idle, s.battery, s.currenttask");
            foreach(var res in resultSet.Results)
            {
                //maping each resultSet value into RedisGraphResult val in order to adjust each data type of the Query,
                RedisGraphResult val = res.Value.FirstOrDefault();
                if (val is null)
                {
                    continue;
                }
                //checking for value types and assigning them according to the properties of robotStatus object
                if (val is ScalarResult<string> stringVal)
                {
                    if (res.Key == "s.actorid")
                        robotStatus.ActorId = stringVal.Value;
                    if (res.Key == "s.idle")
                        robotStatus.Idle = stringVal.Value;
                    if (res.Key == "s.battery")
                        robotStatus.Battery = stringVal.Value;
                    if (res.Key == "s.currenttask")
                        robotStatus.CurrentTask = stringVal.Value;

                }
                else if (val is ScalarResult<bool> boolVal)
                {
                    if (res.Key == "s.active")
                        robotStatus.Active = boolVal.Value;
                    if (res.Key == "s.poweroff")
                        robotStatus.PowerOff = boolVal.Value;
                }
                /*else if (val is ScalarResult<int> intVal) 
                {
                    continue;
                }
                else if (val is ScalarResult<double> doubleVal)
                {
                    continue;
                }*/
            }
            return robotStatus;
        }

        public Task<RobotStatus> UpdateRobotStatus(RobotStatus robotStatus)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRobotStatus(string key)
        {
            throw new NotImplementedException();
        }
    }
}
