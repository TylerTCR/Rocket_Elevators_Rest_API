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
    public class CustomersController : Controller
    {
        // GET /<controller>/
        private readonly tylercalderonContext _context;
        public CustomersController(tylercalderonContext context)
        {
            _context = context;
        }

        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var customers = _context.Customers.ToList();
                return Ok(customers);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("{_email}")]
        public async Task<IActionResult> GetEmail([FromRoute]string _email)
        {
            //Console.WriteLine(_email);
            try
            {
                var customer = _context.Customers.Where(b => b.ContactEmail == _email).FirstOrDefault();
                return Ok(customer.ContactEmail);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}