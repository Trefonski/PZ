using System.Text.Json.Serialization;

namespace PZ.Models
{
    public class Addresses
    {
        public byte ID_Address {get; set;}
        public uint ID_Client {get; set;}
        public bool Default {get; set;}
        public string City {get; set;}
        public string Voivodeship{get; set;}
        public string County {get; set;}
        public string PostCode {get; set;}
        public string Street {get; set;}
        public ushort BlockNo {get; set;}
        public ushort HouseNo {get; set;}

        //FK
        [JsonIgnore]
        public Clients Clients {get; set;}
    }
}