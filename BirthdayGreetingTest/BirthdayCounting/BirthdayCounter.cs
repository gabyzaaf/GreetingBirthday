using System.Collections.Generic;
using BirthdayGreeting2;

namespace BirthdayGreetingTest.BirthdayCounting
{
    internal class BirthdayCounter
    {
        
        private EmployeeRepository employeeRepo;

        public BirthdayCounter(EmployeeRepository employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }

        public int IsBirthday(int day, int month)
        {
            return employeeRepo.BirthdayIs(day, month).EmployeeCount();
        }
    }
}