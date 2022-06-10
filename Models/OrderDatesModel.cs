namespace PZ.Models
{
    public class OrderDates
    {
        public enum StatusType {Received, Paid, Packed, Sent, Delivered}
        public uint ID_Date {get; set;}
        public uint ID_Order {get; set;}
        public StatusType Status {get; set;}
        public DateTime Date {get; set;}

        //FK
        public Orders Orders {get; set;}
    }
}