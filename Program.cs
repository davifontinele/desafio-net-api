
using System.Text.Json.Serialization;
using TrilhaApiDesafio.Context;
using Microsoft.EntityFrameworkCore;

namespace desaio_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<OrganizadorContext>(options =>
    options.UseMySql(
    builder.Configuration.GetConnectionString("ConexaoPadrao"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ConexaoPadrao"))
));

            builder.Services.AddControllers().AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
