using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RedisHash.API.Entities;
using RedisHash.API.Repositories;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RedisHash.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RobotStatusController : ControllerBase
    {
        private readonly IRedisHashRepository _repository;

        public RobotStatusController(IRedisHashRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        //RobotStatus
        [HttpGet("{key}", Name = "GetRobotStatus")]
        [ProducesResponseType(typeof(RobotStatus), (int)HttpStatusCode.OK)]
        public async Task<RobotStatus> GetRobotStatus(string key)
        {
            RobotStatus robotStatus = await _repository.GetRobotStatus(key);
            return robotStatus; //?? new RobotStatus(key); 
        }
    }
}
