using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using MUGS2024dEMO.ApiService.Services;
using MUGS2024dEMO.ApiService.Services.AzureRedisCache;

var builder = WebApplication.CreateBuilder(args);



builder.AddServiceDefaults();

builder.Services.AddProblemDetails();

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<CountryData.Standard.CountryHelper>();
builder.Services.AddScoped<ICountryDataServices, CountryDataServices>();
builder.Services.AddScoped<IRedisCache, RedisCachesServices>();

// Register BlobServiceClient.
builder.Services.AddSingleton<BlobServiceClient>(x =>
    new BlobServiceClient(builder.Configuration.GetConnectionString("StorageAccount")));



// Register DbContext.



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI();
    app.UseSwagger();
}

app.UseExceptionHandler();
app.MapDefaultEndpoints();
app.MapControllers();

app.Run();
