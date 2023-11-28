using Feed.API.Data;
using Feed.API.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Feed.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        public readonly ApplicationContext _applicationContext;
        public FeedController(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        // POST api/<FeedController>
        [HttpPost]
        public void Post([FromBody] FeedEntity feed)
        {

            _applicationContext.Add(feed);
            _applicationContext.SaveChanges();
        }

        //GET api/<FeedController>/5
        [HttpGet("{email}")]
        public async Task<FeedEntity?> GetByEmail(string email)
        {
            var feedEntities = await _applicationContext.Feed.Where(e => e.Email == email).FirstOrDefaultAsync();

            return feedEntities;
        }

        /*// GET: api/<FeedController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // PUT api/<FeedController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FeedController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
