using System;
using System.Collections.Generic;

namespace BirthdayGreeting2
{
    public class Employee
    {
        private string name;
        private string firstname;
        private Email email;
        private DateTime birthday;

        public Employee(string name, string firstname, string email, DateTime birthday)
        {
            this.name = name;
            this.firstname = firstname;
            this.email = new Email(email);
            this.birthday = birthday;
        }

        public override bool Equals(object obj)
        {
            var employee = obj as Employee;
            return employee != null &&
                   name == employee.name &&
                   firstname == employee.firstname &&
                   EqualityComparer<Email>.Default.Equals(email, employee.email) &&
                   birthday == employee.birthday;
        }

        public override int GetHashCode()
        {
            var hashCode = -642255205;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(firstname);
            hashCode = hashCode * -1521134295 + EqualityComparer<Email>.Default.GetHashCode(email);
            hashCode = hashCode * -1521134295 + birthday.GetHashCode();
            return hashCode;
        }

        public bool IsThisBirthday(int day, int month)
        {
            return birthday.Day == day && birthday.Month == month;
        }


    }
}