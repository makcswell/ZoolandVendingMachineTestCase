
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using zooland.DataBaseContext;


namespace UsersService;

// ReSharper disable once ClassNeverInstantiated.Global
public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Configuration.AddJsonFile("appsettings.json", false);

        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Logging.SetMinimumLevel(LogLevel.Trace);

        ConfigureServices(builder.Services, builder.Configuration);

        WebApplication app = builder.Build();

        app.UseCors(b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();


        app.UseSwagger();
        app.UseSwaggerUI();


        app.MapControllers();

        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddCors();
        services.AddMvc();

   

        services.AddControllers();

        services.AddMemoryCache();

        services.AddDbContext<ZoolandDbContext>(d => d.UseNpgsql(configuration.GetConnectionString("MyConnection")),
            ServiceLifetime.Scoped, ServiceLifetime.Scoped);


        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                In = ParameterLocation.Header,
                Name = "Authorization",
                Scheme = "bearer",
                BearerFormat = "jwt-bearer",
                Description =
                    "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\""
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                    },
                    Array.Empty<string>()
                }
            });
        });
        services.AddRouting(urls => urls.LowercaseUrls = true);
    }
}