using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WPF_Calculator.Context;
using WPF_Calculator.Entities;
using WPF_Calculator.Model;
using WPF_Calculator.Repositories;
using WPF_Calculator.UserService;

namespace WPF_Calculator.ViewModels
{
    class MainViewModel :ViewModelBase
    {
        private Repositories.NumberRepository _repository;
        private string _saveResult;
        private string _operation;
        private bool _firstTime = false;
        private Model.Operations _operations;
        private UserService.UserService _userService;
        private const string _ResultPropertyName = "ResultTB";
        private string _Result;
        public static int Id;

        public MainViewModel()
        {
            CalculatorContext context= new CalculatorContext();
            _operations=new Operations();
            _repository = new NumberRepository(context);
            _userService = new UserService.UserService(context);
            User user = _userService.GetCurrentlyLogedUser(Id);
            MessageBox.Show("Witaj" + user.Name + user.Surname);
        }

        public User User => _userService.GetCurrentlyLogedUser(Id);

        public string ResultTB
        {
            get { return _Result; }
            set
            {
                _Result = value;
                RaisePropertyChanged(_ResultPropertyName);
            }
        }

        private const string _OperationTBPropertyName = "OperationTB";
        private string _OperationTB;

        public string OperationTB
        {
            get { return _OperationTB; }
            set
            {
                _OperationTB = value;
                RaisePropertyChanged(_OperationTBPropertyName);
            }
        }

        private const string _MainTbPropertyName = "MainTB";
        private string _MainTb;

        public string MainTB
        {
            get { return _MainTb; }
            set
            {
                _MainTb = value;
                RaisePropertyChanged(_MainTbPropertyName);
            }
        }

        private RelayCommand<string> _digitCommand;

        public RelayCommand<string> DigitCommand
        {
            get
            {
                if (_digitCommand == null)
                    _digitCommand = new RelayCommand<string>(ExecuteDigitCommandAction);
                return _digitCommand;
            }
        }

        private void ExecuteDigitCommandAction(string digit)
        {
            
        }

        private void ExecuteNineButtonCommandAction()
        {
            MainTB += "9";
            _saveResult += "9";
        }

        private RelayCommand _zeroButtonCommand;

        public RelayCommand ZeroButtonCommand
        {
            get
            {
                if (_zeroButtonCommand == null)
                    _zeroButtonCommand = new RelayCommand(ExecuteZeroButtonCommandAction);
                return _zeroButtonCommand;
            }
        }

        private void ExecuteZeroButtonCommandAction()
        {
            MainTB += "0";
            _saveResult += "0";
        }

        private RelayCommand _addCommand;

        public RelayCommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                    _addCommand = new RelayCommand(ExecuteAddCommandAction);
                return _addCommand;
            }
        }

        private void ExecuteAddCommandAction()
        {
            OperationTB = "+";
            _saveResult += " + ";
            if (_firstTime && MainTB != "")
            {
                ResultTB=_operations.DoOperation(MainTB, ResultTB, _operation);
            }
            else
            {
                ResultTB = MainTB;
            }
            MainTB = "";
            _operation = "+";
            _firstTime = true;
        }

        private RelayCommand _subtractCommand;

        public RelayCommand SubtractCommand
        {
            get
            {
                if (_subtractCommand == null)
                    _subtractCommand = new RelayCommand(ExecuteSubtractCommandAction);
                return _subtractCommand;
            }
        }

        private void ExecuteSubtractCommandAction()
        {
            OperationTB = "-";
            _saveResult += " - ";
            if (_firstTime && MainTB != "")
            {
                ResultTB = _operations.DoOperation(MainTB, ResultTB, _operation);
            }
            else
            {
                ResultTB = MainTB;
            }
            MainTB = "";
            _operation = "-";
            _firstTime = true;
        }

        private RelayCommand _multiplyCommand;

        public RelayCommand MultiplyCommand
        {
            get
            {
                if (_multiplyCommand == null)
                    _multiplyCommand = new RelayCommand(ExecuteMultiplyCommandAction);
                return _multiplyCommand;
            }
        }

        private void ExecuteMultiplyCommandAction()
        {
            OperationTB = "*";
            _saveResult += " * ";
            if (_firstTime && MainTB != "")
            {
                ResultTB = _operations.DoOperation(MainTB, ResultTB, _operation);
            }
            else
            {
                ResultTB = MainTB;
            }
            MainTB = "";
            _operation = "*";
            _firstTime = true;
        }

        private RelayCommand _divideCommand;

        public RelayCommand DivideCommand
        {
            get
            {
                if (_divideCommand == null)
                    _divideCommand = new RelayCommand(ExecuteDivideCommandAction);
                return _divideCommand;
            }
        }

        private void ExecuteDivideCommandAction()
        {
            OperationTB = "/";
            _saveResult += " / ";
            if (_firstTime && MainTB!="")
            {
                ResultTB = _operations.DoOperation(MainTB, ResultTB, _operation);
            }
            else
            {
                ResultTB = MainTB;
            }
            MainTB = "";
            _operation = "/";
            _firstTime = true;
        }

        private RelayCommand _equalsCommand;

        public RelayCommand EqualsCommand
        {
            get
            {
                if (_equalsCommand == null)
                    _equalsCommand = new RelayCommand(ExecuteEqualsCommandAction);
                return _equalsCommand;
            }
        }

        private void ExecuteEqualsCommandAction()
        {
            ResultTB = _operations.DoOperation(MainTB, ResultTB, _operation);
            MainTB = "";
            _saveResult += " = " + ResultTB;
            Numbers number= new Numbers();
            number.Number = _saveResult;
            _repository.AddNumber(number);
        }
    }
}
