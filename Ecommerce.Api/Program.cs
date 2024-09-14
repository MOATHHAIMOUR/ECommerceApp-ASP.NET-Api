using Ecommerce.Api.Middleware;
using Ecommerce.Domain;
using Ecommerce.Infrstructure;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);


//Configuer Infrastrucuer Layer  
builder.Services.InfrastructureConfiguration(builder.Configuration);

//Configuer Application Layer  
builder.Services.RegisterApplicationDependencies(builder.Configuration);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

// Configure logging
builder.Logging.ClearProviders(); // Optional: Clear default providers if needed
builder.Logging.AddConsole(); // Add desired logging providers (Console, Debug, etc.)

//Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactApp", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:5000");
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowCredentials();
    });

    options.AddPolicy("AngulerApp", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:4901");
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowCredentials();
    });
});


//Configure Loclization 
builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "";
});
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("ar-JO")
    };
    options.DefaultRequestCulture = new RequestCulture(culture: supportedCultures[1]);
    options.SupportedCultures = supportedCultures;
    // This ensures that the default culture is used if no culture is specified in the request.
    options.FallBackToParentCultures = false;
    options.FallBackToParentUICultures = false;
    options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider()); // Add QueryStringProvider for Culture switching

});





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExeptionHandlingMiddleware>();

//Localization
var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);

//CORS
app.UseCors("ReactApp");
app.UseCors("AngulerApp");

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();