using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using WPF_Calculator.Context;
using WPF_Calculator.Entities;
using WPF_Calculator.Repositories;


namespace WPF_Calculator.ViewModels
{
    class HistoricalViewModel :ViewModelBase
    {
        private NumberRepository _numberRepository;
        private List<string> numbersList;
        private UserService.UserService _userService;
        private readonly CalculatorContext _context;
        private int _id;
        

        public HistoricalViewModel()
        {
            
            _id = UserService.UserService.LoggedInUserId;
            _context = new CalculatorContext();
            _numberRepository = new NumberRepository(_context);
            _numbersList = new ObservableCollection<string>();
            numbersList = new List<string>();
            numbersList = _numberRepository.GetUserNumbersList(_id);
            numbersList.ToList().ForEach(_numbersList.Add);
            
        }

        

        private const string _numbersListPropertyName = "NumbersList";
        private ObservableCollection<string> _numbersList;

        public ObservableCollection<string> NumbersList
        {
            get { return _numbersList; }
            set
            {
                _numbersList = value;
                RaisePropertyChanged(_numbersListPropertyName);
            }
        }
    }
}
