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
    
        
        public async Task DeleteItemAsync(int id)
        {
            using(HttpClient client = new HttpClient())
            {
                await client.DeleteAsync(URI + $"/{id}");
            }
        }
 
        public async Task PostItemAsync(int id, string name, string quality, double quantity)
        {
           
            Item ToPostItem = new Item( id, name, quality, quantity);
            using (HttpClient client = new HttpClient())
            {
                string content = JsonConvert.SerializeObject(ToPostItem);
                await client.PostAsync(URI, new StringContent(content,Encoding.UTF8, "application/json"));
            }
        }
    
        public async Task PutItemAsync(int id, int newID, string name, string quality, double quantity)
        {
            using(HttpClient client = new HttpClient())
            {
                Item ItemToChange = new Item(newID, name, quality, quantity);
                string content = JsonConvert.SerializeObject(ItemToChange);
               await client.PutAsync(URI + $"/{id}", new StringContent(content, Encoding.UTF8, "application/json"));
            }

        }
    
    }
}
