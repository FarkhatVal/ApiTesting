using Newtonsoft.Json;

namespace DemoApiTesting
{
    public class ReqresResponse
    {
            [JsonProperty("page")]
            public int Page { get; set; }
        
            [JsonProperty("per_page")]
            public int? Per_page { get; set; }
            [JsonProperty("total")]
            public int? Total { get; set; }
            [JsonProperty("total_pages")]
            public int? Total_pages { get; set; }
            [JsonProperty("data")] 
            public Users [] Data { get; set; }
            
    }
    public class NameJob
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("job")]
        public string Job { get; set; }
    }
}

         public class Users
         {
             [JsonProperty("id")]
             public string Id { get; set; }
             [JsonProperty("email")]
             public string Email { get; set; }
             [JsonProperty("first_name")]
             public string First_name { get; set; }
             [JsonProperty("last_name")]
             public string Last_name { get; set; }
             [JsonProperty("avatar")]
             public string Avatar { get; set; }
         }


