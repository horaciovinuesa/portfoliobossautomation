//******************************************************************************
// PORFTOLIO BOSS TEST SUITE
//******************************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace PortfolioBossTest
{
    public class PortfolioBossSession
    {
        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string PbAppId = @"C:\Users\Usuario\AppData\Local\PortfolioBoss\Application\PortfolioBoss.exe";

        protected static WindowsDriver<WindowsElement> session;
        protected static WindowsElement settingsButton;

        public static void Setup(TestContext context)
        {
            // Launch a new instance of PB application
            if (session == null)
            {
                // Create a new session to launch Notepad application
                DesiredCapabilities appCapabilities = new DesiredCapabilities();
                appCapabilities.SetCapability("app", PbAppId);
                session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);

                Thread.Sleep(TimeSpan.FromSeconds(2));

                Assert.IsNotNull(session);
                Assert.IsNotNull(session.SessionId);

                // Verify that Notepad is started with untitled new file
                Assert.AreEqual("Portfolio Boss", session.Title);

                // Set implicit timeout to 1.5 seconds to make element search to retry every 500 ms for at most three times
                session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                // Keep track of the settings button to be used throughout the session
                settingsButton = session.FindElementByAccessibilityId("ShowSettingsView");
                
                Assert.IsNotNull(settingsButton);
            }
        }
        
        public static void TearDown()
        {
            // Close the application and delete the session
            if (session != null)
            {
                session.Close();
                session.Quit();
                session = null;
            }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            // Verify Settings button is present 
            Assert.AreEqual("Settings", settingsButton.Text);
        }
    }
}