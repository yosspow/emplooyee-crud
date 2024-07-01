
using MediatR;
using EmployeeManagement.Models;
using EmployeeManagement.Persistence;
using EmployeeManagement.Commands;

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Handlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Employee>
    {
        private readonly EmployeeDbContext _context;

        public UpdateEmployeeCommandHandler(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.Id);

            if (employee == null)
            {
                throw new Exception($"Employee with Id {request.Id} not found.");
            }

            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.Email = request.Email;
            employee.PhoneNumber = request.PhoneNumber;
            employee.Position = request.Position;
            employee.Department = request.Department;

            await _context.SaveChangesAsync(cancellationToken);

            return employee;
        }
    }
}
