using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthdayGreeting2;
using BirthdayGreetingTest.Repository;
using NFluent;
using NSubstitute;
using NUnit.Framework;

namespace BirthdayGreetingTest.BirthdayEmployees
{
    class BirthdayEmployeesTest
    {

        [Test]
        public void Should_Obtains_The_Employee_List_For_The_Birhday()
        {
            // SETUP
            var repo = NSubstitute.Substitute.For<IRepository>();
            var greeting = new BirthdayGreeting(repo,null);
            
            // RUN
            repo.ObtainsCandidateList().Returns(new List<Employee>()
            {
                new Employee("zaafrani","Gabriel","gz@hotmail.com",new DateTime(1990,09,09)),
                new Employee("zaafrani","Michael","mz@hotmail.com",new DateTime(1991,09,29))
            });
            var employeeRepository = greeting.ObtainsCandidateList();
            var birthdayEmployees = new BirthdayEmployeesService(employeeRepository);
            // ARRANGE
            EmployeeRepository employeeList =  birthdayEmployees.BirthdayList(29,09);
            Check.That(employeeList.Contain(new Employee("zaafrani", "Michael", "mz@hotmail.com", new DateTime(1991, 09, 29)))).IsTrue();
        }

        [Test]
        public void Should_Return_Employee_List_For_The_Birthday()
        {
            // SETUP
            var repo = NSubstitute.Substitute.For<IRepository>();
            var greeting = new BirthdayGreeting(repo, null);
            var employeesEstimate = new List<Employee>()
            {
                new Employee("zaafrani","Gabriel","gz@hotmail.com",new DateTime(1990,09,09))
            };
            // RUN
            repo.ObtainsCandidateList().Returns(new List<Employee>()
            {
                new Employee("zaafrani","Gabriel","gz@hotmail.com",new DateTime(1990,09,09)),
                new Employee("zaafrani","Michael","mz@hotmail.com",new DateTime(1991,09,29))
            });
            var employeeRepository = greeting.ObtainsCandidateList();
            var birthdayEmployees = new BirthdayEmployeesService(employeeRepository);
            // ARRANGE
            EmployeeRepository employeeList = birthdayEmployees.BirthdayList(09, 09);
            List<Employee> employees =  employeeList.ObtainEmployees();
            Check.That(employees.SequenceEqual(employeesEstimate) && employeesEstimate.SequenceEqual(employees)).IsTrue();
        }
    }
}
