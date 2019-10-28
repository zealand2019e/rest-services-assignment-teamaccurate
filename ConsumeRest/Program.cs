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
            IList<Item> Items = await worker.GetAllItemsAsync();
            Item Item = await worker.GetOneItemsAsync(1);
            foreach(Item i in Items)
            {
                Console.WriteLine(i);
            }
           
            Console.WriteLine(Item);
            Console.ReadLine();
        }
    }
}
