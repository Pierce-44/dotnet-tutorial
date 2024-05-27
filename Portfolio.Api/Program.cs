using Portfolio.Api.Data;
using Projects.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ProjectStore");
builder.Services.AddSqlite<ProjectStoreContext>(connectionString);

var app = builder.Build();

app.MapProjectsEndpoints();

app.MigrateDb();

app.Run();
