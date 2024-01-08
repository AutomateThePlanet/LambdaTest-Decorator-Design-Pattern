namespace DecoratorDesignPattern.FourthVersion;

public class ScrollIntoViewDriver : DriverDecorator
{
    public override string Url => throw new NotImplementedException();

    public ScrollIntoViewDriver(Driver driver)
    : base(driver)
    {
    }
   
    public override Component FindComponent(By locator)
    {
        var element = Driver?.FindComponent(locator);
        ScrollIntoView(element);
        return element;
    }

    public override List<Component> FindComponents(By locator)
    {
        var elements =  Driver?.FindComponents(locator);
        if (elements.Any())
        {
            ScrollIntoView(elements.Last());
        }
        return elements;
    }

    private void ScrollIntoView(Component element)
    {
        Driver.ExecuteScript("arguments[0].scrollIntoView(true);", element.WrappedElement);
    }
}
