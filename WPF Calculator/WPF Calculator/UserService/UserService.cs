using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Calculator.Context;
using WPF_Calculator.Entities;
using WPF_Calculator.Repositories;

namespace WPF_Calculator.UserService
{
    public class UserService
    {
        public static int Id;
        private readonly CalculatorContext _context;
        private readonly DbSet<User> _users;
        private readonly UserRepository _userRepository;

        public UserService(CalculatorContext context)
        {
            _context = context;
            _users = context.User;
            _userRepository = new UserRepository(context);
        }

        public User GetCurrentlyLogedUser(int Id)
        {
            return _userRepository.GetUserById(Id);
        }

    }
}
