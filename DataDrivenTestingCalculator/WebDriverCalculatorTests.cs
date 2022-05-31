using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DataDrivenTestingCalculator
{
    public class WebDriverCalculatorTests
    {
        private ChromeDriver driver;
        IWebElement field1;

        [OneTimeSetUp]
        public void OpenAndNavigate()
        {         
            this.driver = new ChromeDriver();
            driver.Url = "https://number-calculator.nakov.repl.co/";

        }
        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }
        

        [TestCase("5", "6", "+", "Result: 11" )]
        [TestCase("15", "6", "-", "Result: 9" )]
        [TestCase("15", "1", "-", "Result: 14" )]
        [TestCase("asdasdasd", "asdasdasdas", "-", "Result: invalid input" )]
        public void Test_Calculator(string num1, string num2, string operato, string result)
        {   // arrange
            field1 = driver.FindElement(By.Id("number1"));
            var field2 = driver.FindElement(By.Id("number2"));
            var operation = driver.FindElement(By.Id("operation"));
            var calculate = driver.FindElement(By.Id("calcButton"));
            var resultField = driver.FindElement(By.Id("result"));
            var clearField = driver.FindElement(By.Id("resetButton"));
            // act
            field1.SendKeys(num1);
            operation.SendKeys(operato);
            field2.SendKeys(num2);

            calculate.Click();


            Assert.That(result, Is.EqualTo(resultField.Text));

            clearField.Click(); 

        }
    }
}