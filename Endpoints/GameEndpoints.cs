using GameStore.Api.Dtos;

namespace GameStore.Api.Endpoints;

public static class GameEndpoints
{
    private static readonly List<GameDto> games =
    [
        new (1,"cod","fight",20.00M,new DateOnly(2000,7,7)),
        new (2,"coc","strategy",10.00M,new DateOnly(1999,7,4)),
        new (3,"chess","strategy",0.90M,new DateOnly(2003,7,2)),
        new (4,"pokemon","fight",200.00M,new DateOnly(2024,7,7))
    ];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/games");

        // GET /games
        group.MapGet("/", () => games);

        // GET /games/{id}
        group.MapGet("/{id}", (int id) =>
        {
            var game = games.Find(game => game.Id == id);

            return game is null
                ? Results.NotFound()
                : Results.Ok(game);
        })
        .WithName("GetGame");

        // POST /games
        group.MapPost("/", (CreateGameDto newGame) =>
        {
            GameDto game = new(
                games.Count + 1,
                newGame.Name,
                newGame.Gener,
                newGame.Price,
                newGame.ReleaseDate
            );

            games.Add(game);

            return Results.CreatedAtRoute(
                "GetGame",
                new { id = game.Id },
                game
            );
        });

        // PUT /games/{id}
        group.MapPut("/{id}", (int id, UpdateGameDto updateGame) =>
        {
            var index = games.FindIndex(game => game.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            games[index] = new GameDto(
                id,
                updateGame.Name,
                updateGame.Gener,
                updateGame.Price,
                updateGame.Releases
            );

            return Results.NoContent();
        });

        // DELETE /games/{id}
        group.MapDelete("/{id}", (int id) =>
        {
            var removed = games.RemoveAll(game => game.Id == id);

            return removed == 0
                ? Results.NotFound()
                : Results.NoContent();
        });

        return group;
    }
}