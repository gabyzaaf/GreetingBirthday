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