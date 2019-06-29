using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Order
    {
        [Key]
        public int DishId { get; set; }
        public Dish Dish { get; set; }
        [Key]
        public int SuscriptionId { get; set; }
        public Suscription Suscription { get; set; }
        public DateTime Dentrega { get; set; }
    }
}
