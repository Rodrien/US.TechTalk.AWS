using US.Secrets.API;

var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment.EnvironmentName;
var appName = builder.Environment.ApplicationName;

// Nugget: Kralizek.Extensions.Configuration.AWSSecrets
//builder.Configuration.AddSecretsManager(configurator: options =>
//{
//    options.SecretFilter = entry => entry.Name.StartsWith($"{env}_{appName}");
//    options.KeyGenerator = (_, s) => s
//        .Replace($"{env}_{appName}_", string.Empty)
//        .Replace("__", ":");
//    options.PollingInterval = TimeSpan.FromSeconds(10);
//});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//SecretApiSettings
builder.Services.Configure<SecretApiSettings>(builder.Configuration.GetSection(SecretApiSettings.Key));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
