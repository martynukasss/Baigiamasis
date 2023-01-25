using NUnit.Framework;
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
    public class ForumTests:MethodsForTests
    {
        driverController controller;
       

        [SetUp]
        public void SetUp()
        {
            controller = new driverController();
            controller.driver.Manage().Window.Maximize();
            controller.driver.Url = "https://www.tax.lt/";
        }
        [Test]
        public void ForumoPaieskosTestas()
        {
            TestName = "Forumo Paieskos Testas";
            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
            ClickButtonByXpath(controller.driver, "//a[@href='/paieskos_forma']");
            SendKeysByXpath(controller.driver, "//div[@class='controls']//input[@id='q']", "alga");
            ClickButtonByXpath(controller.driver, "//div[@class='form-actions']//input[@type='submit']");
            CheckIfElementIsPresentByXpath(controller.driver, "//h3[contains(text(),'alga')]");

        }


        [Test]
        public void TemosPridejimasIfavoritus()
        {
            TestName = "Temos pridejimas i favoritus";

            LoginToTax(controller.driver);
            ForumoPaieskosTekstas(controller.driver);
            ClickButtonByXpath(controller.driver, "//a[@href='/temos/1603-muzika']");
            ClickButtonByXpath(controller.driver, "//a[@id='favorite_button']");
            ClickButtonByXpath(controller.driver, "//a[@href='/forumai']");
            ClickButtonByXpath(controller.driver, "//a[@href='/forum_favorites']");
            CheckIfElementIsPresentByXpath(controller.driver, "//a[@href='/temos/1603-muzika']");


        }

        [Test]

        public void NaujosTemosKurimoTestas()
        {
            TestName = "Naujos Temos Kurimo Testas";

            LoginToTax(controller.driver);
            ClickButtonByXpath(controller.driver, "//a[@href='/forumai']");
            ClickButtonByXpath(controller.driver, "//a[@href='/forumai/23-blevyzgos']");
            ClickButtonByXpath(controller.driver, "//a[@href='/temos/nauja?forum_id=23']");
            SendKeysByXpath(controller.driver, "//input[@id='forum_topic_topic_name']", "Kiek uzdirba informatikai ?");
            SendKeysByXpath(controller.driver, "//textarea[@id='forum_topic_forum_posts_attributes_0_post_text']", "Kiek jusu manymu uzdirba IT sferoje?");
            ClickButtonByXpath(controller.driver, "//input[@type='submit']");
            CheckIfElementIsPresentByXpath(controller.driver, "//h1[contains(text(),'Kiek')]");
        }

        [TearDown]
        public void TearDown()
        {
            tear(controller.driver);
        }




    }
}