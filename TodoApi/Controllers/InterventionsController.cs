using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
namespace TodoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InterventionsController : Controller
    {
        // GET: /<controller>/
        private readonly tylercalderonContext _context;
        public InterventionsController(tylercalderonContext context)
        {
            _context = context;
        }
        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> GetPending()
        {
            try
            {
                var pending_intervention = _context.Interventions.Where(b => b.Status == "Pending");
                return Ok(pending_intervention);
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpPut]
        public async Task<IActionResult> PostStatus(Intervention input)
        {
            try
            {
                if (input.Status == "InProgress")
                {
                    var change_status = _context.Interventions.Where(b => b.Id == input.Id).FirstOrDefault();
                    var current_status = change_status.Status;
                    change_status.Status = input.Status;
                    change_status.InterventionStart = DateTime.Now;
                    _context.SaveChanges();
                    return Ok("Status has been successfully changed");
                }
                else if (input.Status == "Completed")
                {
                    var change_status = _context.Interventions.Where(b => b.Id == input.Id).FirstOrDefault();
                    var current_status = change_status.Status;
                    change_status.Status = input.Status;
                    change_status.InterventionEnd = DateTime.Now;
                    _context.SaveChanges();
                    return Ok("Status has been successfully changed");
                }
                else
                {
                    return Ok("Something went wrong");
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}