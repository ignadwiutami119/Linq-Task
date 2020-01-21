using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections;

namespace Json_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            json obj = new json();
            var ObjekList = JsonConvert.DeserializeObject<List<objek>>(obj.jsonformat);
            var CustomerList = JsonConvert.DeserializeObject<List<customer>>(obj.jsonformat);

            Console.WriteLine();
            Console.WriteLine("--------DESERIALIZED SECOND JSON FORMAT--------");
            Console.WriteLine();
            Console.WriteLine("All purchase made in February (show in id):");
            int month;
            foreach (var a in ObjekList)
            {
                month = (a.Created).Month;
                if (month == 2)
                {
                    Console.WriteLine("Order ID : " + a.Id);
                }
            }

            System.Console.WriteLine();
            Console.WriteLine("All purchase made by Ari (show in id):");
            foreach (var a in ObjekList)
            {
                if ((a.Customer.Name).Contains("Ari"))
                {
                    Console.WriteLine("Order ID : " + a.Id);
                }
            }

            System.Console.WriteLine();
            System.Console.WriteLine("Grand total of item that purcashed by Ari : ");
            Console.WriteLine(AriPrice());

            System.Console.WriteLine();
            System.Console.WriteLine("People who have purchases with grand total lower than 300000 : ");
            Console.WriteLine(lowerPrice());

            int AriPrice()
            {
                int sum = 0;
                foreach (var a in ObjekList)
                {
                    if ((a.Customer.Name).Contains("Ari"))
                    {
                        // foreach (var b in )
                        // {
                        //     if (b.Key == "price")
                        //     {
                        //         sum += Convert.ToInt32(b.Value);
                        //     }
                        // }
                        foreach (var b in a.ItemList)
                            sum += ((b.Price) * (b.Quantity));
                    }
                }
                return sum;
            }

            int AnnisPrice()
            {
                int sum = 0;
                foreach (var a in ObjekList)
                {
                    if ((a.Customer.Name).Contains("Annis"))
                    {

                        foreach (var b in a.ItemList)
                            sum += ((b.Price) * (b.Quantity));
                    }
                }
                return sum;
            }

            int RirinPrice()
            {
                int sum = 0;
                foreach (var a in ObjekList)
                {
                    if ((a.Customer.Name).Contains("Ririn"))
                    {

                        foreach (var b in a.ItemList)
                            sum += ((b.Price) * (b.Quantity));
                    }
                }
                return sum;
            }


            string lowerPrice()
            {
                string hasil = "";

                Dictionary<string, int> list = new Dictionary<string, int>(){
                {"Ari",AriPrice()},
                {"Annis",AnnisPrice()},
                {"Ririn",RirinPrice()}
              };

                foreach (KeyValuePair<string, int> item in list)
                    if (item.Value < 300000)
                    {
                        hasil += item.Key + "\n";
                    }
                return hasil;
            }
        }
    }


    class json
    {
        public string jsonformat = @"[
  {
    ""order_id"": ""SO-921"",
    ""created_at"": ""2018-02-17T03:24:12"",
    ""customer"": { ""id"": 33, ""name"": ""Ari"" },
    ""items"": [
      { ""id"": 24, ""name"": ""Sapu Lidi"", ""qty"": 2, ""price"": 13200 }, 
      { ""id"": 73, ""name"": ""Sprei 160x200 polos"", ""qty"": 1, ""price"": 149000 }
    ]
  },
  {
    ""order_id"": ""SO-922"",
    ""created_at"": ""2018-02-20T13:10:32"",
    ""customer"": { ""id"": 40, ""name"": ""Ririn"" },
    ""items"": [
      { ""id"": 83, ""name"": ""Rice Cooker"", ""qty"": 1, ""price"": 258000 },
      { ""id"": 24, ""name"": ""Sapu Lidi"", ""qty"": 1, ""price"": 13200 }, 
      { ""id"": 30, ""name"": ""Teflon"", ""qty"": 1, ""price"": 190000 }
    ]
  },
  {
    ""order_id"": ""SO-923"",
    ""created_at"": ""2018-02-28T15:20:43"",
    ""customer"": { ""id"": 33, ""name"": ""Ari"" },
    ""items"": [
      { ""id"": 303, ""name"": ""Pematik Api"", ""qty"": 1, ""price"": 12000 }, 
      { ""id"": 49, ""name"": ""Panci"", ""qty"": 2, ""price"": 70000 }
    ]
  },
  {
    ""order_id"": ""SO-924"",
    ""created_at"": ""2018-03-02T14:30:54"",
    ""customer"": { ""id"": 40, ""name"": ""Ririn"" },
    ""items"": [
      { ""id"": 986, ""name"": ""TV LCD 40 inch"", ""qty"": 1, ""price"": 6000000 }
    ]
  },
  {
    ""order_id"": ""SO-925"",
    ""created_at"": ""2018-03-03T14:52:22"",
    ""customer"": { ""id"": 33, ""name"": ""Ari"" },
    ""items"": [
      { ""id"": 1033, ""name"": ""Nintendo Switch"", ""qty"": 1, ""price"": 4990000 }, 
      { ""id"": 2003, ""name"": ""Macbook Air 11 inch 128 GB"", ""qty"": 1, ""price"": 12000000 },
      { ""id"": 23, ""name"": ""Pocari Sweat 600ML"", ""qty"": 5, ""price"": 7000 }
    ]
  },
  {
    ""order_id"": ""SO-926"",
    ""created_at"": ""2018-03-05T16:23:20"",
    ""customer"": { ""id"": 58, ""name"": ""Annis"" },
    ""items"": [
      { ""id"": 24, ""name"": ""Sapu Lidi"", ""qty"": 3, ""price"": 13200 }
    ]
  }
]";
    }


    class customer
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    class objek
    {
        [JsonProperty("order_id")]
        public string Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime Created { get; set; }

        [JsonProperty("customer")]
        public customer Customer { get; set; }

        [JsonProperty("items")]
        public List<items> ItemList { get; set; } = new List<items>();
    }

    public class items
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("qty")]
        public int Quantity { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }
    }
}
