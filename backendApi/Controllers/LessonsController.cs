using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendApi.Data;
using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {

            // GET api/lessons
            [HttpGet]
            public ActionResult<IEnumerable<string>> GetLessons()
            {
                try
                {
                    using (var context = new RecordsContext())
                    {
                        var lessons = context.Lessons.ToList();
                        return Ok(lessons);
                    }
                }
                catch (Exception ex)
                {

                    return Ok(ex.Message);
                }


            }

            // POST api/lessons
            [HttpPost]
            public ActionResult PostRecord([FromBody]Lesson lesson)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                try
                {
                    using (var context = new RecordsContext())
                    {
                        context.Lessons.Add(lesson);
                        context.SaveChanges();
                        return Ok("Lesson was created.");
                    }

                }
                catch (Exception ex)
                {

                    return BadRequest(ex.Message);
                }

            }
        }
}