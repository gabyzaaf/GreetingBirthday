using System;

namespace BirthdayGreeting2
{
    public class Candidate
    {
        private string name;
        private string firstname;
        private string email;
        private DateTime birthday;

        public Candidate(string name, string firstname, string email, DateTime birthday)
        {
            this.name = name;
            this.firstname = firstname;
            this.email = email;
            this.birthday = birthday;
        }
    }
}