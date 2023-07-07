using ChessSir.DTOs;
using System.Security.AccessControl;

namespace ChessSir;

public class Database
{
    private readonly Dictionary<Guid, Player> _players = new();

    public Player? Get(Guid id)
    {
        return _players.TryGetValue(id, out var player) ? player : null;
    }

    public IEnumerable<Player> GetAll()
    {
        return _players.Values;
    }

    public Player? GetPlayerByName(string name)
    {
        return _players.Select(pair => pair.Value).FirstOrDefault(player => player.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
    }

    public void CreatePlayer(Player newPlayer)
    {
        Player? foundPlayer = Get(newPlayer.Id);
        if (foundPlayer is null) return;

        _players.Add(newPlayer.Id, newPlayer);
    }

    public void UpdatePlayer(Player existingPlayer)
    {
        Player? foundPlayer = Get(existingPlayer.Id);
        if (foundPlayer is null) return;

        _players[foundPlayer.Id] = existingPlayer;
    }

    public void RemovePlayer(Player existingPlayer)
    {
        _players.Remove(existingPlayer.Id);
    }
}
