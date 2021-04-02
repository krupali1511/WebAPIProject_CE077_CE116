using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrowTogether.Models;
using GrowTogether.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrowTogether.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private IClassService _classService;
        public ClassController(IClassService iclassservice)
        {
            _classService = iclassservice;
        }
        [HttpGet("joinclass")]
        public IActionResult Get([FromBody]User user, Classes classes){

            var iclassservice = _classService.JoinClass(user, classes);
            if (iclassservice=="Success") {
                return Ok(new { message = "Success" });
            }
            else
            {
               return BadRequest(new { message = "Failed" });
            }
        }

        [HttpGet("leaveclass")]
        public IActionResult LeaveClass([FromBody] User user, Classes classes)
        {

            var iclassservice = _classService.LeaveClass(user, classes);
            if (iclassservice == "Success")
            {
                return Ok(new { message = "Success" });
            }
            else
            {
                return BadRequest(new { message = "Failed" });
            }
        }


    }
}
