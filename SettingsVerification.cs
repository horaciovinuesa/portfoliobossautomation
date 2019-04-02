//******************************************************************************
//
// Copyright (c) 2017 Microsoft Corporation. All rights reserved.
//
// This code is licensed under the MIT License (MIT).
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
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
        protected static WindowsElement automationContent, appearanceContent, databaseContent, interactiveBrokersContent, miscellaneousContent;

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
            // Get the text content for every section on the settings
            // Find the elements and assert them, after, click on next one and continue
            // Only content verification, actions will be done on a separate test
            automationContent = session.FindElementByName("AUTOMATION");
            appearanceContent = session.FindElementByName("APPEARANCE");
            databaseContent = session.FindElementByName("DATABASE");
            interactiveBrokersContent = session.FindElementByName("INTERACTIVE BROKERS");
            miscellaneousContent = session.FindElementByName("MISCELLANEOUS");

            //Assert the contents are the expected
            Debug.WriteLine(automationContent);
            Debug.WriteLine(appearanceContent);
            Debug.WriteLine(databaseContent);
            Debug.WriteLine(interactiveBrokersContent);
            Debug.WriteLine(miscellaneousContent);

        }

        [TestMethod]
        public void SettingsInteractions()
        {
            // Press F5 to get Time/Date from Notepad
            Assert.AreEqual(string.Empty, settingsButton.Text);
            settingsButton.SendKeys(Keys.F5);
            Assert.AreNotEqual(string.Empty, settingsButton.Text);
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
