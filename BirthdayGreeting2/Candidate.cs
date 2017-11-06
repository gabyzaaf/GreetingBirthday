using System;

namespace BirthdayGreeting2
{
    public class Candidate
    {
        private string name;
        private string firstname;
        private Email email;
        private DateTime birthday;

        public Candidate(string name, string firstname, string email, DateTime birthday)
        {
            this.name = name;
            this.firstname = firstname;
            this.email = new Email(email);
            this.birthday = birthday;
        }

        public bool IsThisBirthday(int day, int month)
        {
            return birthday.Day == day && birthday.Month == month;
        }
    }
}