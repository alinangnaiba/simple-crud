using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets all employees
        /// </summary>
        /// <returns>A list of Employees.</returns>
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetEmployeesAsync();
            return RequestResponse(response);
        }

        /// <summary>
        /// Gets an employee by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Employee</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var response = await _service.GetEmployeeAsync(id);
            return RequestResponse(response);
        }


        /// <summary>
        /// Get Employees with matching first name
        /// </summary>
        /// <param name="firstName"></param>
        /// <returns>Employee</returns>
        [HttpGet("firstname/{firstName}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetEmployeeByFirstName(string firstName)
        {
            var response = await _service.GetEmployeesByFirstNameAsync(firstName);
            return RequestResponse(response);
        }

        /// <summary>
        /// Get Employees with matching middle name
        /// </summary>
        /// <param name="middleName"></param>
        /// <returns></returns>
        [HttpGet("middlename/{middleName}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetEmployeeByMiddleName(string middleName)
        {
            var response = await _service.GetEmployeesByMiddleNameAsync(middleName);
            return RequestResponse(response);
        }

        /// <summary>
        /// Get Employees with matching last name
        /// </summary>
        /// <param name="lastName"></param>
        /// <returns></returns>
        [HttpGet("lastname/{lastName}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetEmployeeByLaststName(string lastName)
        {
            var response = await _service.GetEmployeesByLastNameAsync(lastName);
            return RequestResponse(response);
        }

        /// <summary>
        /// Create an Employee
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDto dto)
        {
            var response = await Task.FromResult(_service.CreateEmployee(dto));
            return RequestResponse(response);
        }

        /// <summary>
        /// Delete Employee by employee Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var response = await Task.FromResult(_service.DeleteEmployee(id));
            return RequestResponse(response);
        }

        /// <summary>
        /// Update Employee
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPatch]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeDto dto)
        {
            var response = await Task.FromResult(_service.UpdateEmployee(dto));
            return RequestResponse(response);
        }

        private IActionResult RequestResponse<T>(Core.Response<T> response)
        {
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
