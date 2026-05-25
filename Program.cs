using ECommerce_API.Data;                    
using ECommerce_API.Repositories;
using ECommerce_API.Services;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration
                .GetConnectionString("SqlServer");

            builder.Services.AddDbContext<ECommerce_API.Data.ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(3);
                });
            });

            builder.Services.AddScoped<ECommerce_API.Repositories.UsuariosRepositories>();
            builder.Services.AddScoped<ECommerce_API.Services.UsuariosServices>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                using var scope = app.Services.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<ECommerce_API.Data.ApplicationDbContext>();
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

                try
                {
                    var canConnect = db.Database.CanConnect();
                    logger.LogInformation("✅ Conexão com o banco: {CanConnect}", canConnect);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "❌ Erro ao conectar no banco de dados");
                }
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}