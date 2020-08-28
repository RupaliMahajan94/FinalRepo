using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject1
{
    [TestClass]
    public class FirstTestCase
    {
        [TestMethod]
        public void SignupMethod()
        {

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://jt-dev.azurewebsites.net/#/SignIn");
            driver.Manage().Window.Maximize();
            String ActualResult;
            String ExpectedResult = "Jabatalks";
            ActualResult = driver.Title;
            if(ActualResult.Contains(ExpectedResult))
            {
                Console.WriteLine("Test case Passed");
                Assert.IsTrue(true, "test case passed");
            }
            else
            {
                Console.WriteLine("Test case failed");
            }

            driver.FindElement(By.XPath("//a[contains(.,'Register')]")).Click();

            //Language verification 

            driver.FindElement(By.XPath("(//i[contains(@class,'caret pull-right')])[2]")).Click();

            String ExpectedLanguage = "English" ;
            String ActualLanguage = driver.FindElement(By.XPath("//a[contains(.,'English')]")).Text;
            Assert.AreEqual(ExpectedLanguage, ActualLanguage);
            String ExpectedLanguage1 = "Dutch";
            String ActualLanguage1 = driver.FindElement(By.XPath("//a[contains(.,'Dutch')]")).Text;
            Assert.AreEqual(ExpectedLanguage1, ActualLanguage1);


            //Signup details

            driver.FindElement(By.XPath("//input[@title='Enter your name here']")).SendKeys("TestAssignmentQ1");
            driver.FindElement(By.Id("orgName")).SendKeys("AttagisSolutions");
            driver.FindElement(By.Id("singUpEmail")).SendKeys("dummytest@gmail.com");

            driver.FindElement(By.XPath("//span[contains(.,'I agree to the')]")).Click();

            driver.FindElement(By.XPath("//button[contains(.,'Get Started')]")).Click();
            Thread.Sleep(10000);
            String Expectedemailmsg = "A welcome email has been sent. Please check your email.";
            String Actualemailmsg = driver.FindElement(By.XPath("//span[@class='ng-binding'][contains(.,'A welcome email has been sent. Please check your email.')]")).Text;
            
            Console.WriteLine(Actualemailmsg);

            if (Actualemailmsg.Contains(Expectedemailmsg))
            {
                Console.WriteLine("Test case Passed");
                Assert.IsTrue(true, "test case passed");
            }
            else
            {
                Console.WriteLine("Test case failed");
            }

            driver.Close();
            //driver.Quit();



        }

       

    }
    }

