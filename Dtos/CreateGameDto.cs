namespace GameStore.Api.Dtos;

public record CreateGameDto(

    string Name,
    string Gener,
    decimal Price,
    DateOnly ReleaseDate
);
