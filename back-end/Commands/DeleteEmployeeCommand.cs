using MediatR;
using System;

namespace EmployeeManagement.Commands
{
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
