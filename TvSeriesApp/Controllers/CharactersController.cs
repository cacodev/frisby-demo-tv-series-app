using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TvSeriesApp.Models;

namespace TvSeriesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly TvSeriesDataContext _dbContext;

        public CharactersController(TvSeriesDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Character>> Get()
        {
            return _dbContext.Characters;
        }
        [HttpGet("{id}")]
        public ActionResult<Character> Get(int id)
        {
            return _dbContext.Characters.Find(id);
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody] Character value)
        {
            _dbContext.Characters.Add(value);
            _dbContext.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Character value)
        {
            _dbContext.Characters.Update(value);
            _dbContext.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var character = _dbContext.Characters.Find(id);
            _dbContext.Characters.Remove(character);
            _dbContext.SaveChanges();
        }
    }
}
