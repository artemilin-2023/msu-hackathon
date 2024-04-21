using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Minio;
using Minio.DataModel.Args;
using WorkShare.Application.Abstracts;
using WorkShare.Application.Services;
using WorkShare.Infrastructure.Auth;
using WorkShare.Infrastructure.Data;
using WorkShare.Infrastructure.Data.Repositories;


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme);
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,
            },
            new List<string>()
          }
        });
});

services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("PostgreSQL"));
}, ServiceLifetime.Singleton);

services.AddMinio(options =>
{
    options.WithEndpoint(configuration.GetConnectionString("MinIO"));
    options.WithCredentials(configuration["MinIO:Login"], configuration["MinIO:SecretKey"]);
    options.WithSSL(false);
});

services.AddSingleton<IStorage, Storage>();
services.AddSingleton<IWorkRepository, WorkRepository>();

services.AddScoped<WorkServices>();
services.AddScoped<AccessService>();
services.AddScoped<IAuthProvider, AuthProvider>();


var app = builder.Build();

var db = app.Services.GetService<DataContext>();
await db.Database.MigrateAsync();

var minIO = app.Services.GetService<IMinioClient>();
var bucketExists = await minIO.BucketExistsAsync(new BucketExistsArgs().WithBucket("storage"));
if (!bucketExists)
{
    await minIO.MakeBucketAsync(new MakeBucketArgs().WithBucket("storage"));
}


app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.Run();
