using System;
using System.Collections.Generic;

#nullable disable

namespace TasteonusAPI.Models
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        public User User { get; set; }
        public Recipe Recipe { get; set; }
    }
}
