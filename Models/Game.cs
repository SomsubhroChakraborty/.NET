

using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace GameStore.Api.Models;

public class Game
{
public int Id { get; set; }

public required string Name { get; set; }

public Gener? Gener {get; set; }

public int GenerId {get; set;}

public decimal Price {get; set;}

public DateOnly ReleaseDate {get; set;}

}
