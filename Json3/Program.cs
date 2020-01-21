using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
      Console.WriteLine ("Item in Sangkuriang room : ");
      Console.WriteLine (totalItem () + "\n");
      Console.WriteLine ("All electronic devices : ");
      Console.WriteLine (findItem ("electronic"));
      Console.WriteLine ("All furniture : ");
      Console.WriteLine (findItem ("furniture"));
      Console.WriteLine ("All item was purcashed at 16 Januari 2020 : ");
      Console.WriteLine (findPurcashed () + "\n");
      Console.WriteLine ("All item with brown color : ");
      Console.WriteLine (findBrown () + "\n");

      int totalItem () {
        int total = 0;
        var Sangkuriang_item = ObjekList.Where (a => a.Placement.Name == "Sangkuriang").Select (a => a.Id);
        total = Sangkuriang_item.Count ();
        return total;
      }

      string findItem (string input) {
        string result = "";
        int no =1;
        var findItem = ObjekList.Where (a => a.Type == input).Select (a => a.Name);
        foreach (var item in findItem) {
          result += no + ". "+ item + "\n";
          no++;
        }
        return result;
      }

      string findPurcashed () {
        string result = "";
          var get = ObjekList.Where (a =>
            (DateTimeOffset.FromUnixTimeSeconds (a.Purcashed).DateTime.Day == 16) &&
            (DateTimeOffset.FromUnixTimeSeconds (a.Purcashed).DateTime.Month == 1) &&
            (DateTimeOffset.FromUnixTimeSeconds (a.Purcashed).DateTime.Year == 2020)).Select (a => a.Name);
        int no = 1;
        foreach (var a in get) {
          result += no +". "+ a + "\n";
          no++;
        }
      return result;
    }

    string findBrown () {
      string result = "";
      int no = 1;
      var brown = ObjekList.Where (a => a.Tags.Contains ("brown")).Select (a => a.Name);
      foreach (var a in brown) {
        result += no+ ". "+ a + "\n";
        no++;
      }
      return result;
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