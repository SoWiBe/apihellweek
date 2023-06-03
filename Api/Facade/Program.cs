using Extens.Core.Repositories;
using Extens.Core.Services;
using Extens.Errors;
using Extens.Repositories;
using Extens.Services;
using Facade.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IApiRepository, ApiRepository>();
builder.Services.AddScoped<ITasksService, TasksService>();
builder.Services.AddScoped<IChallengesService, ChallengesService>();
builder.Services.AddScoped<IAggregationService, AggregationService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ExceptionHandlerMiddleware>();

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