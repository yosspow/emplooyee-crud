
using MediatR;
using System.Collections.Generic;
using EmployeeManagement.Models;

namespace EmployeeManagement.Queries
{
    public class GetAllEmployeesQuery : IRequest<List<Employee>>
    {
    }
}
