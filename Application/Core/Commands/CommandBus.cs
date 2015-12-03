using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StructureMap;

namespace CleanArchitecture.Application.Core.Commands
{
    public class CommandBus : ICommandBus
    {
        public static IContainer Container;

        public void Execute(ICommand command)
        {
            var handlerType = typeof (ICommandHandler<>)
                .MakeGenericType(command.GetType());

            dynamic handler = Container.GetInstance(handlerType);

            handler.Execute((dynamic) command);
        }
    }
}
