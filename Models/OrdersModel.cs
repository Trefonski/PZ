namespace PZ.Models
{
public class Orders
    {
        public uint ID_Order {get; set;}
        public uint ID_Client {get; set;}
        public uint ID_Date {get; set;}

        //FK
        public Clients Clients {get; set;}
        public List<OrderDates> OrderDates {get; set;}
        
        //FK target
        public List<OrderQuantities> OrderQuantities {get; set;}
    }
}