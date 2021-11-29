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
        [ProducesResponseType(typeof(RedisValue[]), (int)HttpStatusCode.OK)]
        public async Task<string> GetRobotStatus(string key)
        {
            RedisValue[] hashValue = await _repository.GetRobotStatus(key);
            return JsonConvert.SerializeObject(hashValue);
        }
    }
}
