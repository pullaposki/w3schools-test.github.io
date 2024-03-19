using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Mappers
{
    public static class EmployeeMappers
    {
        public static AnEmployeeResponseDto ToResponseDto(this Employee employeeModel)
        {
            return new AnEmployeeResponseDto
            {
                EmployeeId = employeeModel.EmployeeId,
                FirstName = employeeModel.FirstName,
                LastName = employeeModel.LastName,
                Position = employeeModel.Position,
                CompanyId = employeeModel.CompanyId
            };
        }

        public static Employee ToModelFromACreateRequestDto(this ACreateEmployeeRequestDto createDto, int companyId)
        {
            return new Employee
            {
                FirstName = createDto.FirstName,
                LastName = createDto.LastName,
                Position = createDto.Position,
                CompanyId = companyId
            };
        }
        
        public static Employee ToModelFromAnUpdateRequestDto(this AnUpdateEmployeeRequestDto updateDto)
        {
            return new Employee
            {
                FirstName = updateDto.FirstName,
                LastName = updateDto.LastName,
                Position = updateDto.Position
            };
        }
    }
}