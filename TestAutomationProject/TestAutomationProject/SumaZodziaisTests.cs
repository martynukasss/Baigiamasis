using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using TestAutomationProject.TaxPages;

namespace TestAutomationProject
{
    internal class SumaZodziaisTests : MethodsForTests
    {
        driverController controller;


        [SetUp]
        public void SetUp()
        {
            controller = new driverController();
            controller.driver.Manage().Window.Maximize();
            controller.driver.Url = "https://www.tax.lt/skaiciuokles/suma_zodziais";
        }

        [Test]

        public void FieldPositiveTesting()
        {
            TestName = "Teisingos informacijos ivedimas i lauka";

            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
            SendKeysByXpath(controller.driver, "//input[@id='amount']", "100");
            CheckIfElementIsPresentByXpath(controller.driver, "//div[@id='amount_in_words' and contains(text(),'šimtas eurų 0 ct')]");


        }

        [Test]

        public void FieldNegativeWordTesting()
        {
            TestName = "Zodziu ivedimo i lauka testas";

            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
            SendKeysByXpath(controller.driver, "//input[@id='amount']", "zodis");
            CheckIfElementIsPresentByXpath(controller.driver, "//div[@id='amount_in_words' and contains(text(),'nulis 0 ct')]");




        }

        [Test]

        public void FieldNegativeTestingSymbols()
        {
            TestName = "Simboliu ivedimo i lauka testas";

            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
            SendKeysByXpath(controller.driver, "//input[@id='amount']", "!@#$%^&*");
            CheckIfElementIsPresentByXpath(controller.driver, "//div[@id='amount_in_words' and contains(text(),'nulis 0 ct')]");




        }

        [TearDown]
        public void TearDown()
        {
            tear(controller.driver);
        }





    }
}

