namespace DecoratorDesignPattern.FourthVersion;

public abstract class DriverDecorator : Driver
{
    protected readonly Driver Driver;

    protected DriverDecorator(Driver driver)
    {
        Driver = driver;
    }

    public override void Start(Browser browser)
    {
        Driver?.Start(browser);
    }

    public override void Quit()
    {
        Driver?.Quit();
    }

    public override void GoToUrl(string url)
    {
        Driver?.GoToUrl(url);
    }

    public override Component FindComponent(By locator)
    {
        return Driver?.FindComponent(locator);
    }

    public override List<Component> FindComponents(By locator)
    {
        return Driver?.FindComponents(locator);
    }

    public override void Refresh()
    {
        Driver?.Refresh();
    }

    public override bool ComponentExists(Component component)
    {
        return (bool)Driver?.ComponentExists(component);
    }

    public override void DeleteAllCookies()
    {
        Driver?.DeleteAllCookies();
    }

    public override void ExecuteScript(string script, params object[] args)
    {
        Driver?.ExecuteScript(script, args);
    }
}
