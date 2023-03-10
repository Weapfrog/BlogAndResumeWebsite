using System.ComponentModel.DataAnnotations;
using static System.Net.WebRequestMethods;

namespace BlogWebSite.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string eMail { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? NameSurname { get; set; }
        public int? age { get; set; }
        public string? About { get; set; }
        public string? UserPicture { get; set; }
    }
}
