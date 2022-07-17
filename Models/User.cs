using System;
using System.Collections.Generic;

#nullable disable

namespace TasteonusAPI.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Biodata { get; set; }
        public string LoginMethod { get; set; }
        public int Point { get; set; }
        public List<Recipe> Recipes { get; set; }
        public List<Feedback> Feedbacks { get; set; }
    }
}
