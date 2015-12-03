using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Core.Events
{
    public interface IEventHandler<T>
    {
        void Handle(T args);
    }
}
