using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using WPF_Calculator.Context;
using WPF_Calculator.Entities;
using WPF_Calculator.Repositories;

namespace CalculatorTests
{
    [TestFixture]
    public class ConnectionTest
    {
       private  CalculatorContext _context = new CalculatorContext();
        private NumberRepository _repository;

        public ConnectionTest()
        {
            _repository = new NumberRepository(_context);
        }

        [Test]
        public void ShouldAddToDatabase()
        {
           // arrange
           
            Numbers number = new Numbers();
            number.Number = 10;
            // act
            bool result = _repository.AddNumber(number);
            // assert
            Assert.IsTrue(result);
        }
        [Test]
        public void ShouldReturnNumbersFromDatabase()
        {
            //arrange
            //act 
            List<Numbers> AllNumbers = _repository.GetAll();
            //assert
            Assert.IsNotEmpty(AllNumbers);
        }
    }
}
