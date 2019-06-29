using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class DishIngredient
    {
        [Key]
        public int DishId { get; set; }
        public Dish Dish { get; set; }
        [Key]
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }


    }
}
