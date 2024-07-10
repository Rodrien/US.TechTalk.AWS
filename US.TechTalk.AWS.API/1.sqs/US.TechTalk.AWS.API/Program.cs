using Amazon.SQS;
using US.TechTalk.AWS.API.Messaging;
using US.TechTalk.AWS.API.Services;
using US.TechTalk.AWS.API.Services.Interfaces;
using US.TechTalk.AWS.API.Validation;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

builder.Services.Configure<QueueSettings>(builder.Configuration.GetSection(QueueSettings.Key));
builder.Services.AddSingleton<IAmazonSQS, AmazonSQSClient>();
builder.Services.AddSingleton<ISqsMessenger, SqsMessenger>();

builder.Services.AddSingleton<IUrudatosService, UrudatosService>();

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
