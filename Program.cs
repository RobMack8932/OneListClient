using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OneListClient
{

    class Item
    {
        public int id { get; set; }
        public string type { get; set; }
        public string setup { get; set; }
        public string punchline { get; set; }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            var responseAsStream = await client.GetStreamAsync(
            "https://official-joke-api.appspot.com/random_ten"
            );
            var items = await JsonSerializer.DeserializeAsync<List<Item>>(responseAsStream);

            foreach (var item in items)
            {
                Console.WriteLine($"{item.setup}.... { item.punchline}");
            }
        }
    }
}
