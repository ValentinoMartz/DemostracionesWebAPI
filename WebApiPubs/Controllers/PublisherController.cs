using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using WebApiPubs.Models;
using Publisher = WebApiPubs.Models.Publisher;

namespace WebApiPubs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly pubsContext context;

        public PublisherController(pubsContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Publisher>> Get()
        {
            return context.Publishers.ToList();
        }

        [HttpPost]
        public ActionResult<Publisher> Post(Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Publishers.Add(publisher);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<Publisher> Put(int id, [FromBody] Publisher publisher)
        {
            if (id.ToString() != publisher.PubId)
            {
                return BadRequest();
            }
            context.Entry(publisher).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Publisher> Delete(string id)
        {
            var publisherOriginal = (from c in context.Publishers
                                   where c.PubId == id
                                   select c).SingleOrDefault();

            if (publisherOriginal == null)
            {
                return NotFound();
            }
            context.Publishers.Remove(publisherOriginal);
            context.SaveChanges();
            return publisherOriginal;

        }
    }
}
