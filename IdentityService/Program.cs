using IdentityService.Entities;
using IdentityService.Repositories;
using IdentityService.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityService;

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
        builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
        builder.Services.AddAuthorizationBuilder();
        builder.Services.AddIdentity<User, UserRole>()
            .AddMongoDbStores<User, UserRole, Guid>(builder.Configuration.GetConnectionString("MongoDb"), builder.Configuration.GetSection("MongoDb:Database").Value)
            .AddApiEndpoints();

        builder.Services.AddDbContext<UsersDbContext>(opt => { opt.UseMongoDB(builder.Configuration.GetConnectionString("MongoDb"), builder.Configuration.GetSection("MongoDb:Database").Value); });

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();

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

        app.MapIdentityApi<User>();

        app.Run();
    }
}