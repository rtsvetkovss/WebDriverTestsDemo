using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NunitWebDriverTests
{
    public class SoftUniTests
    {
        private WebDriver driver;

        [OneTimeSetUp]
        public void OpenBrowserAndNavigate()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");


            this.driver = new ChromeDriver(options);
            driver.Url = "https://softuni.bg/";
            driver.Manage().Window.Maximize();

        }

        [OneTimeTearDown]

        public void ShutDown()
        {
            driver.Quit();
        }

        [Test]

        public void TestAssertMainPageTitle()
        {
            // arrange
            // act
            driver.Url = "https://softuni.bg/";
            string expectedTitle = "Обучение по програмиране - Софтуерен университет";
            // assert
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));


        }
        [Test]
        public void TestAssertAboutUsPageTitle()
        {
            // arrange        
            driver.Url = "https://softuni.bg/";
            // act

            var ZaNasElement = driver.FindElement(By.CssSelector("#header-nav > div.toggle-nav.toggle-holder > ul > li:nth-child(1) > a > span"));
            ZaNasElement.Click();
            string expectedTitle = "За нас - Софтуерен университет";

            // assert
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));


        }
        [Test]
        public void Test_Login_InvalidUsernameAndPassword()

        //locate username field by ID
        //var usernameField = driver.FindElement(by.ID("username"));
        //udernameField.Click();
        // или IWebElement usernameField = driver.FindElement(by.ID("username"));
        {
            driver.FindElement(By.CssSelector(".softuni-btn-primary")).Click();
            driver.FindElement(By.CssSelector(".login-page-form-content")).Click();
            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.Id("username")).SendKeys("user1");
            driver.FindElement(By.Id("password-input")).SendKeys("user1");
            driver.FindElement(By.CssSelector(".softuni-btn")).Click();
            driver.FindElement(By.CssSelector("li")).Click();
            Assert.That(driver.FindElement(By.CssSelector("li")).Text, Is.EqualTo("Невалидно потребителско име или парола"));
            driver.Close();
        }
    }
    
}