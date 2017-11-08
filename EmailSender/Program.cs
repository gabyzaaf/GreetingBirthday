using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BirthdayGreeting2;

namespace EmailSender
{
    class Email
    {
        static void Main(string[] args)
        {
            List<EmployeeInformations> employeeInformations = new List<EmployeeInformations>()
            {
                new EmployeeInformations("Zaafrani","Gabriel",BirthdayGreeting2.Email.Of("gabriel.zaafrani@gmail.com"),new DateTime(2017,09,29))
            };
           
            ISender isender = new EmailSender();
            isender.Send(employeeInformations);

        }
    }
}
