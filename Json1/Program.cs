using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Json_Task {
    class Program {
        static void Main (string[] args) {

            json obj = new json ();

            var ObjekList = JsonConvert.DeserializeObject<List<objek>> (obj.jsonformat);

            System.Console.WriteLine ();
            System.Console.WriteLine ("--- DESERIALIZED FIRST JSON FORMAT ---");
            System.Console.WriteLine ();

            Console.WriteLine ("User who doesn't have any phone number :");
            // foreach (var a in ObjekList)
            // {
            //     if ((a.profile.Phones).Count == 0)
            //         Console.WriteLine("- " + a.profile.Fullname);
            // }
            var noPhone = ObjekList.Where (a => a.profile.Phones.Count == 0).Select (a => a.profile.Fullname);
            foreach (var item in noPhone) {
                Console.WriteLine (item);
            }

            Console.WriteLine ("\nUser who have article :");
            var haveArticle = ObjekList.Where (a => a.ArticleList.Count != 0).Select (a => a.profile.Fullname);
            foreach (var item in haveArticle) {
                Console.WriteLine (item);
            }

            Console.WriteLine ();
            Console.WriteLine ("User who have annis in their name :");
            var containAnnis = ObjekList.Where (a => a.profile.Fullname.Contains ("Annis")).Select (a => a.Username);
            foreach (var item in containAnnis) {
                Console.WriteLine (item);
            }

            Console.WriteLine ("\nUser who have articles on year 2020 :");
            var article2020 = from item in ObjekList
            from a in item.ArticleList
            where a.Published.Year == 2020
            select item.Username;
            foreach (var item in article2020) {
                Console.WriteLine (item);
            }

            Console.WriteLine ("\nUser who are born on 1986 :");
            var born1986 = ObjekList.Where (a => a.profile.BirthDay.Year == 1986).Select (a => a.profile.Fullname);
            foreach (var item in born1986) {
                Console.WriteLine (item);
            }

            Console.WriteLine ("\nArticles that contain Tips on the title :");
            var articleTips = from item in ObjekList
            from a in item.ArticleList
            where a.Title.Contains ("Tips")
            select a.Title;
            foreach (var item in articleTips) {
                Console.WriteLine (item);
            }

            Console.WriteLine ("\nArticle that published before August 2019 :");
            var before2019 = from item in ObjekList
            from a in item.ArticleList
            where a.Published.Year == 2019 && a.Published.Month < 8
            select a.Title;
            foreach (var item in before2019) {
                Console.WriteLine (item);
            }
        }
    }

    public class json {
        public string jsonformat = @"[{
                                ""id"": 323,
                                ""username"": ""rinood30"",
                                ""profile"": {
                                ""full_name"": ""Shabrina Fauzan"",
                                ""birthday"": ""1988-10-30"",
                                ""phones"": [
                                    ""08133473821"",
                                    ""082539163912"",
                                ],
                                },
                                ""articles"": [
                                {
                                    ""id"": 3,
                                    ""title"": ""Tips Berbagi Makanan"",
                                    ""published_at"": ""2019-01-03T16:00:00""
                                },
                                {
                                    ""id"": 7,
                                    ""title"": ""Cara Membakar Ikan"",
                                    ""published_at"": ""2019-01-07T14:00:00""
                                }
                                ]
                            },
                            {
                                ""id"": 201,
                                ""username"": ""norisa"",
                                ""profile"": {
                                ""full_name"": ""Noor Annisa"",
                                ""birthday"": ""1986-08-14"",
                                ""phones"": [],
                                },
                                ""articles"": [
                                {
                                    ""id"": 82,
                                    ""title"": ""Cara Membuat Kue Kering"",
                                    ""published_at"": ""2019-10-08T11:00:00""
                                },
                                {
                                    ""id"": 91,
                                    ""title"": ""Cara Membuat Brownies"",
                                    ""published_at"": ""2019-11-11T13:00:00""
                                },
                                {
                                    ""id"": 31,
                                    ""title"": ""Cara Membuat Brownies"",
                                    ""published_at"": ""2019-11-11T13:00:00""
                                }
                                ]
                            },
                            {
                                ""id"": 42,
                                ""username"": ""karina"",
                                ""profile"": {
                                ""full_name"": ""Karina Triandini"",
                                ""birthday"": ""1986-04-14"",
                                ""phones"": [
                                    ""06133929341""
                                ],
                                },
                                ""articles"": []
                            },
                            {
                                ""id"": 201,
                                ""username"": ""icha"",
                                ""profile"": {
                                ""full_name"": ""Annisa Rachmawaty"",
                                ""birthday"": ""1987-12-30"",
                                ""phones"": [],
                                },
                                ""articles"": [
                                {
                                    ""id"": 39,
                                    ""title"": ""Tips Berbelanja Bulan Tua"",
                                    ""published_at"": ""2019-04-06T07:00:00""
                                },
                                {
                                    ""id"": 43,
                                    ""title"": ""Cara Memilih Permainan di Steam"",
                                    ""published_at"": ""2019-06-11T05:00:00""
                                },
                                {
                                    ""id"": 58,
                                    ""title"": ""Cara Membuat Brownies"",
                                    ""published_at"": ""2019-09-12T04:00:00""
                                }
                                ]
                            }]";
    }

    class profile {
        [JsonProperty ("full_name")]
        public string Fullname { get; set; }

        [JsonProperty ("birthday")]
        public DateTime BirthDay { get; set; }

        [JsonProperty ("phones")]
        public List<string> Phones { get; set; } = new List<string> ();
    }

    class articles {
        [JsonProperty ("id")]
        public int Id { get; set; } = 0;

        [JsonProperty ("title")]
        public string Title { get; set; }

        [JsonProperty ("published_at")]
        public DateTime Published { get; set; }
    }

    class objek {
        [JsonProperty ("id")]
        public int Id { get; set; }

        [JsonProperty ("username")]
        public string Username { get; set; }

        [JsonProperty ("profile")]
        public profile profile { get; set; } = new profile ();

        [JsonProperty ("articles")]
        public List<articles> ArticleList { get; set; } = new List<articles> ();
    }
}