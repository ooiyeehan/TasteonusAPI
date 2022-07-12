using System;
using System.Collections.Generic;

#nullable disable

namespace TasteonusAPI.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Point { get; set; }
        public Recipe Recipe { get; set; }
        public Feedback Feedback { get; set; }
    }
}
