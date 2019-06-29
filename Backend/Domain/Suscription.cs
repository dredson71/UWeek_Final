using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Suscription
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Qdays { get; set; }
        public int Qpeople { get; set; }
        public float Subcost { get; set; }
        public DateTime Dateinit { get; set; }
        public DateTime Dateend { get; set; }
        public string Turndelivery { get; set; }
        public List<Order> Orders { get; set; }
        public int UserId { get; set; }
    }
}
