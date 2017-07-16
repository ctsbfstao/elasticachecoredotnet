using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebCache.Helper;
using WebCache.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebCache.API
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private ICacheFactory _cacheFactory;

        public ValuesController(ICacheFactory cacheFactory)
        {
            _cacheFactory = cacheFactory;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var response = _cacheFactory.RetrieveOrUpdateRedis<IEnumerable<ProductItem>>();

            return new string[] { response.DataLoadType, response.ElapsedMilliseconds.ToString(), response.CachedJsonContent };
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

        // DELETE api/values
        [HttpDelete]
        public void Delete()
        {
            _cacheFactory.InvalidateCache();
        }
    }
}
