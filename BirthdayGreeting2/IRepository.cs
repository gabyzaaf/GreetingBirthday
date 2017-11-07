using System.Collections.Generic;
using BirthdayGreeting2;
using NUnit.Framework;

namespace BirthdayGreetingTest.Repository
{
    public interface IRepository
    {
        EmployeeRepository InjectEmployeesToSystem(List<Employee> employees);
    }
}