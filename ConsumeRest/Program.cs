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
            IList<Item> Item = await worker.GetAllItemsAsync();
           // Console.WriteLine(worker.GetAllItemsAsync().ToString());
            Console.WriteLine(Item.ToString());
            Console.ReadLine();
        }
    }
}
