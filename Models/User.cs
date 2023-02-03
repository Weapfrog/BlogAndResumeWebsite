﻿using System.ComponentModel.DataAnnotations;

namespace BlogWebSite.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
