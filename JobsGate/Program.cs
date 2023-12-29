
using JobsGate.Data;
using JobsGate.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace JobsGate
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


            // ----------------------- DbContext ------------------//

                builder.Services.AddDbContext<ApplicationDbContext>(options=>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                );
            // ---------------------------------------------- //

            // ----------------------- AddIdentity ------------------//

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            //----------------------------------------------//

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(ops =>
            {
                ops.RequireHttpsMetadata = true;
                ops.SaveToken = false;
                ops.TokenValidationParameters   = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey    = true,
                    ValidateIssuer              = true,
                    ValidateAudience            = true,
                    ValidateLifetime            = true,    

                    ValidIssuer                 = builder.Configuration["JWT:Issuer"],
                    ValidAudience               = builder.Configuration["JWT:Audience"],
                    IssuerSigningKey            = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SECRETKEY"]))
                };

            });

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