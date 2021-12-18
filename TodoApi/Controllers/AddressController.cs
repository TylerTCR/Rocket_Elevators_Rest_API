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
    public class AddressController : Controller
    {
        private readonly tylercalderonContext _context;
        public AddressController(tylercalderonContext context)
        {
            _context = context;
        }

        [Produces("application/json")]
        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserInfo(string email)
        {
            try
            {
                var info = _context.Customers.Where(cust => cust.ContactEmail == email).FirstOrDefault();

                var address = _context.Addresses.Where(addr => addr.Id == info.AddressId).FirstOrDefault();

                Address selectedInfo = new Address();
                selectedInfo.City = address.City;
                selectedInfo.Country = address.Country;
                selectedInfo.PostalCode = address.PostalCode;
                selectedInfo.NumberAndStreet = address.NumberAndStreet;

                return Ok(selectedInfo);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("{email}")]
        public async Task<IActionResult> Process(string email, Address input)
        {
            try
            {
                var info = _context.Customers.Where(cust => cust.ContactEmail == email).FirstOrDefault();

                var address = _context.Addresses.Where(addr => addr.Id == info.AddressId).FirstOrDefault();

                address.City = input.City;
                address.Country = input.Country;
                address.PostalCode = input.PostalCode;
                address.NumberAndStreet = input.NumberAndStreet;
                address.SuiteAndApartment = input.SuiteAndApartment;
                _context.SaveChanges();

                return Ok("The address has successfully been updated");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}