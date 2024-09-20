using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Popular_Search_Service.BackgroundJobs;
using Popular_Search_Service.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHostedService<PopularMoviesBackgroundJob>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//
builder.Services.AddDbContext<ApplicationDbContext>(Options => Options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection")));

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
