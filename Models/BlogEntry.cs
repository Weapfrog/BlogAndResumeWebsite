using System.ComponentModel.DataAnnotations;

namespace BlogWebSite.Models
{
    public class BlogEntry
    {
        [Key]
        public int BlogEntryID { get; set; }
        public string BlogTitle { get; set;}
        public string BlogPost { get; set;}
        public DateTime Time { get; set; } = DateTime.Now;
        public int UserID { get; set; } = 1;
        public string? Keywords { get; set; }
    }
}
