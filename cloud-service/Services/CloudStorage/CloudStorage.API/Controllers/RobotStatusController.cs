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
    /*
     * Exposing the API to the outside world through HTTP request methods
     * Adding specific anotations for this type of class [ApiController] [Route]
     * This class inherits from the ControllerBase class.
     * @field _repository injecting the IRedisJsonRepository.
     */
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RobotStatusController : ControllerBase
    {
        //asigning fields
        private readonly IRedisJsonRepository _repository;

        //initializing fields at startup
        public RobotStatusController(IRedisJsonRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        /*
         * RobotStatus GET method implemented for transfering the data via web.
         * <param> string key
         * <param> robotStatus object
         */
        [HttpGet("{key}", Name = "GetRobotStatus")]
        [ProducesResponseType(typeof(RobotStatus),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<RobotStatus>> GetRobotStatus(string key) 
        {
            //transfering the data for the asigned key
            RobotStatus robotStatus = await _repository.GetRobotStatus(key);
            return Ok(robotStatus);
        }

        [HttpPost(Name = "UpdateRobotStatus")]
        [ProducesResponseType(typeof(RobotStatus), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RobotStatus>> UpdateRobotStatus([FromBody] RobotStatus robotStatus, string key)
        {
            return Ok(await _repository.UpdateRobotStatus(robotStatus, key));
        }

        /*
         * Implementation for DELETE method.
         * <param> string key
         * @field _repository
         */
        [HttpDelete("{key}", Name = "DeleteRobotStatus")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteRobotStatus(string key)
        {
            //transfering the data for the asigned key
            await _repository.DeleteRobotStatus(key);
            return Ok();
        }

        

    }
}
