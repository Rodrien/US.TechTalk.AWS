using Amazon.DynamoDBv2;
using US.TechTalk.AWS.API.Messaging;
using US.TechTalk.AWS.API.Repositories;
using US.TechTalk.AWS.API.Services;
using US.TechTalk.AWS.API.Services.Interfaces;
using US.TechTalk.AWS.API.Validation;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

builder.Services.Configure<TopicSettings>(builder.Configuration.GetSection(TopicSettings.Key));
builder.Services.AddSingleton<IAmazonDynamoDB, AmazonDynamoDBClient>();

builder.Services.AddSingleton<IUrudatosService, UrudatosService>();
builder.Services.AddSingleton<IUrudatosRepository, UrudatosRepository>();

builder.Services.AddControllers();
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

app.UseMiddleware<ValidationExceptionMiddleware>();

app.MapControllers();

app.Run();
