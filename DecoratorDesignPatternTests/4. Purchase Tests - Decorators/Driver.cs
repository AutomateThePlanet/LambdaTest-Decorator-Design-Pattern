namespace DecoratorDesignPattern.FourthVersion;

public abstract class Driver
{
    public abstract string Url { get; }
    public abstract void Start(Browser browser);
    public abstract void Refresh();
    public abstract void Quit();
    public abstract void GoToUrl(string url);
    public abstract Component FindComponent(By locator);
    public abstract List<Component> FindComponents(By locator);

    public abstract bool ComponentExists(Component component);
    public abstract void ExecuteScript(string script, params object[] args);
    public abstract void DeleteAllCookies();
}
