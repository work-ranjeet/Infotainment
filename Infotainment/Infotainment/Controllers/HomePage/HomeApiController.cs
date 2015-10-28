using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Infotainment.Controllers.HomePage
{
    public class HomeApiController : ApiController
    {
        [HttpGet]
        [ActionName("ToptenNewsList")]
        public IEnumerable<string>GetToptenNewsList()
        {
            return new string[] { "1","2","3","4","5","6"};
        }

        // GET api/homeapi

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/homeapi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/homeapi
        public void Post([FromBody]string value)
        {
        }

        // PUT api/homeapi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/homeapi/5
        public void Delete(int id)
        {
        }
    }
}
