namespace SportPit.Core;

public class ControllerName
{
    private const string Controller = "Controller";

    public static string GetName(string strTypeController) =>
        strTypeController.Replace(Controller, string.Empty);
}