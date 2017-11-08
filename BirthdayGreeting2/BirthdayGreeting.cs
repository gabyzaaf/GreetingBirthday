using System;
using BirthdayGreetingTest.Repository;
using NUnit.Framework;
using System.Collections.Generic;
using BirthdayGreetingTest.BirthdayCounting;
using BirthdayGreetingTest.BirthdayEmployees;

namespace BirthdayGreeting2
{
    public class BirthdayGreeting
    {
       
        private IRepository repository;
        private ISender sender;

       

        public BirthdayGreeting(IRepository repository, ISender sender)
        {
            this.repository = repository;
            this.sender = sender;
        }

        public void Send(List<EmployeeInformations> employee)
        {
            sender.Send(employee);
        }
       
        public BirthdayEmployeesService InjectEmployeesToSystemForObtainBirthdayList(List<Employee> employees)
        {
            var employeeRepository = this.repository.InjectEmployeesToSystem(employees);
            return new BirthdayEmployeesService(employeeRepository);
        }

        public BirthdayCounter InjectEmplyeesToSystemForObtainCounterList(List<Employee> employees)
        {
            var employeeRepository = this.repository.InjectEmployeesToSystem(employees);
            return new BirthdayCounter(employeeRepository);
        }
    }
}