using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Json3 {
  class Program {
    static void Main (string[] args) {
      String jsonformat = @"[
  {
    ""inventory_id"": 9382,
    ""name"": ""Brown Chair"",
    ""type"": ""furniture"",
    ""tags"": [
      ""chair"",
      ""furniture"",
      ""brown""
    ],
    ""purchased_at"": 1579190471,
    ""placement"": {
      ""room_id"": 3,
      ""name"": ""Sangkuriang""
    }
  },
  {
    ""inventory_id"": 9380,
    ""name"": ""Big Desk"",
    ""type"": ""furniture"",
    ""tags"": [
      ""desk"",
      ""furniture"",
      ""brown""
    ],
    ""purchased_at"": 1579190642,
    ""placement"": {
      ""room_id"": 3,
      ""name"": ""Sangkuriang""
    }
  },
  {
    ""inventory_id"": 2932,
    ""name"": ""LG Monitor 50 inch"",
    ""type"": ""electronic"",
    ""tags"": [
      ""monitor""
    ],
    ""purchased_at"": 1579017842,
    ""placement"": {
      ""room_id"": 3,
      ""name"": ""Sangkuriang""
    }
  },
  {
    ""inventory_id"": 232,
    ""name"": ""Sharp Pendingin Ruangan 2PK"",
    ""type"": ""electronic"",
    ""tags"": [
      ""ac""
    ],
    ""purchased_at"": 1578931442,
    ""placement"": {
      ""room_id"": 5,
      ""name"": ""Dhanapala""
    }
  },
  {
    ""inventory_id"": 9382,
    ""name"": ""Alat Makan"",
    ""type"": ""tableware"",
    ""tags"": [
      ""spoon"",
      ""fork"",
      ""tableware""
    ],
    ""purchased_at"": 1578672242,
    ""placement"": {
      ""room_id"": 10,
      ""name"": ""Rajawali""
    }
  }
]";

      var ObjekList = JsonConvert.DeserializeObject<List<objek>> (jsonformat);

      Console.WriteLine ("\n--------DESERIALIZED THIRD JSON FORMAT--------\n");
      Console.WriteLine ("\nItem in Sangkuriang room : ");
      Console.WriteLine (totalItem () + "\n");
      Console.WriteLine ("All electronic devices : ");
      Console.WriteLine (findItem ("electronic") + "\n");
      Console.WriteLine ("All furniture : ");
      Console.WriteLine (findItem ("furniture") + "\n");
      Console.WriteLine ("All item was purcashed at 16 Januari 2020 : ");
      Console.WriteLine (findPurcashed () + "\n");
      Console.WriteLine ("All item with brown color : ");
      Console.WriteLine (findBrown () + "\n");

      int totalItem () {
        int total = 0;
        foreach (var a in ObjekList) {
          if (a.Placement.Name == "Sangkuriang") {
            total++;
            System.Console.WriteLine (total + ". " + a.Name);
          }
        }
        System.Console.WriteLine ("Total item : ");
        return total;
      }

      string findItem (string input) {
        string hasil = "";
        int number = 0;
        foreach (var a in ObjekList) {
          if (a.Type == input) {
            number++;
            hasil += number + ". " + a.Name + "\n";
          }
        }
        return hasil;
      }

      string findPurcashed () {
        string hasil = "";
        int number = 0;
        // DateTime dtDateTime = new DateTime ();
        foreach (var obj in ObjekList) {
          var tgl = DateTimeOffset.FromUnixTimeSeconds(obj.Purcashed).DateTime;
          if (tgl.Day==16 && tgl.Month == 1 && tgl.Year == 2020) {
            number++;
            hasil += number + ". " + obj.Name + "\n";
          }
        }
        return hasil;
      }

      string findBrown () {
        string hasil = "";
        int number = 0;
        foreach (var a in ObjekList) {
          if (a.Tags.Contains ("brown")) {
            number++;
            hasil += number + ". " + a.Name + "\n";
          }
        }
        return hasil;
      }
    }
  }

  class objek {
    [JsonProperty ("inventory_id")]
    public int Id { get; set; }

    [JsonProperty ("name")]
    public string Name { get; set; }

    [JsonProperty ("type")]
    public string Type { get; set; }

    [JsonProperty ("tags")]
    public List<string> Tags { get; set; } = new List<string> ();

    [JsonProperty ("purchased_at")]
    public long Purcashed { get; set; }

    [JsonProperty ("placement")]
    public placement Placement { get; set; } = new placement ();
  }

  class placement {
    [JsonProperty ("room_id")]
    public int Id { get; set; }

    [JsonProperty ("name")]
    public string Name { get; set; }
  }
}