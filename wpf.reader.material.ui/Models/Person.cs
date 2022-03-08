using Newtonsoft.Json;
using System.Collections.Generic;

namespace wpf.reader.material.ui.Models
{
    public class Person
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        public string Fullname
        {
            get
            {
                return $"{Name} {Surname}";
            }
        }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("roles")]
        public List<Role> Roles { get; set; }
    }
}