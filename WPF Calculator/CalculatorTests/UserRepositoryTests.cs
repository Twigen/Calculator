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
    class UserRepositoryTests
    {
        private UserRepository _userRepository;
        private CalculatorContext _context = new CalculatorContext();

        public UserRepositoryTests()
        {
            _userRepository = new UserRepository(_context);
        }
        [Test]
        public void ShouldLoginToDatabase()
        {
            // arrange
            User testUser = new User();
            testUser.Login = "norbert";
            testUser.Password = "ww";
            int Id;
            // act
            Id = _userRepository.ValidateUser(testUser.Login, testUser.Password);
            // assert
            Assert.AreEqual(Id, 1);
        }

        [Test]
        public void ShouldReturnUser()
        {
            //arrange 
            int Id = 1;
            //act
           User user = _userRepository.GetUserById(Id);
            //assert
            Assert.IsNotNull(user);
        }
        [Test]
        public void ShouldNotLoginToDatabase()
        {
            // arrange
            User testUser = new User();
            testUser.Login = "norbert1";
            testUser.Password = "ww1";
            int Id;
            // act
            Id = _userRepository.ValidateUser(testUser.Login, testUser.Password);
            // assert
            Assert.AreEqual(Id, 0);
        }
    }
}
