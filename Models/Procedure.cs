namespace BlogWebSite.Models
{
    public class Procedure
    {
        public string Username { get; set; }
        public string BlogTitle { get; set; }
        public string BlogPost { get; set; }
        public DateTime Time { get; set; }
        public int PostID { get; set; }
        public int UserID { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public string? PostImage { get; set; }
    }
}
