using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApiPubs.Models;

namespace WebApiPubs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly pubsContext context;

        public StoreController(pubsContext context)
        {
            this.context = context;
        }

        //Get
        [HttpGet]
        public ActionResult<IEnumerable<Store>> Get()
        {
            return context.Stores.ToList();
        }

        //Post
        [HttpPost]
        public ActionResult<Store> Post(Store store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Stores.Add(store);
            context.SaveChanges();
            return Ok();
        }

        //Put
        //Delete

        //Adicionales
        //GetbyId
        //GetbyName
        //GetbyZip
        //GetbyCityState
    }
}
