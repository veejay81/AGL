using Newtonsoft.Json;
using System.Collections.Generic;

namespace AglTest.Data
{
    /// <summary>
    /// Owner data model
    /// </summary>
    public class Owner
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("pets")]
        public List<Pet> Pets { get; set; } = new List<Pet>();
    }
}
