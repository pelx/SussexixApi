using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BackendApi.Data;
using BackendApi.Models;
using BackendApi.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    
    
   // [Route("/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        readonly IRecordsService _service;
        public RecordsController(IRecordsService service)
        {
            _service = service;
        }

        // GET /record
        [HttpGet("{id}")]
        public IActionResult GetRecord(int id)
        {
            try
            {
                using (var context = new RecordsContext())
                {
                    var record = context.Records.FirstOrDefault(n => n.Id == id);
                    if (record == null) return NotFound();
                    return Ok(record);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET /records
        [HttpGet]
        public IActionResult GetRecords()
        {
            try
            {
               var records = _service.GetAll();
               return Ok(records);
            }
            catch 
            {
                return new StatusCodeResult((int)HttpStatusCode.ServiceUnavailable);
            }
            
        }

        // POST /records
        [HttpPost]
        public IActionResult SaveRecord([FromBody]Record record)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (_service.Save(record) == null)
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);

            return Ok(record);
        }

        // PUT /records
        [HttpPut("{id}")]
        public IActionResult UpdateRecord(int id, [FromBody]Record record)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id != record.Id) return BadRequest();

            if (_service.Update(id, record) == null)
                return new StatusCodeResult((int)HttpStatusCode.NotFound);

            return Ok(record);
        }

        // delete /records
        [HttpDelete("{id}")]
        public IActionResult DeleteRecord(int id)
        {
            try
            {
                using (var context = new RecordsContext())
                {
                    var record = context.Records.FirstOrDefault(n => n.Id == id);
                    if (record == null) return NotFound();

                    context.Remove(record);
                    context.SaveChanges();

                    return Ok(record);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}