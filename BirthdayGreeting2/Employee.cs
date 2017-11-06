using System;

namespace BirthdayGreeting2
{
    public class Employee
    {
        private string _name;
        private string _firstname;
        private string _email;
        private DateTime _born;

        public Employee(string name, string firstname, string email, DateTime born)
        {
            this._name = name;
            this._firstname = firstname;
            this._email = email;
            this._born = born;
        }
    }
}