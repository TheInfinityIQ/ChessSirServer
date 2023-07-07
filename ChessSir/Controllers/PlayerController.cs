using ChessSir.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ChessSir.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly Database _db;

    public PlayerController(Database db)
    {
        this._db = db;
    }

    [HttpPost]
    public IActionResult Matchmaking()
    {
        List<Player> players = _db.GetAll().OrderBy(_ => Random.Shared.Next()).ToList();
        if (players.Count is 0 or 1)
        {
            return BadRequest("our fault no data bros - give money and accounts - buy me a coffeeeeeee");
        }
        Player playerOne = players[0];
        Player playerTwo = players[1];

        var result = new PlayerGameState();
        result.Two = new(playerOne.Id, playerOne.Name, playerOne.Title, playerOne.Rating, true);
        result.One = new(playerTwo.Id, playerTwo.Name, playerTwo.Title, playerTwo.Rating, false);

        return Ok(result);
    }
}

public class PlayerGameState
{
    public ChessPlayer One { get; set; }
    public ChessPlayer Two { get; set; }
}

public record ChessPlayer(Guid Id, string Name, string Title, int Rating, bool IsWhite);


