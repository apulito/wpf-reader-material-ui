using Newtonsoft.Json;

namespace wpf.reader.material.ui.Models
{
    public class Configurator
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("person")]
        public Person Person { get; set; }
    }
}