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
    /// <summary>
    /// Exposing the API to the outside world through HTTP protocol
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RobotStatusController : ControllerBase
    {
        private readonly IRedisGraphRepository _repository;

        public RobotStatusController(IRedisGraphRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// RobotStatus GET operation implemented for transfering the data via web.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>asynchronously a Task of type RobotStatus for the given key</returns>
        [HttpGet("{key}", Name = "GetRobotStatus")]
        [ProducesResponseType(typeof(RobotStatus), (int)HttpStatusCode.OK)]
        public async Task<RobotStatus> GetRobotStatus(string key)
        {
            RobotStatus robotStatus = await _repository.GetRobotStatus(key);
            return robotStatus;
        }
    }
}
