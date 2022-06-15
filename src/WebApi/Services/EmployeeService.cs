using AutoMapper;
using Core;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Models;
using Infrastructure.Services;

namespace WebApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IRepository<Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Response<EmployeeDto> CreateEmployee(EmployeeDto employeeDto)
        {
            var employeeEntity = _mapper.Map<Employee>(employeeDto);
            _repository.Add(employeeEntity);
            SaveChanges(nameof(CreateEmployee));
            var dto = _mapper.Map<EmployeeDto>(employeeEntity);
            return Response.Ok(dto);
        }

        public Response<EmployeeDto> DeleteEmployee(int id)
        {
            var employee = _repository.GetByIdAsync(id).Result;
            _repository.Delete(employee);
            SaveChanges(nameof(DeleteEmployee));
            var dto = _mapper.Map<EmployeeDto>(employee);
            return Response.Ok(dto);
        }

        public async Task<Response<EmployeeDto>> GetEmployeeAsync(int id)
        {
            if (id == 0) 
                return Response.Fail<EmployeeDto>("Employee Id cannot be zero");

            var employee = await _repository.GetByIdAsync(id);
            var dto = _mapper.Map<EmployeeDto>(employee);
            return Response.Ok(dto);
        }

        public async Task<Response<IEnumerable<EmployeeDto>>> GetEmployeesAsync()
        {
            var employees = await _repository.GetAllAsync();
            var dto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return Response.Ok(dto);
        }

        public async Task<Response<IEnumerable<EmployeeDto>>> GetEmployeesByFirstNameAsync(string firstName)
        {
            if (!IsValidName<IEnumerable<EmployeeDto>>(firstName, out var failedResponse))
                return failedResponse;

            var response = await _repository.FindEntitiesByConditionAsync(x => x.FirstName.ToLower() == firstName.ToLower());
            var dto = _mapper.Map<IEnumerable<EmployeeDto>>(response);
            return Response.Ok(dto);
        }

        public async Task<Response<IEnumerable<EmployeeDto>>> GetEmployeesByMiddleNameAsync(string middleName)
        {
            if (!IsValidName<IEnumerable<EmployeeDto>>(middleName, out var failedResponse))
                return failedResponse;

            var response = await _repository.FindEntitiesByConditionAsync(x => x.MiddleName.ToLower() == middleName.ToLower());
            var dto = _mapper.Map<IEnumerable<EmployeeDto>>(response);
            return Response.Ok(dto);
        }

        public async Task<Response<IEnumerable<EmployeeDto>>> GetEmployeesByLastNameAsync(string lastName)
        {
            if (!IsValidName<IEnumerable<EmployeeDto>>(lastName, out var failedResponse))
                return failedResponse;

            var response = await _repository.FindEntitiesByConditionAsync(x => x.LastName.ToLower() == lastName.ToLower());
            var dto = _mapper.Map<IEnumerable<EmployeeDto>>(response);
            return Response.Ok(dto);
        }

        public Response<EmployeeDto> UpdateEmployee(EmployeeDto employeeDto)
        {
            var employeeEntity = _mapper.Map<Employee>(employeeDto);
            _repository.Update(employeeEntity);
            SaveChanges(nameof(UpdateEmployee));
            return Response.Ok(employeeDto);
        }

        private void SaveChanges(string methodName)
        {
            var successSave = _repository.SaveChangesAsync().Result;
            if (!successSave)
            {
                throw new Exception($"Error occured in {nameof(EmployeeService)}.{methodName}.");
            }
        }

        private static bool IsValidName<T>(string name, out Response<T> response)
        {
            if (string.IsNullOrEmpty(name))
            {
                response = Response.Fail<T>($"parameter cannot be empty.");
                return false;
            }
            response = Response.Ok<T>(default);
            return true;
        }
    }
}
