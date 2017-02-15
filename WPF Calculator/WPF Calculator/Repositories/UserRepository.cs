using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Calculator.Context;
using WPF_Calculator.Entities;

namespace WPF_Calculator.Repositories
{
    public class UserRepository
    {
        private readonly CalculatorContext _context;
        private readonly DbSet<User> _users;

        public UserRepository(CalculatorContext context)
        {
            _context = context;
            _users = context.User;
        }

        public int ValidateUser(string login, string password)
        {
           
            User user = _users.FirstOrDefault(x => x.Login == login && x.Password == password);

            if (user==null)
            {
                return 0;
            }
            
            return user.Id;
        }

        public User GetUserById(int Id)
        {
            User user = _users.FirstOrDefault(x => x.Id == Id);
            return user;
        }
    }
}
