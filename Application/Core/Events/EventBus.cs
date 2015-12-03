using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;

namespace CleanArchitecture.Application.Core.Events
{
    public class EventBus : IEventBus
    {
        public static IContainer Container;

        public void Raise(IEvent @event)
        {
            var handlerType = typeof(IEventHandler<>)
                .MakeGenericType(@event.GetType());

            var handlers = Container
                .GetAllInstances(handlerType)
                .Cast<dynamic>();

            foreach (var handler in handlers)
                handler.Handle((dynamic)@event);
        }
    }
}
