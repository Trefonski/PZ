namespace PZ.Models
{
    public class Reviews
    {
        public uint ID_Client {get; set;}
        public string ID_Item {get; set;}
        public enum Rating {oneStar=1, twoStars=2, threeStars=3, fourStars=4, fiveStars=5}
        public string Title {get; set;}
        public string Body {get; set;}
        public DateTime DatePosted {get; set;}

        //FK
        public Items Items {get; set;}
        public Clients Clients {get; set;}
    }
}