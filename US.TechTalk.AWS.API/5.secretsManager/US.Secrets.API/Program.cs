using US.Secrets.API;
using US.Secrets.API.Services;

var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment.EnvironmentName;
var appName = builder.Environment.ApplicationName;

// Nugget: Kralizek.Extensions.Configuration.AWSSecrets

// TODO: Descomentar
//builder.Configuration.AddSecretsManager(configurator: options =>
//{
//    options.SecretFilter = entry => entry.Name.StartsWith($"{env}_{appName}");
//    options.KeyGenerator = (_, s) =>
//    {
//        string original = s;
//        s = s
//        .Replace($"{env}_{appName}_", string.Empty)
//        .Replace("__", ":");

//        return s;
//    };
//    //options.PollingInterval = TimeSpan.FromSeconds(10);
//});

builder.Services.AddSingleton<ISecretService, SecretService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//SecretApiSettings
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection(ApiSettings.Key));

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
