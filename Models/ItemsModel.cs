namespace PZ.Models
{
    public class Items
    {
        public string ID_Item {get; set;}
        public ushort ID_Picture {get; set;}
        public string ID_Brand {get; set;}
        public float Size {get; set;} //restrict values from 14 to 49.5 with 0.5 step
        public string Colour {get; set;}
        public string Style {get; set;} //https://en.wikipedia.org/wiki/List_of_shoe_styles
        public uint Quantity {get; set;}

        //FK
        public List<Pictures> Pictures {get; set;}
        public Brand Brand {get; set;}
        
        //FK target
        public List<OrderQuantities> OrderQuantities {get; set;}
        public List<Reviews> Reviews {get; set;}
    }
}