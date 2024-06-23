using Financas.Aplication.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureService();
builder.ConfigureDependencies();

var app = builder.Build();
app.Setup();

app.Run();
