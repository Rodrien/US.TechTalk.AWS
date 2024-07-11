using Amazon.S3;
using Amazon.SimpleNotificationService;
using US.TechTalk.AWS.API.Messaging;
using US.TechTalk.AWS.API.Services;
using US.TechTalk.AWS.API.Services.Interfaces;
using US.TechTalk.AWS.API.Validation;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

builder.Services.Configure<TopicSettings>(builder.Configuration.GetSection(TopicSettings.Key));
builder.Services.AddSingleton<IAmazonSimpleNotificationService, AmazonSimpleNotificationServiceClient>();
builder.Services.AddSingleton<ISnsMessenger, SnsMessenger>(); 
builder.Services.AddSingleton<IAmazonS3, AmazonS3Client>(); 

builder.Services.AddSingleton<IUrudatosService, UrudatosService>();
builder.Services.AddSingleton<IUrudatosImageService, UrudatosImageService>();

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
