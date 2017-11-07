using System;
using System.IO;
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
            var employee = ReadEmployeeFile(file);
            //ASSERT
            Check.That(employee).IsEqualTo(employeeEstimate);
        }

        private Employee ReadEmployeeFile(string file)
        {
            file = "Employees.csv";
            var csvLines = File.ReadAllLines(file);

            var lineSplited = csvLines[0].Split(';');
            string name = lineSplited[0];
            string firstname = lineSplited[1];
            string email = lineSplited[2];

            var dateSplited = lineSplited[3].Split('/');
            int year = int.Parse(dateSplited[0]);
            int month = int.Parse(dateSplited[1]);
            int day = int.Parse(dateSplited[2]);

           

            Employee employee = new Employee(name, firstname, email, new DateTime(year, month, day));
            return employee;
        }
    }
}
