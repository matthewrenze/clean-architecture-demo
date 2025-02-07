using System.Runtime.Loader;

namespace CleanArchitecture.Service;

class Program
{
    static void Main(string[] args)
    {
        var files = Directory.GetFiles(
            AppDomain.CurrentDomain.BaseDirectory,
            "CleanArchitecture*.dll");

        var assemblies = files
            .Select(p => AssemblyLoadContext.Default.LoadFromAssemblyPath(p));

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(
            p => p.DocumentFilter<LowercaseDocumentFilter>());

        builder.Services.AddAdvancedDependencyInjection();

        builder.Services.Scan(p => p.FromAssemblies(assemblies)
            .AddClasses()
            .AsMatchingInterface());

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.UseAdvancedDependencyInjection();

        app.Run();
    }
}