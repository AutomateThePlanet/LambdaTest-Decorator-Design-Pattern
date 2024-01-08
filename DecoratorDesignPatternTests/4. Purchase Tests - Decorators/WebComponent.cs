namespace DecoratorDesignPattern.FourthVersion;

public class WebComponent : Component
{
    private readonly IWebDriver _webDriver;
    private readonly Actions _actions;
    private readonly IWebElement _webElement;
    private readonly By _by;

    public WebComponent(IWebDriver webDriver, IWebElement webElement, By by)
    {
        _webDriver = webDriver;
        _actions = new Actions(_webDriver);
        _webElement = webElement;
        _by = by;
        WrappedElement = webElement;
    }

    public override By By => _by;

    public override string Text => _webElement?.Text;

    public override bool? Enabled => _webElement?.Enabled;

    public override bool? Displayed => _webElement?.Displayed;

    public override IWebElement WrappedElement { get; }

    public override void Click()
    {
        //WaitToBeClickable(By);
        _webElement?.Click();
    }

    public override string GetAttribute(string attributeName)
    {
        return _webElement?.GetAttribute(attributeName);
    }

    public override void TypeText(string text)
    {
        _webElement?.Clear();
        _webElement?.SendKeys(text);
    }

    public override void Hover()
    {
        _actions.MoveToElement(_webElement).Perform();
    }

    private void WaitToBeClickable(By by)
    {
        var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
        webDriverWait.Until(ExpectedConditions.ElementToBeClickable(by));
    }

    public override Component FindComponent(By locator)
    {
        var element = _webDriver.FindElement(locator);
        return new WebComponent(_webDriver, element, locator);
    }

    public override List<Component> FindComponents(By locator)
    {
        var elements = _webDriver.FindElements(locator);
        var components = new List<Component>();
        foreach (var element in elements)
        {
            components.Add(new WebComponent(_webDriver, element, locator));
        }
        return components;
    }
}
