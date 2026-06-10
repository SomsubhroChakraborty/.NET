    using GameStore.Api.Dtos;

    var builder = WebApplication.CreateBuilder(args);
    var app = builder.Build();


    List<GameDto> games = [
        new (1,"cod","fight",20.00M,new DateOnly(2000,7,7)),
        new (2,"coc","strategy",10.00M,new DateOnly(1999,7,4)),
        new (3,"chess","strategy",00.90M,new DateOnly(2003,7,2)),
        new (4,"pokemon","fight",200.00M,new DateOnly(2024,7,7)),
    ];
    //Get 
    app.MapGet("/games", () => games);
    //Get /game/id
    app.MapGet("/games/{id}", (int id) => games.Find(game=>game.Id == id))
    .WithName("GetGame");
    //Post
    app.MapPost("/games", (CreateGameDto newGame) =>
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
    app.Run();
