using Microsoft.AspNetCore.Mvc;
using RedisGraph.API.Entities;
using RedisGraph.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RedisGraph.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RobotStatusController : ControllerBase
    {
        private readonly IRedisGraphRepository _repository;

        public RobotStatusController(IRedisGraphRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        //RobotStatus
        [HttpGet("{key}", Name = "GetRobotStatus")]
        [ProducesResponseType(typeof(RobotStatus), (int)HttpStatusCode.OK)]
        public async Task<RobotStatus> GetRobotStatus(string key)
        {
            RobotStatus robotStatus = await _repository.GetRobotStatus(key);
            return robotStatus;
        }
    }
}
