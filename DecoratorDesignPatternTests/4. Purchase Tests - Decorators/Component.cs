namespace DecoratorDesignPattern.FourthVersion;

public abstract class Component 
{
    public abstract By By { get; }
    public abstract IWebElement WrappedElement { get; }
    public abstract string Text { get; }
    public abstract bool? Enabled { get; }
    public abstract bool? Displayed { get; }
    public abstract void TypeText(string text);
    public abstract void Click();
    public abstract string GetAttribute(string attributeName);
    public abstract void Hover();
    public abstract Component FindComponent(By locator);
    public abstract List<Component> FindComponents(By locator);
}
