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
using NUnit.Allure.Core;
using Allure.Commons;
using NUnit.Allure.Attributes;

namespace testSGrid;
[TestFixture]
[AllureNUnit]

public class Tests
{
    private IWebDriver driver;
    string hubUrl;
    public IDictionary<string, object> vars { get; private set; }
    private IJavaScriptExecutor js;

    [SetUp]
    public void Setup()
    {
        AllureLifecycle.Instance.CleanupResultDirectory();
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
    [Category("SampleTag")]
    [Description("Test1")]
    [AllureTag("NUnit", "Debug")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureFeature("Core")]
    public void OpenGoogleAndSearch()
    {
        driver.Navigate().GoToUrl("https://www.google.com");
        driver.Manage().Window.Maximize();
        driver.FindElement(By.Name("q")).SendKeys("I Want to see this on a remote machine");
        string text = driver.FindElement(By.XPath("//a[@class='spell_orig']")).Text;
        AllureLifecycle.Instance.WrapInStep(() =>
        {
            Assert.Equals("I Want to see this on a remote machine", text);
        }, "Google Search");
    }

    /*[Test]
    [Parallelizable]
    [Category("SampleTag")]
    [Description("Test2")]
    [AllureTag("NUnit", "Debug")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureFeature("Core")]
    public void OpenBingAndSearch()
    {
        driver.Navigate().GoToUrl("https://www.bing.com/");
        driver.Manage().Window.Maximize();
        driver.FindElement(By.Name("q")).SendKeys("I Want to see this on a remote machine");
    }*/



}