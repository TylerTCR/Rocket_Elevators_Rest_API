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
    }
}
