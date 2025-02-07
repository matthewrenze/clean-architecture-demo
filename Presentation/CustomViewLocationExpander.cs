using System;
using Microsoft.AspNetCore.Mvc.Razor;

namespace CleanArchitecture.Presentation
{
    public class CustomViewLocationExpander : IViewLocationExpander
    {        
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            return new[]
            {
                "~/{1}/Views/{0}.cshtml",
                "~/Shared/Views/{0}.cshtml"
            };
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            // Nothing needs to be done here
        }
    }
}