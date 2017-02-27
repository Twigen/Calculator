using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WPF_Calculator.Context;
using WPF_Calculator.Repositories;
using WPF_Calculator.Views;

namespace WPF_Calculator.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private Repositories.UserRepository _userRepository;
        private CalculatorContext _context;
        public LoginViewModel()
        {
            _context = new CalculatorContext();
            _userRepository = new UserRepository(_context);
        }

        private const string _LoginPropertyName = "Login";
        private string _Login;

        public string Login
        {
            get { return _Login; }
            set
            {
                _Login = value;
                RaisePropertyChanged(_LoginPropertyName);
            }
        }

        private const string _PasswordPropertyName = "Password";
        private string _Password;

        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                RaisePropertyChanged(_PasswordPropertyName);
            }
        }

        private RelayCommand _loginCommand;

        public RelayCommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                    _loginCommand = new RelayCommand(ExecuteLoginCommandAction);
                return _loginCommand;
            }
        }

        private void ExecuteLoginCommandAction()
        {
            int id =_userRepository.ValidateUser(Login, Password);
            if (id != 0)
            {
                Entities.User activeUser = _userRepository.GetUserById(id);
                UserService.UserService.AssignLoggedInUser(activeUser);
                MessageBox.Show("Login poprawny");
                new MainWindow().Show();
            }
            else
            {
                MessageBox.Show("Login bledny");
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
            new AddUserWindow().Show();
        }
    }
}
