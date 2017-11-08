using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BirthdayGreeting2;
using BirthdayGreetingTest.BirthdayEmployees;
using BirthdayGreetingTest.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using NUnit.Framework;

namespace FileExtensionTest
{
    [TestClass]
    public class ReadCsvFile
    {
        private readonly string fileName = "Employees.csv";
        private List<Employee> employee;

        [SetUp]
        public void Init()
        {
            var employeesFile = new EmployeesFile(fileName);
            employee = employeesFile.Read();
        }


        [Test]
        public void Should_ReadFile()
        {
            // SETUP
            
            // RUN
            var csvLines = File.ReadAllLines(fileName);

            // ASSERT
            Check.That(csvLines[0]).IsEqualTo("zaafrani;gabriel;gabriel.zaafrani@gmail.com;1990/09/29");
        }

        [Test]
        public void Should_Extract_One_Employee()
        {
            // SETUP
            Employee employeeEstimate = new Employee("zaafrani","gabriel","gabriel.zaafrani@gmail.com",new DateTime(1990,09,29));
            //RUN

            //ASSERT
            Check.That(employee[0]).IsEqualTo(employeeEstimate);
        }

        [Test]
        public void Should_Extract_Multiples_Employee()
        {
            List<Employee> employeesEstimate = new List<Employee>()
            {
                new Employee("zaafrani","gabriel","gabriel.zaafrani@gmail.com",new DateTime(1990,09,29)),
                new Employee("zaafrani","michael", "michael.zaafrani@gmail.com",new DateTime(1990,09,09))
            };
           
            Check.That(employee.SequenceEqual(employeesEstimate) && employeesEstimate.SequenceEqual(employee))
                .IsTrue();
        }

        

        
        [Test]
        public void Should_Obtains_The_Birthday()
        {
            // SETUP
            IRepository repo = new FileRepo();
           
            BirthdayGreeting birthdayGreeting = new BirthdayGreeting(repo,null);
            var service = birthdayGreeting.InjectEmployeesToSystemForObtainBirthdayList(employee);

            // RUN
           
            var employeeList = service.BirthdayListInformations(29, 09);
          
            // ASSERT
            Check.That(service.Exist(new Employee("zaafrani", "gabriel", "gabriel.zaafrani@gmail.com",
                new DateTime(1990, 09, 29)))).IsTrue();

        }
    }
}
