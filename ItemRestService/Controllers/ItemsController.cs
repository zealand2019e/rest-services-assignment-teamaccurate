using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib.Model;
using ModelLib;

namespace ItemRestService.Controllers
{
    [Route("api/Items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {

        private static readonly List<Item> items = new List<Item>()
         {
         new Item(1,"Bread","Low",33),
         new Item(2,"Bread","Middle",21),
         new Item(3,"Beer","low",70.5),
         new Item(4,"Soda","High",21.4),
         new Item(5,"Milk","Low",55.8)
         }; 



        // GET: api/Items
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return items;
        }

        // GET: api/Items/5
        [HttpGet]
        [Route("{id}")]
        public Item Get(int id)
        {
            return items.Find(i => i.Id == id);
        }

        // POST: api/Items
        [HttpPost]
        public void Post([FromBody] Item value)
        {
            items.Add(value);
        }

        // PUT: api/Items/5
        [HttpPut]
        [Route("{id}")]
        public void Put(int id, [FromBody] Item value)
        {
            Item item = Get(id);
            if (item != null)
            {
                item.Id = value.Id;
                item.Name = value.Name;
                item.Quality = value.Quality;
                item.Quantity = value.Quantity;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            Item item = Get(id);
            items.Remove(item);
        }

        [HttpGet]
        [Route("Name/{substring}")]
        public IEnumerable<Item> GetFromSubstring(String substring)
        {
            return items.FindAll(i => i.Name.Contains(substring));
        }

        [HttpGet]
        [Route("Names/{quality}")]
        public IEnumerable<Item> GetQuality(String quality)
        {
            return items.FindAll(i => i.Quality == "Low" || i.Quality == "Middle" || i.Quality == "High");
        }

        [HttpGet]
        [Route("Quant/{filters?}")]
        public IEnumerable<Item> GetWithFilter(string filters)
        {
            string[] words = filters.Split(" ");            
            double filter1 = Convert.ToDouble(words[0]);
            double filter2 = Convert.ToDouble(words[1]);
            return items.FindAll(i => i.Quantity >= filter1 && i.Quantity <= filter2);
        }

        

    }
}
