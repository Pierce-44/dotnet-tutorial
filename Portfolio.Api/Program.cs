using Projects.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapProjectsEndpoints();

// commit

app.Run();
