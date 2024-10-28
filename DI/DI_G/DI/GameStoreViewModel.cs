using MessageProject;

namespace DI;
public class GameStoreViewModel
{
    private IMessageWrite _messageWrite;

    public GameStoreViewModel( IMessageWrite messageWrite)
    {
        _messageWrite = messageWrite;
    }
    public void Show(Game game)
    {
        _messageWrite.Write(game.ToString());
    }
}

