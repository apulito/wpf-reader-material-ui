using Newtonsoft.Json;

namespace wpf.reader.material.ui.Models
{
    public class Role
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}