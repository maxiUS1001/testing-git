using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace lab9
{
    public class Tests
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new EdgeDriver();
            _driver.Navigate().GoToUrl("https://www.agoda.com/?cid=1844104");
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void SearchForFlightToParisFromVilnius()
        {
            _driver.FindElement(By.XPath("//span[text()='Авиабилеты']")).Click();

            _driver.FindElement(By.XPath("//span[text()='One-way']")).Click();

            _driver.FindElement(By.XPath("//input[@name='origin']")).Clear();
            _driver.FindElement(By.XPath("//input[@name='origin']")).SendKeys("Vilnius(VNO)");
            
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.FindElement(By.XPath("//*[@id='ap-VNO/7110']/div[2]")).Click();

            _driver.FindElement(By.XPath("//input[@name='destination']")).SendKeys("Paris (PAR)");

            _driver.FindElement(By.XPath("//*[@id='ap-PAR/36014']/div[2]")).Click();

            _driver.FindElement(By.XPath("//div[text()='Depart']")).Click();

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.FindElement(By.XPath("//div[@aria-label='December 14']")).Click();

            _driver.FindElement(By.XPath("//span[text()='Search']")).Click();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}