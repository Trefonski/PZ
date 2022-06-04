namespace PZ.Models
{
    public class Brands
    {
        public uint ID_Brand {get; set;}
        public string BrandName {get; set;}

        //FK target
        public Items Items {get; set;}
    }
}