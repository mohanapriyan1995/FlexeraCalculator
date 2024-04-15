using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Reflection.Metadata;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace FlexeraCalc.Pages.CalculatorPage
{
    internal class CalculatorPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public CalculatorPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private By AnnualRevenue => By.Id("AnnualRevenue");
        private By Headquarters => By.Id("Headquarters_Country");
        private By EmployeeCount => By.Id("NumberofEmployees");
        private By AnnualBudget => By.XPath("//input[@code_ref='Annual IT Budget Override - 2u92e']");
        private By NumberOfYears => By.Id("Number_of_Years");
        private By TotalProjectedSavings => By.XPath("//span[@code_ref='Grand Total Savings Low - 2u9ag']/parent::span");
        private By ModifiedAssumptionsButton => By.XPath("//button[@class='btn btn-primary assumptionsBtn']");
        private By ModifiedAssumptionsNoOfSam => By.XPath("(//input[@type='text'])[7]");
        private By ModifiedAssumptionsClick => By.XPath("//div[@id='exampleModal']");


        public void EnterInputValues(string value1, string value2, string value3, string value4, string value5)
        {

            SwitchToFrame();
            EnterValue(AnnualRevenue, value1);
            SelectDropdownByText(Headquarters, value2);
            EnterValue(EmployeeCount, value3);
            EnterValue(AnnualBudget, value4);
            SelectDropdownByText(NumberOfYears, value5);
        }

        private void SwitchToFrame()
        {
            driver.SwitchTo().Frame(0);
        }

        private void EnterValue(By locator, string value)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(value);
        }

        private void SelectDropdownByText(By locator, string text)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
            var dropdown = new SelectElement(driver.FindElement(locator));
            dropdown.SelectByText(text);
        }

        public string TotalProjectedValueCheck()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(TotalProjectedSavings));
            var ProjecteprojectedValue = driver.FindElement(TotalProjectedSavings).Text;
            return ProjecteprojectedValue;
        }

        public void ChangeModifiedAssumptions()
        {


            wait.Until(ExpectedConditions.ElementIsVisible(ModifiedAssumptionsButton));

            wait.Until(ExpectedConditions.ElementToBeClickable(ModifiedAssumptionsButton));
            driver.FindElement(ModifiedAssumptionsButton).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(ModifiedAssumptionsNoOfSam));
            driver.FindElement(ModifiedAssumptionsNoOfSam).Clear();
            driver.FindElement(ModifiedAssumptionsNoOfSam).SendKeys("4");
            driver.FindElement(ModifiedAssumptionsClick).Click();

        }


    }
}