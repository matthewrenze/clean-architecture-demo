using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Core.Queries
{
    public interface IQueryBus
    {
        TResult Execute<TResult>(IQuery<TResult> query);
    }
}
