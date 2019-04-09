//******************************************************************************
// PORFTOLIO BOSS TEST SUITE
// Portfolio management section
// Tests have not been defined nor developed yet, this is a placeholder
//******************************************************************************


using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PortfolioBossTest
{
    [TestClass]
    public class ScenarioMenuItem : PortfolioBossSession
    {
        [TestMethod]
        public void MenuItemEdit()
        {
            // Select Edit -> Time/Date to get Time/Date
            Assert.AreEqual(string.Empty, settingsButton.Text);
            session.FindElementByName("Edit").Click();
            session.FindElementByXPath($"//MenuItem[starts-with(@Name, \"Time/Date\")]").Click();
            string timeDateString = settingsButton.Text;
            Assert.AreNotEqual(string.Empty, timeDateString);

            // Select all text, copy, and paste it twice using MenuItem Edit -> Select All, Copy, and Paste
            session.FindElementByName("Edit").Click();
            session.FindElementByXPath($"//MenuItem[starts-with(@Name, \"Select All\")]").Click();
            session.FindElementByName("Edit").Click();
            session.FindElementByXPath($"//MenuItem[starts-with(@Name, \"Copy\")]").Click();
            session.FindElementByName("Edit").Click();
            session.FindElementByXPath($"//MenuItem[starts-with(@Name, \"Paste\")]").Click();
            session.FindElementByName("Edit").Click();
            session.FindElementByXPath($"//MenuItem[starts-with(@Name, \"Paste\")]").Click();

            // Verify that the Time/Date string is duplicated
            Assert.AreEqual(timeDateString + timeDateString, settingsButton.Text);
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Setup(context);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TearDown();
        }
    }
}
