using System.Reflection.Metadata.Ecma335;

namespace BlogWebSite.Models
{
    public class CommentProcedure
    {
        public int CommentID { get; set; }
        public string Username { get; set; }
        public string CommentText { get; set; }
        public DateTime Time { get; set; }
        public int PostID { get; set; }
        public int UserID { get; set; }
        public int Likes { get; set; } = 0;
        public int Dislikes { get; set; } = 0;
    }
}
