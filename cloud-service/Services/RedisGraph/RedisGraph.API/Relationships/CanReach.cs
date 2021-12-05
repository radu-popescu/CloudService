using RedisGraph.API.Entities;
using RedisGraphDotNet.Client;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisGraph.API.Relationships
{
    public class CanReach
    {
        private readonly IRedisGraphClient _redisGraph = new RedisGraphClient("localhost", 6377);

        
        public CanReach()
        {
            Robot rob = new Robot();
            Edge edg = new Edge();

            _redisGraph.Query("testgraph", "CREATE ("+rob.Id+")-[:CAN_REACH]->("+edg.Id+")");

        }

    }
}
