namespace PZ.Models
{
    public class OrderDates
    {
        public uint ID_Date {get; set;}
        public uint ID_Order {get; set;}
        public byte ID_Status {get; set;}
        public DateTime Date {get; set;}

        //FK        
        public Status Status {get; set;}
        public Orders Orders {get; set;}
    }
}