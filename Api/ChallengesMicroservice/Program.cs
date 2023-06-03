using ChallengesMicroservice.Repository;
using ChallengesMicroservice.Repository.Core;
using Extens.Core.Services;
using Extens.Errors;
using Extens.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DbContext = ChallengesMicroservice.Database.DbContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbContext>();
builder.Services.AddScoped<IChallengesRepository, ChallengesRepository>();
builder.Services.AddScoped<IDayRepository, DaysRepository>();
builder.Services.AddScoped<IDayTasksRepository, DayTasksRepository>();
builder.Services.AddScoped<IValidationService, ValidationService>();
builder.Services.AddScoped<ExceptionHandlerMiddleware>();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();
app.UseMiddleware<ExceptionHandlerMiddleware>();

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