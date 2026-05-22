using WebApplication1.DATA;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using WebApplication1.Services.Autor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.// arquivo: WebApplication1/Services/Autor/IAutoService.cs (ou onde a classe está definida)
namespace WebApplication1.Services.Autor
{
    public interface AutorInterface
    {
        // métodos da interface
    }

    // Corrigido: a classe agora implementa a interface AutorInterface
    public class IAutoService : AutorInterface
    {
        // implementação dos métodos
    }
}AddScoped <AutorInterface, IAutoService>();

builder.Services.AddDbContext<AppDbcontext>(options =>
{ 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
