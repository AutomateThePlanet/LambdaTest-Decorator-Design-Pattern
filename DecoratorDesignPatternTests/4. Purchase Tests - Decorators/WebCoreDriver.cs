using System.Collections.ObjectModel;
using AngleSharp.Dom;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace DecoratorDesignPattern.FourthVersion;

public class WebCoreDriver : Driver
{
    private IWebDriver _webDriver;
    private WebDriverWait _webDriverWait;

    public override string Url => _webDriver.Url;

    public override void Start(Browser browser)
    {
        switch (browser)
        {
            case Browser.Chrome:
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                _webDriver = new ChromeDriver();
                break;
            case Browser.Firefox:
                new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                _webDriver = new FirefoxDriver();
                break;
            case Browser.Edge:
                new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                _webDriver = new EdgeDriver();
                break;
            case Browser.Safari:
                _webDriver = new SafariDriver();
                break;
            case Browser.InternetExplorer:
                new WebDriverManager.DriverManager().SetUpDriver(new InternetExplorerConfig());
                _webDriver = new InternetExplorerDriver();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
        }

        _webDriver.Manage().Window.Maximize();
        _webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
    }

    public override void Quit()
    {
        _webDriver.Quit();
    }

    public override void GoToUrl(string url)
    {
        _webDriver.Navigate().GoToUrl(url);
    }

    public override Component FindComponent(By locator)
    {
        IWebElement nativeWebElement = 
            _webDriverWait.Until(ExpectedConditions.ElementExists(locator));
        Component element = new WebComponent(_webDriver, nativeWebElement, locator);

        // If we use log decorator.
        Component logElement = new LogComponent(element);

        return logElement;
    }

    public override List<Component> FindComponents(By locator)
    {
        ReadOnlyCollection<IWebElement> nativeWebElements = 
            _webDriverWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
        var elements = new List<Component>();
        foreach (var nativeWebElement in nativeWebElements)
        {
            Component element = new WebComponent(_webDriver, nativeWebElement, locator);
            elements.Add(element);
        }

        return elements;
    }

    public override void Refresh()
    {
        _webDriver.Navigate().Refresh();
    }

    public override bool ComponentExists(Component component)
    {
        try
        {
            _webDriver.FindElement(component.By);

            return true;
        }
        catch
        {
            // The component was not found
            return false;
        }
    }

    public override void DeleteAllCookies()
    {
        _webDriver.Manage().Cookies.DeleteAllCookies();
    }

    public override void ExecuteScript(string script, params object[] args)
    {
        ((IJavaScriptExecutor)_webDriver).ExecuteScript(script, args);
    }
}
