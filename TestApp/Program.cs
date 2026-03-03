using Scalar.AspNetCore;
using StratusSDK;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddStratusExtensions(options =>
{
    builder.Configuration.GetSection("Stratus").Bind(options);
    options.Environment =
        env.IsDevelopment()
            ? EStratusEnvironment.Development
            : EStratusEnvironment.Production;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi("/openapi/{documentName}.json");


    app.MapScalarApiReference(options =>
    {
        options
        .WithTitle("SDK Controller")
        .WithTheme(ScalarTheme.DeepSpace)
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
