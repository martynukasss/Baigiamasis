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
    internal class AtlyginimoSkaiciuoklesTests : MethodsForTests
    {
        driverController controller;


        [SetUp]
        public void SetUp()
        {
            controller = new driverController();
            controller.driver.Manage().Window.Maximize();
            controller.driver.Url = "https://www.tax.lt/skaiciuokles/atlyginimo_ir_mokesciu_skaiciuokle";
        }

        [Test]
        public void AntPopieriausLaukelioNegativeTest()
        {
            TestName = "Ant Popieriaus Laukelio Negative Testas";

            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
            ScrollFunctionBy150(controller.driver);
            SendKeysByXpath(controller.driver, "//div[@class='controls']//input[@class='input-medium bold_text']", "!@#$%^");
            CheckIfElementIsPresentByXpath(controller.driver, "//table[@id='calculator_table']//*[contains(text(),'0,00 €')]");
        }

        [Test]
        public void AntPopieriausLaukelioPositiveTest()
        {
            TestName = "Ant Popieriaus Laukelio Positive Testas";

            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
            ScrollFunctionBy150(controller.driver);
            SendKeysByXpath(controller.driver, "//div[@class='controls']//input[@class='input-medium bold_text']", "1500");
            CheckIfElementIsPresentByXpath(controller.driver, "//table[@id='calculator_table']//*[contains(text(),'1 500,00 €')]");
        }


        [Test]
        public void MokesciuSkaiciuoklesMygtukuTestas()
        {
            TestName = "Mokesciu Skaiciuokles Mygtuku Testas";

            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
            ClickButtonByXpath(controller.driver, "//div[@class='controls']//input[@id='papildomas_pensijos_kaupimas']");
            CheckIfElementIsPresentByXpath(controller.driver, "//div[@id='papildomas_pensijos_kaupimas_procentai_div' and @style='display: block;']");
            ClickButtonByXpath(controller.driver, "//input[@id='koks_atl_2']");
            CheckIfElementIsPresentByXpath(controller.driver, "//div[@class='alert alert-block alert-info']//*[contains(text(),'rankas')]");
            ClickButtonByXpath(controller.driver, "//input[@id='paskaiciuoti_npd_2']");
            CheckIfElementIsPresentByXpath(controller.driver, "//div[@id='npd_sum' and @style='display: block;']");
        }



        [TearDown]
        public void TearDown()
        {
            tear(controller.driver);
        }






    }
}
