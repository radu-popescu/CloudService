using RedisJson.API.Entities;
using RedisJson.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RedisJson.API.Controllers
{
    /// <summary>
    /// Exposing the API to the outside world through HTTP protocol
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RobotStatusController : ControllerBase
    {
        private readonly IRedisJsonRepository _repository;

        public RobotStatusController(IRedisJsonRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        /// <summary>
        /// RobotStatus GET operation implemented for transfering the data via web.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>asynchronously a Task of type ActionResult of RobotStatus for the given key</returns>
        [HttpGet("{key}", Name = "GetRobotStatus")]
        [ProducesResponseType(typeof(RobotStatus),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<RobotStatus>> GetRobotStatus(string key) 
        {
            RobotStatus robotStatus = await _repository.GetRobotStatus(key);
            return Ok(robotStatus);
        }

        /// <summary>
        /// RobotStatus CREATE and UPDATE operations for transfering the data via web.
        /// </summary>
        /// <param name="robotStatus"></param>
        /// <param name="key"></param>
        /// <returns>asynchronously a Task of type ActionResult of RobotStatus for the given key</returns>
        [HttpPost(Name = "UpdateRobotStatus")]
        [ProducesResponseType(typeof(RobotStatus), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RobotStatus>> UpdateRobotStatus([FromBody] RobotStatus robotStatus, string key)
        {
            return Ok(await _repository.UpdateRobotStatus(robotStatus, key));
        }

        /// <summary>
        /// RobotStatus DELETE method.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>no return, delete the object for the given key</returns>
        [HttpDelete("{key}", Name = "DeleteRobotStatus")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteRobotStatus(string key)
        {
            await _repository.DeleteRobotStatus(key);
            return Ok();
        }

        

    }
}
