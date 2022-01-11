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
    public class EmployeeController : Controller
    {
        private readonly tylercalderonContext _context;
        public EmployeeController(tylercalderonContext context)
        {
            _context = context;
        }
        
        [Produces("application/json")]
        [HttpGet("{email}")]
        public async Task<IActionResult> VerifyEmployee(string _email)
        {
            try
            {
                var employee = _context.Employees.Where(b => b.Email == _email).FirstOrDefault();
                if (employee.Email == _email) {
                    return Ok(employee.Email);
                } else {
                    return Ok("NotFound");
                }
                
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}