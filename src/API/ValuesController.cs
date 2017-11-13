using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace taller.Controllers
{
    [Route("api/[controller]")]
    //uthorize]
    public class ValuesController : Controller
    {
    ILogger<ValuesController> factory;
    public ValuesController(ILogger<ValuesController> loggerFactory )
    {
      this.factory = loggerFactory;
    }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
      //var logger= this.factory.LogCritical.CreateLogger<ValuesController>();
      factory.LogDebug("Call Method GET");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
