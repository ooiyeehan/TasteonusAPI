using System;
using System.Collections.Generic;

#nullable disable

namespace TasteonusAPI.Models
{
    public partial class Reward
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Point { get; set; }
        public string ImageUrl { get; set; }
    }
}
