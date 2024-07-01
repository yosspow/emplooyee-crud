
using EmployeeManagement.Models;
using EmployeeManagement.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Queries
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly EmployeeDbContext _context;

        public GetEmployeeByIdQueryHandler(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
        }
    }
}
