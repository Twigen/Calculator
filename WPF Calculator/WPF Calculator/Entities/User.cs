using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Calculator.Entities
{
   public class User
    {
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(450)]
        [Index]
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        ICollection<Numbers> Numberses { get; set; } 
    }
}
