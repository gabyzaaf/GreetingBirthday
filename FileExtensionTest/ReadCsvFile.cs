using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BirthdayGreeting2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using NUnit.Framework;

namespace FileExtensionTest
{
    [TestClass]
    public class ReadCsvFile
    {
        private readonly string fileName = "Employees.csv";

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
            string file = null;
            file = "Employees.csv";
            var employee = ReadEmployeesFile(file);
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
            var file = "Employees.csv";
            List<Employee> employees = ReadEmployeesFile(file);
            Check.That(employees.SequenceEqual(employeesEstimate) && employeesEstimate.SequenceEqual(employees))
                .IsTrue();
        }

        

        private List<Employee> ReadEmployeesFile(string file)
        {
            List<Employee> employees = new List<Employee>();

            var csvLines = File.ReadAllLines(file);
            foreach (var line in csvLines)
            {
                var lineSplited = line.Split(';');
                string name = lineSplited[0];
                string firstname = lineSplited[1];
                string email = lineSplited[2];

                var dateSplited = lineSplited[3].Split('/');
                int year = int.Parse(dateSplited[0]);
                int month = int.Parse(dateSplited[1]);
                int day = int.Parse(dateSplited[2]);
                employees.Add(new Employee(name, firstname, email, new DateTime(year, month, day)));
            }
            return employees;
        }
    }
}
