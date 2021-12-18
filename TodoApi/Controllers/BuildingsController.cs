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
    public class BuildingsController : Controller
    {
        private readonly tylercalderonContext _context;
        public BuildingsController(tylercalderonContext context)
        {
            _context = context;
        }

        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {


            var c = "";
            var buildings = _context.Buildings.Include(b => b.Batteries).ThenInclude(c => c.Columns).ThenInclude(e => e.Elevators).ToList();
           
            List<Building> buildinglist = new List<Building>();
            foreach(var b in buildings)
            {
                var battery = b.Batteries.ToList();
                var count_buildinglist = buildinglist.Count;
                foreach(var t in battery)
                {
                    if (t.Status == "Intervention")
                    {
                        buildinglist.Add(b);
                        break;
                    }
                    else
                    {
                        var column = t.Columns.ToList();
                        foreach (var v in column)
                        {
                            if (v.Status == "Intervention")
                            {
                                buildinglist.Add(b);
                                break;
                            }
                            else
                            {
                                var elevator = v.Elevators.ToList();
                                foreach (var e in elevator)
                                {
                                    if (e.Status == "Intervention")
                                    {
                                        buildinglist.Add(b);
                                        break;
                                    }
                                }
                            }
                        }


                    }
                  
                }
               

            }
            
            return Ok(buildinglist);
          
        }

        [Produces("application/json")]
        [HttpGet("{_email}")]
        public async Task<IActionResult> GetBuildingByCust(string _email)
        {
            // Get the customer by the email passed in (the logged in customer)
            var customer = _context.Customers.Where(b => b.ContactEmail == _email).FirstOrDefault();

            // First get list of all buildings
            var buildingsList = _context.Buildings;

            List<Building> theirBuildings = new List<Building>();
            // Go through each building in the buildingsList
            foreach (var building in buildingsList)
            {
                // If the current building's customer id matches _custId...
                if (building.CustomerId == customer.Id)
                {
                    theirBuildings.Add(building); // Add it to the theirBuildings list
                }
            }
            // Return a list of the customer's buildings
            return Ok(theirBuildings);
        }
    }
}
