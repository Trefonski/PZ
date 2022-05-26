namespace PZ.Models
{
    public class ItemNames
    {
        public uint ID_ItemName {get; set;}
        public string ItemName {get; set;}

        //FK target
        public Brand Brand {get; set;}    
    }
}