using DecoratorDesignPatternTests.Models;

namespace DecoratorDesignPatternTests.FourthVersion;
public class CheckoutPage : WebPage
{
    public CheckoutPage(Driver driver) 
        : base(driver)
    {
    }

    public Component FirstNameInput => Driver.FindComponent(By.Id("input-payment-firstname"));
    public Component LastNameInput => Driver.FindComponent(By.Id("input-payment-lastname"));
    public Component EmailInput => Driver.FindComponent(By.Id("input-payment-email"));
    public Component TelephoneInput => Driver.FindComponent(By.Id("input-payment-telephone"));
    public Component PasswordInput => Driver.FindComponent(By.Id("input-payment-password"));
    public Component ConfirmPasswordInput => Driver.FindComponent(By.Id("input-payment-confirm"));
    public Component CompanyInput => Driver.FindComponent(By.Id("input-payment-company"));
    public Component Address1Input => Driver.FindComponent(By.Id("input-payment-address-1"));
    public Component Address2Input => Driver.FindComponent(By.Id("input-payment-address-2"));
    public Component CityInput => Driver.FindComponent(By.Id("input-payment-city"));
    public Component PostCodeInput => Driver.FindComponent(By.Id("input-payment-postcode"));
    public Component ShippingAddressCountrySelect => Driver.FindComponent(By.Id("input-payment-country"));
    public Component ShippingAddressCountryOption(string country) =>
        ShippingAddressCountrySelect.FindComponent(By.XPath($".//option[contains(text(), '{country}')]"));
    public Component BillingAddressRegionSelect => Driver.FindComponent(By.Id("input-payment-zone"));
    public Component BillingAddressRegionOption(string region) =>
        BillingAddressRegionSelect.FindComponent(By.XPath($".//option[contains(text(), '{region}')]"));
    public Component TermsAgreeCheckbox => Driver.FindComponent(By.XPath("//input[@id='input-agree']//following-sibling::label"));
    public Component ContinueButton => Driver.FindComponent(By.XPath("//button[@id='button-save']"));
    public Component TotalPrice => Driver.FindComponents(By.XPath("//td[text()='Total:']/following-sibling::td/strong")).Last();

    public void FillUserDetails(UserDetails userDetails)
    {
        FirstNameInput.TypeText(userDetails.FirstName);
        LastNameInput.TypeText(userDetails.LastName);
        EmailInput.TypeText(userDetails.Email);
        TelephoneInput.TypeText(userDetails.Telephone);
        PasswordInput.TypeText(userDetails.Password);
        ConfirmPasswordInput.TypeText(userDetails.ConfirmPassword);
    }

    public void FillBillingAddress(BillingAddress billingAddress)
    {
        CompanyInput.TypeText(billingAddress.Company);
        Address1Input.TypeText(billingAddress.Address1);
        Address2Input.TypeText(billingAddress.Address2);
        CityInput.TypeText(billingAddress.City);
        PostCodeInput.TypeText(billingAddress.PostCode);
        ShippingAddressCountrySelect.Click();
        ShippingAddressCountryOption(billingAddress.Country).Click();
        BillingAddressRegionSelect.Click();
        BillingAddressRegionOption(billingAddress.Region).Click();
    }

    public void AgreeToTerms()
    {
        // TODO: Move to Driver as addition to FindComponent as decoratr
        // TODO: Add addtional decorator for highlighting element
        ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", TermsAgreeCheckbox);
        TermsAgreeCheckbox.Click();
    }

    public void ClickContinue()
    {
        ContinueButton.Click();
    }

    public void AssertTotalPrice(string expectedPrice)
    {
        Assert.That(TotalPrice.Text, Is.EqualTo(expectedPrice));
    }

    public void CompleteCheckout()
    {
        var continueButton = Driver.FindComponent(By.XPath("//button[@id='button-save']"));
        continueButton.Click();
    }
}
