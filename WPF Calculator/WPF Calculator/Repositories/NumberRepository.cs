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
    public class NumberRepository
    {
        private readonly CalculatorContext _context;
        private readonly DbSet<Numbers> _numbers;

        public NumberRepository(CalculatorContext context)
        {
            
            _context = context;
            _numbers = _context.Numbers;
        }

        public bool AddNumber(Numbers number)
        {
            _numbers.Add(number);
            int changes = _context.SaveChanges();
            return changes > 0;
        }

        public List<Numbers> GetAll()
        {
            return _numbers.ToList();
        }
        public List<string> GetUserNumbersList(int userId)
        {
            List<Numbers> numberList = new List<Numbers>();
            numberList = _numbers.Where(x => x.UserId == userId).ToList();
            return numberList.Select(c => c.Number).ToList();
        }
    }
}
