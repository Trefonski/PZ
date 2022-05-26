namespace PZ.Models
{
    public class OrderDates
    {
        public uint ID_Date {get; set;}
        public byte ID_Status {get; set;}
        public DateTime Date {get; set;}

        //FK        
        public Status Status {get; set;}

        //FK target
        public Orders Orders {get; set;}
    }
}