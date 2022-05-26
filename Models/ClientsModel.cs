namespace PZ.Models
{
public class Clients 
    {
        public uint ID_Client {get; set;}
        public byte ID_Address {get; set;}
        public string Login {get; set;}
        public string Name {get; set;}
        
        //FK
        public List<Addresses> Addresses {get; set;}

        //FK target
        public List<Orders> Orders {get; set;}
        public List<Reviews> Reviews {get; set;}
    }
}