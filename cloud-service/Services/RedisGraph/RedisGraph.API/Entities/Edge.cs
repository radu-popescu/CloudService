using RedisGraph.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisGraph.API.Entities
{
    public class Edge 
    {
        public string Id { get; set; }
 
        public Edge()
        {
            this.Id = "edge_1";
        }
    }
}
