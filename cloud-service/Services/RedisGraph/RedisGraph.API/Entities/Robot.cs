using RedisGraph.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisGraph.API.Entities
{
    public class Robot : IReachable
    {
        public string Id { get; set; }

        public Robot()
        {
            this.Id = "robot_1";
        }

        public List<IReachable> CanReachList { get; set; }
        public List<IOwnable> Owns { get; set; }

    }
}
