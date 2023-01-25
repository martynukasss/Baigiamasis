using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V106.Browser;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;

namespace TestAutomationProject.TaxPages
{
    public class MethodsForTests
    {

        public string TestName = "Default Test Name";
    
        public void ClickButtonByXpath(IWebDriver driver ,string xpath)
        {
            By by = By.XPath(xpath);
            driver.FindElement(by).Click();


        }



        public void ScrollFunctionBy150 (IWebDriver driver)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            System.Threading.Thread.Sleep(1000);
            js.ExecuteScript("window.scrollBy(0,300);");

        }



        public void SendKeysByXpath(IWebDriver driver, string xpath,string text) 
        {
            driver.FindElement(By.XPath(xpath)).SendKeys(text);
        }

        public void CheckIfElementIsPresentByXpath(IWebDriver driver, string xpath)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval= TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";

            IWebElement searchResult = fluentWait.Until(x => x.FindElement(By.XPath(xpath)));



        }




        public void LoginToTax(IWebDriver driver)
        {
            ClickButtonByXpath(driver, "//button[@aria-label='Sutinku']");

            ClickButtonByXpath(driver, "//div[@class='btn-toolbar']//a[@href='/login']");
            SendKeysByXpath(driver, "//div[@class='controls']//input[@id='user_login']", "BaigiamasisTest");
            SendKeysByXpath(driver, "//div[@class='controls']//input[@id='user_password']", "123456789");
            ClickButtonByXpath(driver, "//div[@class='form-actions']//input[@class='btn btn-primary btn-large']");
            CheckIfElementIsPresentByXpath(driver, "//div[@class='alert alert-success']");


        }


        public void ForumoPaieskosTekstas(IWebDriver driver)
        {
            
            ClickButtonByXpath(driver, "//a[@href='/paieskos_forma']");
            SendKeysByXpath(driver, "//div[@class='controls']//input[@id='q']", "muzika");
            ClickButtonByXpath(driver, "//div[@class='form-actions']//input[@type='submit']");


        }



        public void AcceptPupUp(IWebDriver driver)
        {
            driver.SwitchTo().Alert().Accept();


        }

        public void SendKeysEnterByXpath(IWebDriver driver, string xpath)
        {
            driver.FindElement(By.XPath(xpath)).SendKeys(Keys.Enter);



        }
        public void tear(IWebDriver driver)
        {
            try
            {
                string time = "_" + DateTime.Now.ToString("HH:mm");
                Console.WriteLine("_" + time);
                time = time.Replace(":", "_");

                Screenshot TakeScreenShot = ((ITakesScreenshot)driver).GetScreenshot();
                TakeScreenShot.SaveAsFile("C:\\Users\\Martynas\\Documents\\Tests\\" + TestName + time + ".png");

               


            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }


            driver.Quit();


        }
    }









    }

