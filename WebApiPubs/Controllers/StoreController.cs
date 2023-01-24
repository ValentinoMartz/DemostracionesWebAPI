﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpPut("{id}")]
        public ActionResult<Store> Put(string id, [FromBody] Store store)
        {
            if (id != store.StorId)
            {
                return BadRequest();
            }
            context.Entry(store).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        //Delete
        [HttpDelete("{id}")]
        public ActionResult<Store> Delete(string id)
        {
            var store = (from c in context.Stores
                         where c.StorId == id
                         select c).SingleOrDefault();

            if (store == null)
            {
                return NotFound();
            }
            context.Stores.Remove(store);
            context.SaveChanges();
            return store;
        }


        //Adicionales
        //GetbyId
        [HttpGet("{id}")]
        public ActionResult<Store> GetById(string ID)
        {
            Store store = (from e in context.Stores
                           where e.StorId == ID
                           select e).SingleOrDefault();
            return store;
        }

        //GetbyName
        [HttpGet("name/{name}")]
        public ActionResult<Store> GetByName(string name)
        {
            Store store = (from c in context.Stores
                         where c.StorName == name
                         select c).SingleOrDefault();

            if (store == null)
            {
                return NotFound();
            }
            return store;
        }
        //GetbyZip
        [HttpGet("zip/{zip}")]
        public ActionResult<IEnumerable<Store>> GetByZip(string zip)
        {

            List<Store> stores = (from e in context.Stores
                                  where e.Zip == zip
                                  select e).ToList();
            return stores;
        }

        //GetbyCityState
        [HttpGet("city/{city}")]
        public ActionResult<IEnumerable<Store>> GetByCity(string city)
        {

            List<Store> stores = (from e in context.Stores
                                  where e.City == city
                                  select e).ToList();
            return stores;
        }
    }
}
