using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
var app = builder.Build();

// Register all game endpoints
app.MapGamesEndpoints();

app.Run();