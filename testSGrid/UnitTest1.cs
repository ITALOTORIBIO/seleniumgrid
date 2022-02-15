using NUnit.Framework;
using testSGrid.Factories;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
namespace testSGrid;

public class Tests
{
    private IWebDriver driver;
        string hubUrl;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;
 
        [SetUp]
        public void Setup()
        {
            vars = new Dictionary<string, object>();
 
            hubUrl = "http://localhost:4444/wd/hub";
            driver = LocalDriverFactory.CreateInstance(Enums.BrowserType.Chrome, hubUrl);
            js = (IJavaScriptExecutor)driver;
        }
 
        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }
 
        [Test]
        [Parallelizable]
        public void OpenGoogleAndSearch()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Name("q")).SendKeys("I Want to se this on a remote machine");
        }
 
        
 
        
}