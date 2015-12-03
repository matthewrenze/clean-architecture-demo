using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;

namespace CleanArchitecture.Application.Core.Queries
{
    public class QueryBus : IQueryBus
    {
        public static IContainer Container;

        public TResult Execute<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>)
                .MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = Container.GetInstance(handlerType);

            return handler.Execute((dynamic)query);
        }
    }
}
