namespace ConsoleApp1.Messages.Interfaces;

public interface IMessageWrite
{
    public int rand { get; set; }
    void Write(string message);
}
