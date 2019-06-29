using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public DateTime Birth { get; set; }

        public List<Allergy> Allergies { get; set; }
        public List<Suscription> Suscriptions { get; set; }
    }
}
