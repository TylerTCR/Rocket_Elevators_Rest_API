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
    public class LeadsController : Controller
    {
        private readonly tylercalderonContext _context;
        public LeadsController(tylercalderonContext context)
        {
            _context = context;
        }

        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var products = _context.Leads.ToList();
                return Ok(products);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("recent")]
        public async Task<IActionResult> GetList()
        {

            var leads = _context.Leads.ToList();
            var customers = _context.Customers.ToList();
            List<Lead> recent_leads = new List<Lead>();

            DateTime currentDate = DateTime.Now.AddDays(-30);
            Boolean found;
            foreach (var l in leads)
            {
                found = false;
                foreach(var custy in customers)
                {
                    if(l.Email != custy.ContactEmail)
                    {
                       
                    }
                    else
                    {
                        found = true;
                        break;
                    }
                }
                if(found == false)
                {
                    if(l.CreatedAt >= currentDate)
                    {
                        recent_leads.Add(l);
                    }
                }
            }

            return Ok(recent_leads);
        }
    }
}