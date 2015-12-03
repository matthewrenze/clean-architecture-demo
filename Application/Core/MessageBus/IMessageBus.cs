using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Core.Commands;
using CleanArchitecture.Application.Core.Events;
using CleanArchitecture.Application.Core.Queries;

namespace CleanArchitecture.Application.Core.MessageBus
{
    public interface IMessageBus
    {
        void Execute(ICommand command);

        T Execute<T>(IQuery<T> query);

        void Raise(IEvent @event);
    }
}
