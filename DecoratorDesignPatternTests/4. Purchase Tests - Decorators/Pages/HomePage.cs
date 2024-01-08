namespace DecoratorDesignPatternTests.FourthVersion;
public class HomePage : WebPage
{
    public HomePage(Driver driver) 
        : base(driver)
    {
    }

    public Component SearchInput => Driver.FindComponent(By.XPath("//input[@name='search']"));

    public void SearchProduct(string searchText)
    {
        //SearchInput.Clear();
        SearchInput.TypeText(searchText);
        //SearchInput.SendKeys(Keys.Enter);
    }
}
