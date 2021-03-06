using System;
using System.Collections.Generic;
using System.Threading;
using KineticTests.PageObjects.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace KineticTests
{
	[TestClass]
	public class TC_KineticTests : BaseFunctions
	{
		[TestMethod]
		public void TC_CheckBoxes()
		{
			LaunchBrowser();
			driver.FindElement(By.LinkText("Checkboxes")).Click();
			chkbox.Click();
			unchkdbox.Click();
			Assert.IsTrue(chkbox.Selected);
			Assert.IsTrue(!unchkdbox.Selected);
			Wait2Seconds();
			CloseBrowser();
		}

		[TestMethod]
		public void TC_DragAndDrop()
		{
			//Test will fail because of a known issue (Issue with Cursor Changing) https://github.com/SeleniumHQ/selenium/issues/8003
			LaunchBrowser();
			driver.FindElement(By.LinkText("Drag and Drop")).Click();
			Actions actions = new Actions(driver);
			actions.DragAndDrop(drag, drop);
			actions.Build();
			actions.Perform();
			string divHeader = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/header")).Text.ToString();
			Assert.AreEqual("B", divHeader);
			Wait2Seconds();
			CloseBrowser();
		}

		[TestMethod]
		public void TC_DragAndDrop1()
		{
			//Peformed a drag and drop functionality on another website

			driver = new ChromeDriver();
			driver.Navigate().GoToUrl("http://www.uitestpractice.com/");
			driver.Manage().Window.Maximize();
			IWebElement drag = driver.FindElement(By.Id("draggable"));
			IWebElement drop = driver.FindElement(By.Id("droppable"));
			Actions actions = new Actions(driver);
			actions.DragAndDrop(drag, drop).Perform();
			Wait2Seconds();
			CloseBrowser();
		}

		[TestMethod]
		public void TC_Dropdown()
		{
			LaunchBrowser();
			driver.FindElement(By.LinkText("Dropdown")).Click();
			SelectDropdownValues("dropdown", "Option 2");
			string selectedOption = driver.FindElement(By.XPath("/html/body/div[2]/div/div/select/option[3]")).Text.ToString();
			Assert.AreEqual("Option 2", selectedOption);
			Wait2Seconds();
			CloseBrowser();
		}
	}
}
