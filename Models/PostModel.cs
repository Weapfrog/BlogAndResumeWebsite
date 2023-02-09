namespace BlogWebSite.Models
{
    public class PostModel
    {
        public Procedure BlogEntryModel { get; set; }
        public List<CommentProcedure> CommentModel { get; set; }
        public int PostID { get; set; }
    }
}
