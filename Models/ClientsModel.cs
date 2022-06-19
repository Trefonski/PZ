namespace PZ.Models
{
    public class Clients
    {
        public uint ID_Client {get; set;}
        public string Login {get; set;}
        public string ClientName {get; set;}
        
        //FK target
        public List<Addresses> Addresses {get; set;}
        public List<Orders> Orders {get; set;}
        public List<Reviews> Reviews {get; set;}
    }
}