using System;
using NSubstitute;
using NUnit.Framework;

namespace BirthdayGreeting2
{
    public class GreetingSenderTest
    {
        [Test]
        public void Should_Verify_The_Mock_Is_Called()
        {
            // SETUP

            // RUN
            var runSender = NSubstitute.Substitute.For<ISender>();
            // ARANGE
            runSender.Received().Send();
            
        }

        [Test]
        public void Should_Verify_The_Mock_Is_Called_With_GreetingBirthday()
        {
            // SETUP
            var employee = new Employee("Zaafrani","Gabriel","gabriel.zafrani@email.com",new DateTime(1990,09,20));
            var runSender = NSubstitute.Substitute.For<ISender>();
            var bithdayGreeting = new BirthdayGreeting(employee,runSender);
            
            // RUN
            bithdayGreeting.Send();
            // ARRANGE
            runSender.Received().Send();
        }
    }
}
