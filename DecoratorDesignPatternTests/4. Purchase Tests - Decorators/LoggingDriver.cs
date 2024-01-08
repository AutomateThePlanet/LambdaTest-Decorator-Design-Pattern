namespace DecoratorDesignPattern.FourthVersion;

public class LoggingDriver : DriverDecorator
{
    public override string Url => throw new NotImplementedException();

    public LoggingDriver(Driver driver)
    : base(driver)
    {
    }

    public override void Quit()
    {
        Console.WriteLine("Close browser");
        Driver?.Quit();
    }

    public override void GoToUrl(string url)
    {
        Console.WriteLine($"Go to URL = {url}");
        Driver?.GoToUrl(url);
    }

    public override Component FindComponent(By locator)
    {
        Console.WriteLine($"Find Element -> by {locator}");
        return Driver?.FindComponent(locator);
    }

    public override List<Component> FindComponents(By locator)
    {
        Console.WriteLine($"Find elements -> by {locator}");
        return Driver?.FindComponents(locator);
    }

    public override void Refresh()
    {
        Console.WriteLine("refresh");
        Driver?.Refresh();
    }

    public override bool ComponentExists(Component component)
    {
        Console.WriteLine("check if the component exists");
        return (bool)Driver?.ComponentExists(component);
    }
}
