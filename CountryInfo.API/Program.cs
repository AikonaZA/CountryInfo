using CountryInfo.Application.Interfaces;
using CountryInfo.Application.Mappings;
using CountryInfo.Application.Services;
using CountryInfo.Infrastructure.Configuration;
using CountryInfo.Infrastructure.Interfaces;
using CountryInfo.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Bind configuration section to RestCountriesApiSettings
builder.Services.Configure<RestCountriesApiSettings>(builder.Configuration.GetSection("RestCountriesApi"));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<IRestCountriesClient, RestCountriesClient>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add response caching
builder.Services.AddResponseCaching();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:7139") // Blazor WebAssembly app URL
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS
app.UseCors("AllowSpecificOrigin");

// Use response caching middleware
app.UseResponseCaching();
app.UseAuthorization();
app.MapControllers();
app.Run();
