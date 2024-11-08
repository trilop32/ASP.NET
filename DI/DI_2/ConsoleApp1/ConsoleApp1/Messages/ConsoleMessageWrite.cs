using ConsoleApp1.Messages.Interfaces;

namespace ConsoleApp1.Messages;

public class ConsoleMessageWrite : IMessageWrite
{
    public int rand { get; set; } = new Random().Next(100);
    public void Write(string message)
    {
        Console.WriteLine(message);
    }
}
