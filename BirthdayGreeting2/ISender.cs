using System.Collections.Generic;

namespace BirthdayGreeting2
{
    public interface ISender
    {
        void Send(List<EmployeeInformations> employee);
    }
}