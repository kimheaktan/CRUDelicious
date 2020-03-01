using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        [Required]
        public int DishId { get; set; }
        // MySQL VARCHAR and TEXT types can be represeted by a string
        [Required]
        public string Name { get; set; }

        [Required]
        public string Chef{get;set;}

        [Required]
        public int Tastiness { get; set; }
        [Required]
        // [Range(double.Epsilon, double.MaxValue)]
        public int Calories { get; set; }
        [Required]
        public string Description { get; set; }

        // The MySQL DATETIME type can be represented by a DateTime
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}

    