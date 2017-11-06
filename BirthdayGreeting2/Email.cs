using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BirthdayGreeting2
{
    public class Email
    {
        private readonly string email;

        public Email(string email)
        {
            this.email = email;
        }

        public override bool Equals(object obj)
        {
            var email = obj as Email;
            return email != null &&
                   this.email == email.email;
        }

        public override int GetHashCode()
        {
            return 848330207 + EqualityComparer<string>.Default.GetHashCode(email);
        }

        public bool IsValid()
        {
            var regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            return regex.IsMatch(this.email);
        }

        public override string ToString()
        {
            return this.email;
        }


    }
}