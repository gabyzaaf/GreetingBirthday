using System;
using System.Collections.Generic;
using BirthdayGreeting2;
using NUnit.Framework;

namespace BirthdayGreetingTest.BirthdayEmployees
{
    public class BirthdayEmployeesService
    {
        private EmployeeRepository employeeRepository;

        public BirthdayEmployeesService(EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public List<Employee> BirthdayList(int day, int month)
        {
            this.employeeRepository = employeeRepository.BirthdayIsWithEmailValid(day, month);
            return new List<Employee>(this.employeeRepository.ObtainEmployees());
        }

        public Boolean Exist(Employee employe)
        {
            var employees = this.employeeRepository.ObtainEmployees();
            foreach (var employee in employees)
            {
                if (employee.Equals(employe))
                {
                    return true;
                }
            }
            return false;
        }



    }
}