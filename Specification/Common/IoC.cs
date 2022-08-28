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
            var container = new Container(x =>
            {
                x.Scan(scan =>
                {
                    scan.AssembliesFromApplicationBaseDirectory(
                        filter => filter.FullName.StartsWith("CleanArchitecture"));

                    scan.WithDefaultConventions();
                });

                x.For<IDatabaseService>()
                    .Use(appContext.DatabaseService);

                x.For<IInventoryService>()
                    .Use(appContext.InventoryService);

                x.For<IDateService>()
                    .Use(appContext.DateService);
            });

            return container;
        }
    }
}
