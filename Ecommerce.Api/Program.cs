using Ecommerce.Api.Middleware;
using Ecommerce.Infrstructure;
using Ecommerce.Domain;

var builder = WebApplication.CreateBuilder(args);

//Configuer Infrastrucuer Layer  
builder.Services.InfrastructureConfiguration(builder.Configuration);

//Configuer Application Layer  
builder.Services.RegisterApplicationDependencies();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Configure logging
builder.Logging.ClearProviders(); // Optional: Clear default providers if needed
builder.Logging.AddConsole(); // Add desired logging providers (Console, Debug, etc.)


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExeptionHandlingMiddleware>();

app.UseAuthentication();
app.UseHttpsRedirection();
app.MapControllers();   
app.Run();