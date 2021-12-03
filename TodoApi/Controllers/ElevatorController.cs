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
    public class ElevatorController : Controller
    {
        private readonly tylercalderonContext _context;
        public ElevatorController(tylercalderonContext context)
        {
            _context = context;
        }

        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var products = _context.Elevators.ToList();
                return Ok(products);
            }
            catch
            {
                return BadRequest();
            }
        }
        
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpect(int id)
        {
            try
            {
                var products = _context.Elevators.Where(b => b.Id == id)
                    .FirstOrDefault();
                    var current_status = products.Status;
                return Ok(current_status);
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("inactive")]
        public async Task<IActionResult> GetSpect1()
        {
            try
            {
                List<Elevator> nonOperational = new List<Elevator>();
                var elevator = _context.Elevators.ToList();

                foreach (var e in elevator)
                {
                    if(e.Status != "Active")
                    {
                        nonOperational.Add(e);
                    }
                    

                }
                return Ok(nonOperational);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Process(Elevator input)
        {
            try
            {
                Elevator products = _context.Elevators.Where(b => b.Id == input.Id)
                    .FirstOrDefault();
                var current_status = products.Status;
                products.Status = input.Status;
                _context.SaveChanges();
                return Ok("Status has been successfully changed");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}