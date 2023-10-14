using cookie_stand_api.Data;
using cookie_stand_api.Model;
using cookie_stand_api.Model.Interface;
using cookie_stand_api.Model.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace cookie_stand_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
       options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
     );

            string connString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services
                .AddDbContext<CookieDbContext>
                (opions => opions.UseSqlServer(connString));
            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                // There are other options like this
            })
.AddEntityFrameworkStores<CookieDbContext>();

   
 builder.Services.AddTransient<ICookieStand, CookieStandServiescs>();
  builder.Services.AddTransient<IUserService, IdentityUserService>();
            builder.Services.AddTransient<IHourlySales, HourlySalesServies>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                {
                    builder
                        .WithOrigins("http://localhost:3000") // Add your Next.js frontend URL
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()

                {
                    Title = "Cookie-System",
                    Version = "v1",
                });
            });
            var app = builder.Build();
            app.UseSwagger(options =>
            {
                options.RouteTemplate = "/api/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Cookie-System");
                options.RoutePrefix = "docs";
            });
            app.UseCors("AllowSpecificOrigin");
            app.MapControllers();
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}