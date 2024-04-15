using FlexeraCalc.Pages.CalculatorPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;


namespace FlexeraCalc.Tests
{
    [TestFixture]
    public class Calculator : IDisposable
    {
        private IWebDriver driver;
        private CalculatorPage calculatorPage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            calculatorPage = new CalculatorPage(driver);
        }

        [Test]
        public void ValidateModifiedAssumptions()
        {

            driver.Navigate().GoToUrl("https://www.flexera.com/flexera-one/business-value-calculator");
            calculatorPage.EnterInputValues("3000000", "France", "5000", "5000000", "3 years");
            calculatorPage.ChangeModifiedAssumptions();
            var Totalprojectedsavings = calculatorPage.TotalProjectedValueCheck();
            Assert.That(Totalprojectedsavings, Is.EqualTo("$7M to $18.5M"));
        }

        [Test]
        public void TestPositiveScenario()
        {
            driver.Navigate().GoToUrl("https://www.flexera.com/flexera-one/business-value-calculator");
            calculatorPage.EnterInputValues("3000000", "France", "5000", "5000000", "3 years");
            var Totalprojectedsavings = calculatorPage.TotalProjectedValueCheck();
            Assert.That(Totalprojectedsavings, Is.EqualTo("$6.6M to $17.7M"));
        }


        [TearDown]
        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}