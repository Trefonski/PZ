namespace PZ.Models
{
    public class Status
    {
        public byte ID_Status {get; set;}
        public enum enumStatus {Received, Paid, Packed, Sent, Delivered}

        //FK target
        public List<OrderDates> OrderDates {get; set;}
    }
}