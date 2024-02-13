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
    }
}