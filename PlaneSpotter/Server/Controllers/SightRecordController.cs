using Microsoft.AspNetCore.Mvc;
using PlaneSpotter.Server.Services;
using PlaneSpotter.Shared.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace PlaneSpotter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SightRecordController : ControllerBase
    {
        private ISightRecordService _service;
        public SightRecordController(ISightRecordService sightRecordService)
        {
            _service = sightRecordService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<SightRecord>>> GetSightRecords()
        {
            List<SightRecord> records = await _service.GetSightRecords();
            if (records == null)
            {
                return NotFound("Sights not found");
            }
            return Ok(records);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SightRecord>> GetSightRecord(int id)
        {
            var record = await _service.GetSightRecord(id);
            if (record == null)
            {
                return NotFound("Sight not found");
            }
            return Ok(record);

        }

        [HttpPost("add")]
        public async Task<ActionResult<SightRecord>> AddSightRecord([FromBody] SightRecord request) 
        {
            if (request != null)
            {
                var sight = await _service.AddSightRecord(request);
                if (sight != null)
                    return Ok(sight);            
            }           
            return BadRequest();
       
        }

        [HttpPut("edit")]
        public async Task<ActionResult<SightRecord>> UpdateSightRecord([FromBody]SightRecord request )
        {
            if (request != null)
            {
                var records = await _service.UpdateSightRecord(request);
                if (records != null)
                    return Ok(records);               
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Boolean>> DeleteSight([FromRoute]int id) 
        {
            var record = await _service.DeleteSightRecord(id);
            return Ok(record);
        }

        [HttpPost("upload")]
        public async Task<ActionResult<SightRecord>> UploadSightImage([FromForm] IFormFile file)
        {
            if (file != null)
            {
                var response = await _service.UploadImage(file);
                if (response != null)
                    return Ok(response);
            }
            return Ok(null);

        }


        [HttpGet("image")]
        public async Task<IActionResult> GetImage( string name)
        {
            if (name != null)
            {
                var response = await _service.GetImage(name);
                if (response != null)
                      return File(response.memory, "image/jpg", response.path); ;
            }
            return Ok(null);

        }
    }
}
