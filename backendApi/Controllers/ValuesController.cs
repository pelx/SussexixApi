using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendApi.Data;
using BackendApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace backendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            try
            {
                using (var db = new RecordsContext())
                {
                    var dt = new DateTime().Date;


                    // Seed
                    //db.Records.AddRange(new Record
                    //{
                    //    Id = 1,
                    //    Day = 1,
                    //    StrId = "1",
                    //    Date = dt,
                    //    Teacher = "Paul",
                    //    Type = "ATM",
                    //    Topic = "Nothing",
                    //    Duration = 45,
                    //    Notes = "many many"
                    //});

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
