using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModelLib;
using Newtonsoft.Json;


namespace ConsumeRest
{
    class Program
    {
        static async Task Main(string[] args)
        {

            Worker worker = new Worker();


           await worker.PostItemAsync(12, "Chciken", "High", 24);
            await worker.PutItemAsync(2, 2, "Beens", "Medium", 26);
           // await worker.DeleteItemAsync(2);


            IList<Item> Items = await worker.GetAllItemsAsync();
            Item Item = await worker.GetOneItemsAsync(1);
            foreach (Item i in Items)
            {
                Console.WriteLine(i.ToString());
            }

            Console.WriteLine(Item.ToString());
            Console.ReadLine();
        }
    }
}
