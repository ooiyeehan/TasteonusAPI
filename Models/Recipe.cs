using System;
using System.Collections.Generic;

#nullable disable

namespace TasteonusAPI.Models
{
    public partial class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredient { get; set; }
        public string Instruction { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public double Rating { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
