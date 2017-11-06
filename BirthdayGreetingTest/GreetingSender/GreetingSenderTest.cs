using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace BirthdayGreeting2
{
    public class GreetingSenderTest
    {
        private List<Employee> employees;
        [SetUp]
        public void Init()
        {
            employees = new List<Employee>()
            {
                new Employee("Zaafrani", "Gabriel", "gabriel.zafrani@email.com", new DateTime(1990, 09, 20))
            };
        }

        [Test]
        public void Should_Verify_The_Mock_Is_Called_With_GreetingBirthday()
        {
            // SETUP
            
            var runSender = NSubstitute.Substitute.For<ISender>();
            var bithdayGreeting = new BirthdayGreeting(null,runSender);
            
            // RUN
            bithdayGreeting.Send(employees);
            // ARRANGE
            runSender.Received().Send(employees);
        }


        [Test]
        public void Should_Verify_The_Mock_With_Employee()
        {
            // SETUP
            
            var runSender = NSubstitute.Substitute.For<ISender>();
            var bithdayGreeting = new BirthdayGreeting(null, runSender);

            // RUN
            bithdayGreeting.Send(employees);
            // ARRANGE
            runSender.Received().Send(employees);
        }

        
    }
}
