using Core;
using Infrastructure.Models;

namespace Infrastructure.Services
{
    public interface IEmployeeService
    {
        Task<Response<IEnumerable<EmployeeDto>>> GetEmployeesAsync();
        Task<Response<EmployeeDto>> GetEmployeeAsync(int id);
        Task<Response<IEnumerable<EmployeeDto>>> GetEmployeesByFirstNameAsync(string firstName);
        Task<Response<IEnumerable<EmployeeDto>>> GetEmployeesByMiddleNameAsync(string middleName);
        Task<Response<IEnumerable<EmployeeDto>>> GetEmployeesByLastNameAsync(string LastName);
        Response<EmployeeDto> UpdateEmployee(EmployeeDto employeeDto);
        Response<EmployeeDto> DeleteEmployee(int id);
        Response<EmployeeDto> CreateEmployee(EmployeeDto employeeDto);
    }
}
