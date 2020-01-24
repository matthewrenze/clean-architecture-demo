using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Common.Dates;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace CleanArchitecture.Specification.Common
{
    public static class IoC
    {
        public static IContainer Initialize(AppContext appContext)
        {
            return new Container(x =>
            {
                SetScanningPolicy(x);

                x.For<IDatabaseService>()
                 .Use(appContext.DatabaseService);

                x.For<IInventoryService>()
                 .Use(appContext.InventoryService);

                x.For<IDateService>()
                 .Use(appContext.DateService);
            });
        }

        private static void SetScanningPolicy(IRegistry x)
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
