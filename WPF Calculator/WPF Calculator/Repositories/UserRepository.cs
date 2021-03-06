﻿using System;
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
                return 0;
            
            return user.Id;
        }

        public User GetUserById(int Id)
        {
            User user = _users.FirstOrDefault(x => x.Id == Id);
            return user;
        }

        public bool ValidateUserLogin(string login)
        {
            User user =_users.FirstOrDefault(x => x.Login == login);
            if (user == null)
                return true;
            else
            {
                return false;
            }
        }

        public void AddUser(string login, string password, string name, string surname)
        {
            User user = new User();
            user.Login = login;
            user.Password = password;
            user.Name = name;
            user.Surname = surname;
            _users.Add(user);
        }
    }
}
