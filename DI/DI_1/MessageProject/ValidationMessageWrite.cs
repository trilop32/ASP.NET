using System.ComponentModel;

namespace MessageProject;

public class ValidationMessageWrite: IMessageWrite
{
    private string _login;
    private string _password;
    private IMessageWrite _messageWrite;
    public ValidationMessageWrite(string login,string password, IMessageWrite messageWrite)
    {
        _login = login;
        _password = password;
        _messageWrite = messageWrite;
    }
    public void Write(string message)
    {
        if (_login == "qwerty" && _password == "12345678")
        {
            _messageWrite.Write(message);
        }
    }
}
