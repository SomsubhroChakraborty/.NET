namespace GameStore.Api.Dtos;

public record UpdateGameDto

(
     int Id,
    string Name,
    string Gener,
    decimal Price,
    DateOnly Releases
);
