namespace DecoratorDesignPatternTests.FourthVersion;
public abstract class WebPage
{
    protected readonly Driver Driver;

    public WebPage(Driver driver)
    {
        Driver = driver;
    }
}
