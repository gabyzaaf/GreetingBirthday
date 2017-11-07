using BirthdayGreeting2;

namespace BirthdayGreetingTest.BirthdayEmployees
{
    public class BirthdayEmployeesService
    {
        private EmployeeRepository employeeRepository;

        public BirthdayEmployeesService(EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public EmployeeRepository BirthdayList(int day, int month)
        {
            EmployeeRepository employeeRepositorytmp = employeeRepository.BirthdayIsWithEmailValid(day, month);
            return employeeRepositorytmp;
        }
    }
}