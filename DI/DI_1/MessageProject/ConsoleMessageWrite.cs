namespace MessageProject;
public class ConsoleMessageWrite : IMessageWrite
{
    public void Write(string message)
    {
        Console.WriteLine(message);
    }
}
