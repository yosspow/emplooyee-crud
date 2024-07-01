
using EmployeeManagement.Models;
using MediatR;
using System;

namespace EmployeeManagement.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public Guid Id { get; set; }
    }
}
