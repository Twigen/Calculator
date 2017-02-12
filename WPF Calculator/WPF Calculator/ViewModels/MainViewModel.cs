using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WPF_Calculator.Model;

namespace WPF_Calculator.ViewModels
{
    class MainViewModel :ViewModelBase
    {
        private string _operation;
        private bool _firstTime = false;
        private Model.Operations _operations;

        private const string _ResultPropertyName = "ResultTB";
        private string _Result;

        public MainViewModel()
        {
            _operations=new Operations();
            
        }

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
        private RelayCommand _oneButtonCommand;

        public RelayCommand OneButtonCommand
        {
            get
            {
                if (_oneButtonCommand == null)
                    _oneButtonCommand = new RelayCommand(ExecuteOneButtonCommandAction);
                return _oneButtonCommand;
            }
        }

        private void ExecuteOneButtonCommandAction()
        {
            MainTB += "1";
        }

        private RelayCommand _twoButtonCommand;

        public RelayCommand TwoButtonCommand
        {
            get
            {
                if (_twoButtonCommand == null)
                    _twoButtonCommand = new RelayCommand(ExecuteTwoButtonCommandAction);
                return _twoButtonCommand;
            }
        }

        private void ExecuteTwoButtonCommandAction()
        {
            MainTB += "2";
        }

        private RelayCommand _threeButtonCommand;

        public RelayCommand ThreeButtonCommand
        {
            get
            {
                if (_threeButtonCommand == null)
                    _threeButtonCommand = new RelayCommand(ExecuteThreeButtonCommandAction);
                return _threeButtonCommand;
            }
        }

        private void ExecuteThreeButtonCommandAction()
        {
            MainTB += "3";
        }

        private RelayCommand _fourButtonCommand;

        public RelayCommand FourButtonCommand
        {
            get
            {
                if (_fourButtonCommand == null)
                    _fourButtonCommand = new RelayCommand(ExecuteFourButtonCommandAction);
                return _fourButtonCommand;
            }
        }

        private void ExecuteFourButtonCommandAction()
        {
            MainTB += "4";
        }

        private RelayCommand _fiveButtonCommand;

        public RelayCommand FiveButtonCommand
        {
            get
            {
                if (_fiveButtonCommand == null)
                    _fiveButtonCommand = new RelayCommand(ExecuteFiveButtonCommandAction);
                return _fiveButtonCommand;
            }
        }

        private void ExecuteFiveButtonCommandAction()
        {
            MainTB += "5";
        }

        private RelayCommand _sixButtonCommand;

        public RelayCommand SixButtonCommand
        {
            get
            {
                if (_sixButtonCommand == null)
                    _sixButtonCommand = new RelayCommand(ExecuteSixButtonCommandAction);
                return _sixButtonCommand;
            }
        }

        private void ExecuteSixButtonCommandAction()
        {
            MainTB += "6";
        }

        private RelayCommand _sevenButtonCommand;

        public RelayCommand SevenButtonCommand
        {
            get
            {
                if (_sevenButtonCommand == null)
                    _sevenButtonCommand = new RelayCommand(ExecuteSevenButtonCommandAction);
                return _sevenButtonCommand;
            }
        }

        private void ExecuteSevenButtonCommandAction()
        {
            MainTB += "7";
        }

        private RelayCommand _eightButtonCommand;

        public RelayCommand EightButtonCommand
        {
            get
            {
                if (_eightButtonCommand == null)
                    _eightButtonCommand = new RelayCommand(ExecuteEightButtonCommandAction);
                return _eightButtonCommand;
            }
        }

        private void ExecuteEightButtonCommandAction()
        {
            MainTB += "8";
        }

        private RelayCommand _nineButtonCommand;

        public RelayCommand NineButtonCommand
        {
            get
            {
                if (_nineButtonCommand == null)
                    _nineButtonCommand = new RelayCommand(ExecuteNineButtonCommandAction);
                return _nineButtonCommand;
            }
        }

        private void ExecuteNineButtonCommandAction()
        {
            MainTB += "9";
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
    }
}
