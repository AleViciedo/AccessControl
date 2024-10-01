using AccessControl.Domain.ValueObjects;
using AccessControl.GrpcProtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AccessControl.Domain;
using AccessControl.Application.Abstract;

namespace AccessControl.Application.Process.Commands.CreateProcess
{
    public record CreateProcessCommand(
        string Name,
        List<Domain.ValueObjects.Product> Products
        ) : ICommand<Domain.ValueObjects.Process>;
}
