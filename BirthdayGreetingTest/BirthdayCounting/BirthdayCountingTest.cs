using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthdayGreeting2;
using NFluent;
using NUnit.Framework;

namespace BirthdayGreetingTest.BirthdayCounting
{
    class BirthdayCountingTest
    {
        [Test]
        public void Should_Counting_The_Birthday_From_Specific_Day()
        {
            // SETUP
            var employees = new List<Employee>()
            {
                new Employee("zaafrani", "Gabriel", "gabriel.zaafrani@tuto.fr", new DateTime(1990, 09, 29)),
                new Employee("zaafrani", "Michael", "Michael.zaafrani@tuto.fr", new DateTime(1975, 12, 02)),
                new Employee("zaafrani", "Salomon", "salomon.zaafrani@tuto.fr", new DateTime(1956, 09, 19))
            };
            var employeeRepo = new EmployeeRepository(employees);
            var brithdayCounter = new BirthdayCounter(employeeRepo);

            // RUN
            int numberEmployeesBirthday = brithdayCounter.IsBirthday(29, 09);
            // ASSERT
            Check.That(numberEmployeesBirthday).IsEqualTo(1);

        }
        
    }
}
