using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Infotainment.Controllers
{
    public class MainNewsApiController : ApiController
    {
        // GET api/homemainnewsapi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/homemainnewsapi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/homemainnewsapi
        public void Post([FromBody]string value)
        {
        }

        // PUT api/homemainnewsapi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/homemainnewsapi/5
        public void Delete(int id)
        {
        }
    }
}
