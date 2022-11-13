using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace lab9_practice
{
    public class Tests
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new EdgeDriver();
            _driver.Navigate().GoToUrl("https://pastebin.com");
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void ICanWin()
        {
            _driver.FindElement(By.Id("postform-text")).SendKeys("Hello from WebDriver");
            _driver.FindElement(By.Id("select2-postform-expiration-container")).Click();
            _driver.FindElement(By.XPath("//li[text()='10 Minutes']")).Click();
            _driver.FindElement(By.Id("postform-name")).SendKeys("helloweb");
            _driver.FindElement(By.XPath("//button[@class='btn -big']")).Click();
        }

        [Test]
        public void BringItOn()
        {
            _driver.FindElement(By.Id("postform-text")).SendKeys("git config --global user.name  \"New Sheriff in Town\" " +
                "\ngit reset $(git commit - tree HEAD ^{ tree} -m \"Legacy code\") \ngit push origin master --force");
            _driver.FindElement(By.Id("select2-postform-format-container")).Click();
            _driver.FindElement(By.XPath("//li[text()='Bash']")).Click();

            _driver.FindElement(By.Id("select2-postform-expiration-container")).Click();
            _driver.FindElement(By.XPath("//li[text()='10 Minutes']")).Click();

            _driver.FindElement(By.Id("postform-name")).SendKeys("how to gain dominance among developers");

            _driver.FindElement(By.XPath("//button[@class='btn -big']")).Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            IWebElement syntaxHighlighting = _driver.FindElement(By.XPath("//a[text()='Bash']"));
            IWebElement codeFirstLine = _driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/ol/li[1]/div/span[1]"));
            IWebElement codeSecondLine = _driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/ol/li[2]/div/span[1]"));
            IWebElement codeThirdLine = _driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/ol/li[3]/div/span[1]"));

            Assert.That(_driver.Title, Is.EqualTo("how to gain dominance among developers - Pastebin.com"));
            Assert.That(syntaxHighlighting.Text, Is.EqualTo("Bash"));
            Assert.That(codeFirstLine.Text, Is.EqualTo("git config"));
            Assert.That(codeSecondLine.Text, Is.EqualTo("git reset"));
            Assert.That(codeThirdLine.Text, Is.EqualTo("git push"));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}