using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Calculator.Entities;

namespace WPF_Calculator.Context
{
    public class CalculatorContext :DbContext
    {
        public CalculatorContext() : base(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Calculator; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False")
        {
            
        }
        public DbSet<Numbers> Numbers { get; set; }
        public DbSet<User> User { get; set; } 
    }
}
