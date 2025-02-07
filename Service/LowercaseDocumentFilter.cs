using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

//TODO: Move to Shared folder or Common project?

namespace CleanArchitecture.Service
{
    public class LowercaseDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var paths = swaggerDoc.Paths;
         
            var newPaths = new Dictionary<string, OpenApiPathItem>();

            var removeKeys = new List<string>();

            foreach (var path in paths)
            {
                var newKey = path.Key.ToLower();

                if (newKey != path.Key)
                {
                    removeKeys.Add(path.Key);

                    newPaths.Add(newKey, path.Value);
                }
            }

            foreach (var path in newPaths)
                swaggerDoc.Paths.Add(path.Key, path.Value);

            foreach (var key in removeKeys)
                swaggerDoc.Paths.Remove(key);
        }
    }
}