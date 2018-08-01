using System.Collections.Generic;
using System.Linq;
using CoreStandard.UI.Data;
using CoreStandard.UI.Models;
using HelloWorld;
using HelloWorld_Full;
using Microsoft.AspNetCore.Mvc;

namespace CoreStandard.UI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly CoreStandardDbContext _dbContext;
        private readonly IDecisioner _decisioner;
        private readonly IFullDecisioner _fullDecisioner;

        public ValuesController(CoreStandardDbContext dbContext, IDecisioner decisioner, IFullDecisioner fullDecisioner)
        {
            _dbContext = dbContext;
            _decisioner = decisioner;
            _fullDecisioner = fullDecisioner;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _dbContext.Users.AsQueryable().Select(x => x.Value);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            switch (id)
            {
                case 100:
                {
                    return _decisioner.DoSomeWork();
                }
                case 101:
                {
                    return _fullDecisioner.DoWork();
                }
            }

            return _dbContext.Users.Find(id).Value;
        }

        // POST api/values
        [HttpPost]
        public int Post([FromBody]string value)
        {
            var user = new User(value);
            _dbContext.Add(user);
            _dbContext.SaveChanges();
            return user.Id;
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
