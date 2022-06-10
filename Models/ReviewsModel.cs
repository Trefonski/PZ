namespace PZ.Models
{
    public class Reviews
    {
        public enum RatingType {oneStar=1, twoStars=2, threeStars=3, fourStars=4, fiveStars=5}

        public uint ID_Client {get; set;}
        public string ID_Item {get; set;}
        public string Title {get; set;}
        public string Body {get; set;}
        public RatingType Rating { get; set; }
        public DateTime DatePosted {get; set;}

        //FK
        public Items Items {get; set;}
        public Clients Clients {get; set;}
    }
}