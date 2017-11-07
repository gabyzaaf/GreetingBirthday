using System.Collections.Generic;
using BirthdayGreeting2;
using BirthdayGreetingTest.Repository;

namespace FileExtensionTest
{
    public class FileRepo : IRepository
    {
        public EmployeeRepository InjectEmployeesToSystem(List<Employee> employees)
        {
            return new EmployeeRepository(employees);
        }
    }
}