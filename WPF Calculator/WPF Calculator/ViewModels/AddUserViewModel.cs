using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using  GalaSoft.MvvmLight.Command;
using WPF_Calculator.Context;
using WPF_Calculator.Repositories;
using WPF_Calculator.Views;

namespace WPF_Calculator.ViewModels
{
    class AddUserViewModel : ViewModelBase
    {
        private UserRepository _userRepository;
        private CalculatorContext _context;

        public AddUserViewModel()
        {
            _context = new CalculatorContext();
            _userRepository=new UserRepository(_context);
        }

        private const string _UserLoginPropertyName = "Login";
        private string _UserLogin;

        public string Login
        {
            get { return _UserLogin; }
            set
            {
                _UserLogin = value;
                RaisePropertyChanged(_UserLoginPropertyName);
            }
        }

        private const string _UserPassworPropertyName = "Password";
        private string _UserPasswor;

        public string Password
        {
            get { return _UserPasswor; }
            set
            {
                _UserPasswor = value;
                RaisePropertyChanged(_UserPassworPropertyName);
            }
        }

        private const string _UserNamePropertyName = "Name";
        private string _UserName;

        public string Name
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
                RaisePropertyChanged(_UserNamePropertyName);
            }
        }

        private const string _UserSurnamePropertyName = "Surname";
        private string _UserSurname;

        public string Surname
        {
            get { return _UserSurname; }
            set
            {
                _UserSurname = value;
                RaisePropertyChanged(_UserSurnamePropertyName);
            }
        }

        private RelayCommand _signUpCommand;

        public RelayCommand SignUpCommand
        {
            get
            {
                if (_signUpCommand == null)
                    _signUpCommand = new RelayCommand(ExecuteSignUpCommandAction);
                return _signUpCommand;
            }
        }

        private void ExecuteSignUpCommandAction()
        {
            if (_userRepository.ValidateUserLogin(Login))
            {
                _userRepository.AddUser(Login, Password, Name, Surname);
                MessageBox.Show("Poprawnie dodano usera");
                _context.SaveChanges();
            }
            else
            {
                MessageBox.Show("Login zajety");
            }
        }
    }
}
