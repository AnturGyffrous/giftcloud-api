using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IDL.Giftcloud.Api.Administration.Controllers
{
    [Route("[controller]")]
    public class GiftsController : Controller
    {
        private readonly string _connectionString;

        public GiftsController(IConfiguration configuration)
        {
            _connectionString = configuration["SqlConnectionString"];
        }

        // GET: <controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2", _connectionString };
        }

        // GET <controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST <controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT <controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE <controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
