using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationProject.TaxPages
{
    internal class driverController
    {
        public IWebDriver driver;


        public driverController()
            {
              driver = new ChromeDriver();
            }
        }
    }

