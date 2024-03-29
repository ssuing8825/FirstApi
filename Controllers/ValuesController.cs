﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace FirstApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly EnvironmentConfig _configuration;

        public ValuesController(IOptionsMonitor<EnvironmentConfig> configuration)
        {
            _configuration = configuration.CurrentValue;

        }

        // GET api/values
        [HttpGet]
        public string Get()
        {
           // return "Ok heres asdfasdf";
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = client.GetAsync("http://secondapi_image/api/values").Result)
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = content.ReadAsStringAsync().Result;
                return result +"And I'm in teh first AP dI";
            }
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

    public class EnvironmentConfig
    {
        public string SecondApiUrl { get; set; }
    }

}
