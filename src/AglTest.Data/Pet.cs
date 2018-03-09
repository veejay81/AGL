using Newtonsoft.Json;

namespace AglTest.Data
{
    /// <summary>
    /// Pet data model
    /// </summary>
    public class Pet
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
