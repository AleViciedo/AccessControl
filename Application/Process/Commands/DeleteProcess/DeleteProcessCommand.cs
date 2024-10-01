using AccessControl.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Application.Process.Commands.DeleteProcess
{
    public record DeleteProcessCommand(
        Guid Id
        ) : ICommand;
}
