using EmployeeManagement.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Commands
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly EmployeeDbContext _context;
        private readonly ILogger<DeleteEmployeeCommandHandler> _logger;

        public DeleteEmployeeCommandHandler(EmployeeDbContext context, ILogger<DeleteEmployeeCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.Id);

            if (employee == null)
            {
                _logger.LogWarning("Employee with ID: {Id} not found", request.Id);
                return false; // Indicate that the employee was not found
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Employee with ID: {Id} deleted", request.Id);
            return true; // Indicate that the deletion was successful
        }
    }
}
