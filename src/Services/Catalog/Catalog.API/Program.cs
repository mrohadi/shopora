var builder = WebApplication.CreateBuilder(args);

// Add services to the DI container.
// Carter is an endpoint management for minimal API implementation
builder.Services.AddCarter();
builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapCarter();

app.Run();
