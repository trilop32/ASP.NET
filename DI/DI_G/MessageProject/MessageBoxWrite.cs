using System.Runtime.InteropServices;
namespace MessageProject;

public class MessageBoxWrite: IMessageWrite
{
    [DllImport("User32.dll", CharSet=CharSet.Unicode)]
    public static extern int MessageBox(IntPtr h, string m, string c, int type);

    public void Write(string message)
    {
        MessageBox((IntPtr)0, message, "Игра", 0);
    }

}