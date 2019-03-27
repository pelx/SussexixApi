using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("/")]
    [ApiController]
    public class RootController : ControllerBase
    {
        [HttpGet(Name = nameof(GetRoot))]
        [ProducesResponseType(200)]
        public IActionResult GetRoot()
        {
            var response = new
            {
                href = Url.Link(nameof(GetRoot), null),
                records = new
                {
                    href = Url.Link(nameof(RecordsController.GetRecords), null)
                },

                updateRecord = Url.Link(nameof(RecordsController.GetRecords), new { id = new Record().Id })

        };

            return Ok(response);
        }
    }
}