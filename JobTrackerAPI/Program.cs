using JobTrackerAPI.Business;
using JobTrackerAPI.DataAccess;
using JobTrackerAPI.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<JobTrackerDbContext>(opts => opts.UseSqlServer(connectionString));

builder.Services.AddIdentityAuthentication();

builder.Services.AddBusinessLayer();
builder.Services.AddDataLayer();

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseIdentityAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();