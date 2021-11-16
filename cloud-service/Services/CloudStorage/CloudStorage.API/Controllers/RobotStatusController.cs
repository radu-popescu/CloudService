using CloudStorage.API.Entities;
using CloudStorage.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CloudStorage.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RobotStatusController : ControllerBase
    {
        private readonly ICloudStorageRepository _repository;

        public RobotStatusController(ICloudStorageRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        //RobotStatus
        [HttpGet("{key}", Name = "GetRobotStatus")]
        [ProducesResponseType(typeof(RobotStatus),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<RobotStatus>> GetRobotStatus(string key) 
        {
            RobotStatus robotStatus = await _repository.GetRobotStatus(key);
            return Ok(robotStatus ?? new RobotStatus(key));
        }

        [HttpPost(Name = "UpdateRobotStatus")]
        [ProducesResponseType(typeof(RobotStatus), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RobotStatus>> UpdateRobotStatus([FromBody] RobotStatus robotStatus)
        {
            return Ok(await _repository.UpdateRobotStatus(robotStatus));
        }

        [HttpDelete("{key}", Name = "DeleteRobotStatus")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteRobotStatus(string key)
        {
            await _repository.DeleteRobotStatus(key);
            return Ok();
        }

        

    }
}
