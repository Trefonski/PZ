namespace PZ.Models
{
   public class Pictures
    {
        public ushort ID_Picture {get; set;}
        public byte[] Picture {get; set;}

        //FK target
        public Items Items {get; set;}
    }
}