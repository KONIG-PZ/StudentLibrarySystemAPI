
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentLibrarySystem.Data;

namespace StudentLibrarySystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //React Connection
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReact",
                    policy => policy
                    .WithOrigins("http://localhost:5173")
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            }
            );

            //Sql Connection (LocalHost)
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(
                        builder.Configuration.GetConnectionString("DefaultConnection"),
                        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
                        
                    )
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowReact");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
