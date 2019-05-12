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
    public class SeriesController : ControllerBase
    {
        private readonly TvSeriesDataContext _dbContext;

        public SeriesController(TvSeriesDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Series>> Get()
        {
            return _dbContext.Series;
        }
        [HttpGet("{id}")]
        public ActionResult<Series> Get(int id)
        {
            return _dbContext.Series.Find(id);
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody] Series value)
        {
            _dbContext.Series.Add(value);
            _dbContext.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Series value)
        {
            _dbContext.Series.Update(value);
            _dbContext.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var Series = _dbContext.Series.Find(id);
            _dbContext.Series.Remove(Series);
            _dbContext.SaveChanges();
        }
    }
}
