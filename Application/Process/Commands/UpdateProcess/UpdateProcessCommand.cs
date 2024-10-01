using AccessControl.Application.Abstract;
using AccessControl.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Application.Process.Commands.UpdateProcess
{
    public record UpdateProcessCommand(
        Domain.ValueObjects.Process process
        ) :ICommand;
}
