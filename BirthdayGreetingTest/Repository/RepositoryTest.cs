using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthdayGreeting2;
using NFluent;
using NSubstitute;
using NUnit.Framework;

namespace BirthdayGreetingTest.Repository
{
    class RepositoryTest
    {
       

        [Test]
        public void Should_Get_Candidate_List_From_Repository()
        {
            // SETUP
            var repository = NSubstitute.Substitute.For<IRepository>();
            var sender = NSubstitute.Substitute.For<ISender>();
            // RUN
            var birthdayGreeting = new BirthdayGreeting(repository, sender);
            birthdayGreeting.InjectEmployeesToSystem(null);
            // ARRANGE
            repository.Received().InjectEmployeesToSystem(null);

        }

        [Test]
        public void Should_Obtains_The_Candidates_List_From_Specific_Birthday()
        {
            // SETUP
            var repository = NSubstitute.Substitute.For<IRepository>();
            var sender = NSubstitute.Substitute.For<ISender>();
            int day = 29;
            int month = 09;
            var employeesValues = new List<Employee>()
            {
                new Employee("zaafrani", "Gabriel", "gabriel.zaafrani@tuto.fr", new DateTime(1990, 09, 29)),
                new Employee("zaafrani", "Michael", "Michael.zaafrani@tuto.fr", new DateTime(1975, 12, 02)),
                new Employee("zaafrani", "Salomon", "salomon.zaafrani@tuto.fr", new DateTime(1956, 09, 19))

            };

            // RUN
            repository.InjectEmployeesToSystem(employeesValues).Returns(new EmployeeRepository(employeesValues));
            var birthdayGreeting = new BirthdayGreeting(repository, sender);
            

           
           
            var candidateRepo = birthdayGreeting.InjectEmployeesToSystem(employeesValues);
            
            // ARRANGE
            var birthdayEmployees = candidateRepo.BirthdayIs(day, month);
            Check.That(birthdayEmployees.Contain(new Employee("zaafrani", "Gabriel", "gabriel.zaafrani@tuto.fr", new DateTime(1990, 09, 29)))).IsTrue();

        }
    }
}
