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

        private static User _loggedInUser;

        public static int LoggedInUserId
        {
            get { return _loggedInUser?.Id ?? 0; }
        }

        public static string UserFullName
        {
            get
            {
                if (_loggedInUser == null)
                {
                    return "";
                }
                else
                {
                    return _loggedInUser.Name + " " + _loggedInUser.Surname;
                }
            }
        }

        public static void AssignLoggedInUser(User user)
        {
            _loggedInUser = user;
        }
    }
}
