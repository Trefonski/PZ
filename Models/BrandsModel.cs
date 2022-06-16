using System.Text.Json.Serialization;

namespace PZ.Models
{
    public class Brands
    {
        public uint ID_Brand {get; set;}
        public string BrandName {get; set;}

        //FK target
        [JsonIgnore]
        public List<Items> Items {get; set;}
    }
}