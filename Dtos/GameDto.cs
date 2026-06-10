namespace GameStore.Api.Dtos;

public record GameDto(
    int Id,
    string Name,
    string Gener,
    decimal Price,
    DateOnly Releases
);

