using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Configuration.AddJsonFile("ocelot.json", false, reloadOnChange: true);
builder.Services.AddOcelot();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();


app.UseHttpsRedirection();

await app.UseOcelot();

app.Run();