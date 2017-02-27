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
    public class NumberRepositoryTests
    {
       private  CalculatorContext _context = new CalculatorContext();
        private NumberRepository _repository;
       

        public NumberRepositoryTests()
        {
            _repository = new NumberRepository(_context);
            
        }

        [Test]
        public void ShouldAddToDatabase()
        {
           // arrange
           
            Numbers number = new Numbers();
            number.Number = "10";
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

        [Test]
        public void ShouldReturnNumberListFromDatabase()
        {
            //arrange

            //act
            List<string> listOfNumbers = _repository.GetUserNumbersList(1);

            //assert
            Assert.IsNotEmpty(listOfNumbers);
        }

        [Test]
        public void ShouldAddNumberWithUser()
        {
            //arrange
            Numbers numbers = new Numbers();
            numbers.Number = "test string";
            numbers.UserId = 1;
            //act
            bool result = _repository.AddNumber(numbers);

            //assert
            Assert.IsTrue(result);
            Assert.Greater(numbers.Id,0);
        }
        
    }
}
