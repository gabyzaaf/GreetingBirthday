using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthdayGreeting2;
using FileExtensionTest;

namespace FileInjector
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeesFile = new EmployeesFile("Employees.csv");
            var employee = employeesFile.Read();
            var birthdayGreeting = new BirthdayGreeting(new FileRepo(), null);

            var birthdayEmployeesService = birthdayGreeting.InjectEmployeesToSystemForObtainBirthdayList(employee);
            var liste = birthdayEmployeesService.BirthdayList(29, 09);

            liste.ForEach(c => Console.WriteLine(c));
        }
    }
}
