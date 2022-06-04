namespace PZ.Models
{
    public class OrderQuantities
    {
        public uint ID_Order {get; set;}
        public string ID_Item {get; set;}
        public ushort Quantity {get; set;}

        //FK
        public Orders Orders {get; set;}
        public Items Items {get; set;}
    }
}