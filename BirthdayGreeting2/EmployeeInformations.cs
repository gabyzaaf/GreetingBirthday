using System;
using System.Collections.Generic;

namespace BirthdayGreeting2
{
    public class EmployeeInformations
    {
        public string Name { get; }
        public string Firstname { get; }
        public Email Email{get ;}
        public DateTime Birthday { get; }

        public EmployeeInformations(string name, string firstname, Email email, DateTime birthday)
        {
            this.Name = name;
            this.Firstname = firstname;
            this.Email = email;
            this.Birthday = birthday;
        }

        public override bool Equals(object obj)
        {
            var informations = obj as EmployeeInformations;
            return informations != null &&
                   Name == informations.Name &&
                   Firstname == informations.Firstname &&
                   EqualityComparer<Email>.Default.Equals(Email, informations.Email) &&
                   Birthday == informations.Birthday;
        }

        public override int GetHashCode()
        {
            var hashCode = -642255205;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Firstname);
            hashCode = hashCode * -1521134295 + EqualityComparer<Email>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + Birthday.GetHashCode();
            return hashCode;
        }
    }
}