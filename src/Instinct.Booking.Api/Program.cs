using Instinct.Booking.Api;
using Instinct.Booking.Application;
using Instinct.Booking.Common;
using Instinct.Booking.External;
using Instinct.Booking.Persistence;

var builder = WebApplication.CreateBuilder(args);

#region KeyVault Configuration
/*
var keyVaultUrl = builder.Configuration["keyVaultUrl"] ?? string.Empty;

if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "local")
{
    string tenantId = Environment.GetEnvironmentVariable("tenantId") ?? string.Empty;
    string clientId = Environment.GetEnvironmentVariable("clientId") ?? string.Empty;
    string clientSecret = Environment.GetEnvironmentVariable("clientSecret") ?? string.Empty;

    var tokenCredentials = new ClientSecretCredential(tenantId, clientId, clientSecret);
    builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUrl), tokenCredentials);
}
else
{
    builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUrl), new DefaultAzureCredential());
}
*/
#endregion

#region Dependency Injection Setup

builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);
#endregion

builder.Services.AddControllers();
var app = builder.Build();

#region Swagger
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
#endregion

#region Middleware Pipeline
app.UseAuthentication();
app.UseAuthorization();
#endregion

app.MapControllers();

app.Run();
