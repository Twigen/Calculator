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
                MainViewModel.Id = id;
                MessageBox.Show("Login poprawny");
                new MainWindow().Show();
            }
            else
            {
                MessageBox.Show("Login bledny");
            }
            
            
        }
    }
}
