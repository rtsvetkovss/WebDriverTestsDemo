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
            this.driver = new ChromeDriver();
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
            string expectedTitle = "�������� �� ������������ - ��������� �����������";
            // assert
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));
           

        }
        [Test]
        public void TestAssertAboutUsPageTitle()
        {
            // arrange        

            // act
           
            var ZaNasElement = driver.FindElement(By.CssSelector("#header-nav > div.toggle-nav.toggle-holder > ul > li:nth-child(1) > a > span"));
            ZaNasElement.Click();
            string expectedTitle = "�� ��� - ��������� �����������";
            
            // assert
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));
            

        }
    }
}