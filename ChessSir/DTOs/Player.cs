namespace ChessSir.DTOs;

public class Player
{
    private int _rating = 1000;

    public Guid Id { get; init; } = Guid.NewGuid();

    public string Name { get; set; } = "";

    public string Title { get; set; } = "";

    public int Rating
    {
        get => _rating;
        set
        {
            if (_rating + value < 100) return;
            _rating = value;
        }
    }
}
