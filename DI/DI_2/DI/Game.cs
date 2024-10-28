namespace DI;
public class Game
{
    public required string Title { get; set; }
    public required string Publisher { get; set; }
    public required DateOnly DataRelease { get; set; }
    public required bool Multiplayear { get; set; }
    public required string Genre { get; set; }
    public override string ToString()
    {
        return $"Издательство: {Publisher}, Дата выхода: {DataRelease.ToString("D")}, Онлайн игра: {IsMultiplayer()}, Жанр: {Genre}";
    }
    public string IsMultiplayer()
    {
        if(Multiplayear)
        {
            return "поддерживается";
        }
        return "не поддерживается";
    }
}