using System;
using System.Collections.Generic;
using System.IO;
using BirthdayGreeting2;

namespace FileExtensionTest
{
    public class EmployeesFile
    {
        private string _file;

        public EmployeesFile(string file)
        {
            this._file = file;
        }

        public  List<Employee> Read()
        {
            List<Employee> employees = new List<Employee>();

            var csvLines = File.ReadAllLines(_file);
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