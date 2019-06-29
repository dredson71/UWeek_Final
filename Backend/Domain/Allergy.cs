using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Allergy
    {
        [Key]
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        [Key]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
