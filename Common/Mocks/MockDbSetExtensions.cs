using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Moq;

namespace CleanArchitecture.Common.Mocks
{
    public static class MockDbSetExtensions
    {
        public static void SetUpDbSet<T>(this Mock<IDbSet<T>> mock, IList<T> list)
            where T : class
        {
            var queryable = list.AsQueryable();

            mock.Setup(p => p.GetEnumerator())
                .Returns(queryable.GetEnumerator());

            mock.Setup(p => p.Provider)
                .Returns(queryable.Provider);

            mock.Setup(p => p.ElementType)
                .Returns(queryable.ElementType);

            mock.Setup(p => p.Expression)
                .Returns(queryable.Expression);
        }
    }
}
