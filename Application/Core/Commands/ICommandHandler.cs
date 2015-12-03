using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Core.Commands
{
    public interface ICommandHandler<T>
    {
        void Execute(T command);
    }
}
