using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Dish
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Recipe { get; set; }

        public List<DishIngredient> DishIngredients { get; set; }
        public List<Order> Orders { get; set; }
        public int PlanId { get; set; }
    }
}
