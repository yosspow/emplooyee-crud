
using MediatR;
using EmployeeManagement.Models;
using EmployeeManagement.Commands;

using EmployeeManagement.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly EmployeeDbContext _context;

        public CreateEmployeeCommandHandler(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Position = request.Position,
                Department = request.Department
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync(cancellationToken);

            return employee;
        }
    }
}
