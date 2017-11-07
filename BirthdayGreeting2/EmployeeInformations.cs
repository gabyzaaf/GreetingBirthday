using System;
using System.Collections.Generic;

namespace BirthdayGreeting2
{
    public class EmployeeInformations
    {
        private string name;
        private string firstname;
        private Email email;
        private DateTime birthday;

        public EmployeeInformations(string name, string firstname, Email email, DateTime birthday)
        {
            this.name = name;
            this.firstname = firstname;
            this.email = email;
            this.birthday = birthday;
        }

        public override bool Equals(object obj)
        {
            var informations = obj as EmployeeInformations;
            return informations != null &&
                   name == informations.name &&
                   firstname == informations.firstname &&
                   EqualityComparer<Email>.Default.Equals(email, informations.email) &&
                   birthday == informations.birthday;
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
    }
}