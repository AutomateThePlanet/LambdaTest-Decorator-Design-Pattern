﻿using DecoratorDesignPatternTests.Models;

namespace DecoratorDesignPatternTests.FourthVersion;

public class ProductPage : WebPage
{
    public ProductPage(Driver driver) 
        : base(driver)
    {
    }

    public Component AddToCartButton => Driver.FindComponents(By.XPath("//button[@title='Add to Cart']")).Last();
    public Component CompareButton => Driver.FindComponent(By.XPath("//a[@aria-label='Compare']"));
    public Component QuantityField => Driver.FindComponents(By.XPath("//input[@name='quantity']")).Last();
    public IReadOnlyCollection<Component> CompareProductButtons => Driver.FindComponents(By.XPath("//button[@title='Compare this Product']"));

    public void SelectProductFromAutocomplete(int productId)
    {
        var autocompleteItemXPath = $"//ul[contains(@class, 'dropdown-menu autocomplete')]/li/div/h4/a[contains(@href, 'product_id={productId}')]";
        var autocompleteItem = Driver.FindComponent(By.XPath(autocompleteItemXPath));
        autocompleteItem.Click();
    }

    public void AddToCart(string quantity)
    {
        //QuantityField.Clear();
        QuantityField.TypeText(quantity);
        AddToCartButton.Click();
    }

    public void CompareLastProduct()
    {
        CompareProductButtons.Last().Click();
    }

    public void GoToComparePage()
    {
        CompareButton.Click();
    }

    public void AssertCompareProductDetails(ProductDetails expectedProduct, int index)
    {
        var productName = Driver.FindComponent(By.XPath(GetCompareProductDetailsCellXPath("Product", index)));
        Assert.That(productName.Text, Is.EqualTo(expectedProduct.Name));
        // Add more assertions for Price, Model, Brand, Weight, etc.
    }

    private string GetCompareProductDetailsCellXPath(string cellName, int productCompareIndex)
    {
        return $"//table/tbody/tr/td[text()='{cellName}']/following-sibling::td[{productCompareIndex}]";
    }
}
