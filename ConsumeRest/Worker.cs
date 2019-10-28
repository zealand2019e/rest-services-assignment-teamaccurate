using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModelLib;
using Newtonsoft.Json;

namespace ConsumeRest
{
   public class Worker
    {
        private string URI = "http://localhost:50067/api/Items";

         public void Start()
         {
          
         }

        public async Task<IList<Item>> GetAllItemsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(URI);
                IList<Item> cList =
                JsonConvert.DeserializeObject<IList<Item>>(content);
                return cList;
            }
        }


        public async Task<Item> GetOneItemsAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(URI + $"/{id}");
                Item returnedContent = JsonConvert.DeserializeObject<Item>(content);
                return returnedContent;
            }
        }
    
    
    }
}
