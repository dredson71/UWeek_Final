using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Ingredient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<DishIngredient> DishIngredients { get; set; }
        public List<Allergy> Allergies { get; set; }
    }
}
