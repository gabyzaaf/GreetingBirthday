using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayGreeting2
{
    public class EmployeeRepository
    {
        private List<Employee> employees;

        public EmployeeRepository(List<Employee> employees)
        {
            this.employees = employees;
        }


        public EmployeeRepository BirthdayIs(int day, int month)
        {
            return new EmployeeRepository(employees.Where(c => c.IsThisBirthday(day,month) ).ToList());
        }

        public EmployeeRepository BirthdayIsWithEmailValid(int day, int month)
        {
            return new EmployeeRepository(employees.Where(c => c.IsThisBirthday(day, month) && c.EmailIsValid()).ToList());
        }

        public Boolean Contain(Employee employe)
        {
            foreach (var employee in employees)
            {
                if (employee.Equals(employe))
                {
                    return true;
                }
            }
            return false;
        }

        public int EmployeeCount()
        {
            return this.employees.Count;
        }

        public List<Employee> ObtainEmployees()
        {
           return new List<Employee>(employees);
        }
    }
}