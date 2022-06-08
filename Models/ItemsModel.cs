namespace PZ.Models
{
    public class Items
    {
        public string ID_Item {get; set;}
        public uint ID_Brand {get; set;}
        public float Size {get; set;} //restrict values from 14 to 49.5 with 0.5 step
        public string Colour {get; set;}
        public string Style {get; set;} //https://en.wikipedia.org/wiki/List_of_shoe_styles
        public uint Stock {get; set;}
        public string ItemName {get; set;}
        public enum Sex {mens=1, womens=2, unisex=3, boy=4, girl=5, unisexChild=6}

        //FK
        public Brands Brands {get; set;}
        
        //FK target
        public List<Pictures> Pictures {get; set;}
        public List<OrderQuantities> OrderQuantities {get; set;}
        public List<Reviews> Reviews {get; set;}
    }
}