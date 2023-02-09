namespace BlogWebSite.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string CommentText { get; set; }
        public int UserID { get; set; }
        public int PostID { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
        public int Likes { get; set; } = 0;
        public int Dislikes { get; set; } = 0;
    }
}
