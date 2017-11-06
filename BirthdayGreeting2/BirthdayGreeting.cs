using System;

namespace BirthdayGreeting2
{
    public class BirthdayGreeting
    {
        private Employee employee;
        private ISender runSender;

        public BirthdayGreeting(Employee employee, ISender runSender)
        {
            this.employee = employee;
            this.runSender = runSender;
        }

       

        public void Send(Employee employee)
        {
            runSender.Send(employee);
        }
    }
}