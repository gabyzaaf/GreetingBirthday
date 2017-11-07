using System;
using BirthdayGreetingTest.Repository;
using NUnit.Framework;
using System.Collections.Generic;

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

        public void Send(List<Employee> employee)
        {
            sender.Send(employee);
        }

        public EmployeeRepository InjectEmployeesToSystem(List<Employee> employees)
        {
            var candidateRepository = this.repository.InjectEmployeesToSystem(employees);
            return candidateRepository;
        }
    }
}