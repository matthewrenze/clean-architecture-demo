using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Core.Commands
{
    public interface ICommandBus
    {
        void Execute(ICommand command);
    }
}
