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
    public class ColumnController : Controller
    {
        private readonly tylercalderonContext _context;
        public ColumnController(tylercalderonContext context)
        {
            _context = context;
        }

        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var products = _context.Columns.ToList();
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
                var products = _context.Columns.Where(b => b.Id == id)
                    .FirstOrDefault();
                    var current_status = products.Status;
                return Ok(current_status);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Process(Column input)
        {
            try
            {
                Column products = _context.Columns.Where(b => b.Id == input.Id)
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

        [Produces("application/json")]
        [HttpGet("email/{_email}")]
        public async Task<IActionResult> GetColumnByBattery(string _email)
        {

            // Get the customer by the email passed in (the logged in customer)
            var customer = await _context.Customers.FirstOrDefaultAsync(cust => cust.ContactEmail == _email);

            // First get list of all buildings
            var buildingsList = _context.Buildings;

            List<Battery> theirBatteries = new List<Battery>();
            List<Column> theirColumns = new List<Column>();

            // Getting the buildings that matches the customer id
            var buildingList = _context.Buildings.Where(build => build.CustomerId == customer.Id).ToList();

            foreach (var building in buildingList)
            {
                // Getting the batteries that match the building id
                var batteries = _context.Batteries.Where(batt => building.Id == batt.BuildingId).ToList();
                theirBatteries.AddRange(batteries);
            }

            foreach (var battery in theirBatteries)
            {
                // Getting the columns that match the battery id
                var columns = _context.Columns.Where(col => battery.Id == col.BatteryId).ToList();
                theirColumns.AddRange(columns);
            }

            // Return a list of the customer's columns
            return Ok(theirColumns);
        }
    }
}