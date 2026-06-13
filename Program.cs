using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// Register all game endpoints
app.MapGamesEndpoints();

app.Run();