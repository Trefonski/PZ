namespace PZ.Models
{
    public class Brand
    {
        public string ID_Brand {get; set;}
        public uint ID_ItemName {get; set;}

        //FK
        public List<ItemNames> ItemNames {get; set;}

        //FK target
        public Items Items {get; set;}
    }
}