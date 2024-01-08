namespace DecoratorDesignPattern.FourthVersion;

public abstract class ComponentDecorator : Component
{
    protected readonly Component Element;

    protected ComponentDecorator(Component element)
    {
        Element = element;
    }

    public override By By => Element?.By;
    public override IWebElement WrappedElement => Element?.WrappedElement;

    public override string Text => Element?.Text;

    public override bool? Enabled => Element?.Enabled;

    public override bool? Displayed => Element?.Displayed;

    public override void Click()
    {
        Element?.Click();
    }

    public override string GetAttribute(string attributeName)
    {
        return Element?.GetAttribute(attributeName);
    }

    public override void TypeText(string text)
    {
        Element?.TypeText(text);
    }
}
