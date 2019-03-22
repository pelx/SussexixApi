using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendApi.Data;
using BackendApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {

        // GET api/records
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetRecords()
        {
            try
            {
                using (var context = new RecordsContext())
                {
                    var records = context.Records.ToList();
                    return Ok(records);
                }
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }

            
        }

        // POST api/records
        [HttpPost]
        public ActionResult PostRecord([FromBody]Record record)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                using (var context = new RecordsContext())
                {
                    context.Records.Add(record);
                    context.SaveChanges();
                    return Ok("Record was created.");
                }
               
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}