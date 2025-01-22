using Carter;

var builder = WebApplication.CreateBuilder(args);

// add services to the container

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

builder.Services.AddMarten( opts =>
{
    var connString = builder.Configuration.GetConnectionString("Database")!;
    Console.WriteLine(connString);
    opts.Connection(connString);

}).UseLightweightSessions();

var app = builder.Build();


//Configure the HTTP request pipeline

app.MapCarter();

app.Run();
