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
    // options.OrgId = "20112494026";
    options.BucketName = "test-csharp-bucket";
    options.ProjectID = "8286000000012033";
    options.ClientID = "1000.1QDVQ1XWF42FX3X8KLBEQMFZQHTTPT";
    options.ClientSecret = "bc832455a06902f29354c4c8d1d4ae039c1d41603f";
    options.RefreshToken = "1000.1d18d47f47167de5d22e142e05580e07.80e8c3ccff0d0fdaec4451943fd6776e";
    options.RedirectUrl = "http://localhost:8081/zoho";
    options.Environment =
        env.IsDevelopment()
            ? EStratusEnvironment.Development
            : EStratusEnvironment.Production;

    options.Region = ERegion.EU;
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
