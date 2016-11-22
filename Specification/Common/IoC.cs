using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Common.Dates;
using StructureMap;
using StructureMap.Graph;

namespace CleanArchitecture.Specification.Common
{
    public static class IoC
    {
        public static IContainer Initialize(AppContext appContext)
        {
            ObjectFactory.Initialize(x =>
            {
                SetScanningPolicy(x);

                x.For<IDatabaseContext>()
                    .Use(appContext.Database);

                x.For<IInventoryClient>()
                    .Use(appContext.InventoryClient);

                x.For<IDateService>()
                    .Use(appContext.DateService);

            });

            return ObjectFactory.Container;
        }

        private static void SetScanningPolicy(IInitializationExpression x)
        {
            x.Scan(scan =>
            {
                scan.AssembliesFromApplicationBaseDirectory(
                    filter => filter.FullName.StartsWith("CleanArchitecture"));

                scan.WithDefaultConventions();
            });
        }
    }
}
