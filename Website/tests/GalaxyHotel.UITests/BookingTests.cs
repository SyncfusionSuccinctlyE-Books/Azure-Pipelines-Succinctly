using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GalaxyHotel.UITests
{
    [TestClass]
    public class BookingTests
    {
        private IWebDriver webDriver;
        private string baseUrl;

        public TestContext TestContext { get; set; }

        [TestMethod]
        [TestCategory("Chrome")]
        public void BookARoomAndCheckForConfirmationTest()
        {
            webDriver.Navigate().GoToUrl(baseUrl);
            webDriver.FindElement(By.LinkText("Book")).Click();

            var bookingConfirmationText = webDriver.FindElement(By.XPath("//h1")).Text;

            Assert.AreEqual("Room booked!", bookingConfirmationText);
        }

        [TestInitialize()]
        public void SetupTest()
        {
            baseUrl = TestContext.Properties["baseUrl"].ToString();
            webDriver = new ChromeDriver();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            webDriver.Quit();
            webDriver.Dispose();
            webDriver = null;
        }
    }
}
