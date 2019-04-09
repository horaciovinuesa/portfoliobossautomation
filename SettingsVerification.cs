//******************************************************************************
// PORFTOLIO BOSS 
// Settings section tests 
//******************************************************************************


using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;
using System;
using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;
using System.Diagnostics;

namespace PortfolioBossTest
{
    [TestClass]
    public class SettingsVerification : PortfolioBossSession
    {
        protected static WindowsElement automationEntry, appearanceEntry, databaseEntry, interactiveBrokersEntry, miscellaneousEntry;
        protected static WindowsElement automationContent, appearanceContentTheme, appearanceContentScale, appearanceContentColorSel, databaseContent, interactiveBrokersContent, miscellaneousContent;

        [TestMethod]
        public void VerifySettingsSection()
        {
            // Verify that the settings section is present and all the options are in place
            Assert.IsNotNull(settingsButton);
            settingsButton.Click();

            //Check for all the settings menu entries
            automationEntry = session.FindElementByName("AUTOMATION");
            appearanceEntry = session.FindElementByName("APPEARANCE");
            databaseEntry = session.FindElementByName("DATABASE");
            interactiveBrokersEntry = session.FindElementByName("INTERACTIVE BROKERS");
            miscellaneousEntry = session.FindElementByName("MISCELLANEOUS");
            
            //Assert the menu entries
            Assert.IsNotNull(automationEntry);
            Assert.IsNotNull(appearanceEntry);
            Assert.IsNotNull(databaseEntry);
            Assert.IsNotNull(interactiveBrokersEntry);
            Assert.IsNotNull(miscellaneousEntry);

            Trace.WriteLine("Settings menu verified");
            Thread.Sleep(2000);
        }

        [TestMethod]
        public void VerifySettingsSectionContent()
        {
            //Access the settings section 
            Assert.IsNotNull(settingsButton);
            settingsButton.Click();

            // Get the text content for every section on the settings
            automationEntry.Click();
            automationContent = session.FindElementByAccessibilityId("NewEmailAddress");
            
            appearanceEntry.Click();
            appearanceContentTheme = session.FindElementByName("Theme");
            appearanceContentScale = session.FindElementByName("Scale");
            appearanceContentColorSel = session.FindElementByName("#FFA4C400");
            
            databaseEntry.Click();
            databaseContent = session.FindElementByName("Open database folder");
            
            interactiveBrokersEntry.Click();
            interactiveBrokersContent = session.FindElementByName("Connect to IB Trader Workstation");
            
            miscellaneousEntry.Click();
            miscellaneousContent = session.FindElementByAccessibilityId("ResetUI");
            
            //Assert the contents are not empty on any section
            Assert.IsNotNull(miscellaneousContent);
            Assert.IsNotNull(interactiveBrokersContent);
            Assert.IsNotNull(databaseContent);
            Assert.IsNotNull(interactiveBrokersContent);
            Assert.IsNotNull(appearanceContentTheme);
            Assert.IsNotNull(appearanceContentScale);
            Assert.IsNotNull(appearanceContentColorSel);
            Assert.IsNotNull(automationContent);

        }

        [TestMethod]
        public void SettingsInteractions()
        {
            //Access the settings section 
            Assert.IsNotNull(settingsButton);
            settingsButton.Click();
            
            //TODO
            //Verify entering a new email address
            //Verify duplicating email address
            //Verify that no more than 3 email addresses can be entered
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
