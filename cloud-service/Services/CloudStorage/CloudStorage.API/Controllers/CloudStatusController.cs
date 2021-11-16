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
    public class CloudStatusController : ControllerBase
    {
        private readonly ICloudStorageRepository _repository;

        public CloudStatusController(ICloudStorageRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }



        //CloudStatus
        [HttpGet("{key}", Name = "GetCloudStatus")]
        [ProducesResponseType(typeof(CloudStatus), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CloudStatus>> GetCloudStatus(string key)
        {
            CloudStatus cloudStatus = await _repository.GetCloudStatus(key);
            return Ok(cloudStatus ?? new CloudStatus(key));
        }

        [HttpPost(Name = "UpdateCloudStatus")]
        [ProducesResponseType(typeof(CloudStatus), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CloudStatus>> UpdateCloudStatus([FromBody] CloudStatus cloudStatus)
        {
            return Ok(await _repository.UpdateCloudStatus(cloudStatus));
        }

        [HttpDelete("{key}", Name = "DeleteCloudStatus")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCloudStatus(string key)
        {
            await _repository.DeleteCloudStatus(key);
            return Ok();
        }

    }
}
