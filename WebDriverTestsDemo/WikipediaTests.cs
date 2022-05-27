
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

// create new chrome browser instance 

var driver = new ChromeDriver();

// navigate to wikipedia 

driver.Url = "https://wikipedia.org";

System.Console.WriteLine("CURRENT TITLE: " + driver.Title);

// locate search field by ID

var searchField = driver.FindElement(By.Id("searchInput"));

// click on element

searchField.Click();

// fill QA and click enter button

searchField.SendKeys("QA");
searchField.SendKeys(Keys.Enter);

System.Console.WriteLine("TITTLE AFTER SEARCH: " + driver.Title);

// close browser

driver.Quit();


