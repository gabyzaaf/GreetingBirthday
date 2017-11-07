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

            var employees = new List<Employee>()
            {
                new Employee("zaafrani", "Gabriel", "gz@hotmail.com", new DateTime(1990, 09, 09)),
                new Employee("zaafrani", "Michael", "mz@hotmail.com", new DateTime(1991, 09, 29))
            };
            // RUN

            repo.InjectEmployeesToSystem(employees).Returns( new EmployeeRepository(employees));


            var birthdayEmployees = greeting.InjectEmployeesToSystemForObtainBirthdayList(employees);
            
            // ARRANGE
            var employeeList =  birthdayEmployees.BirthdayList(29,09);
            Check.That(birthdayEmployees.Exist(new Employee("zaafrani", "Michael", "mz@hotmail.com", new DateTime(1991, 09, 29)))).IsTrue();
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

            var employes = new List<Employee>()
            {
                new Employee("zaafrani", "Gabriel", "gz@hotmail.com", new DateTime(1990, 09, 09)),
                new Employee("zaafrani", "Michael", "mz@hotmail.com", new DateTime(1991, 09, 29))
            };

            // RUN
            repo.InjectEmployeesToSystem(employes).Returns(new EmployeeRepository(employes));
            var birthdayEmployees = greeting.InjectEmployeesToSystemForObtainBirthdayList(employes);
            
            // ARRANGE
            var employeeList = birthdayEmployees.BirthdayList(09, 09);
            
            Check.That(employeeList.SequenceEqual(employeesEstimate) && employeesEstimate.SequenceEqual(employeeList)).IsTrue();
        }

        [Test]
        public void Should_Obtains_The_Employee_Informations()
        {
            // SETUP
            var repo = NSubstitute.Substitute.For<IRepository>();
            var greeting = new BirthdayGreeting(repo, null);
            var employeesInformationsEstimate = new List<EmployeeInformations>()
            {
                new EmployeeInformations("zaafrani","Gabriel",new Email("gz@hotmail.com"),new DateTime(1990,09,09))
            };

            var employes = new List<Employee>()
            {
                new Employee("zaafrani", "Gabriel", "gz@hotmail.com", new DateTime(1990, 09, 09)),
                new Employee("zaafrani", "Michael", "mz@hotmail.com", new DateTime(1991, 09, 29))
            };

            // RUN
            repo.InjectEmployeesToSystem(employes).Returns(new EmployeeRepository(employes));
            var birthdayEmployees = greeting.InjectEmployeesToSystemForObtainBirthdayList(employes);

            // ARRANGE
            List<EmployeeInformations> employeesInformation = birthdayEmployees.BirthdayListInformations(09, 09);
            Check.That(employeesInformation.SequenceEqual(employeesInformationsEstimate) &&
                       employeesInformationsEstimate.SequenceEqual(employeesInformation)).IsTrue();
        }
    }
}
