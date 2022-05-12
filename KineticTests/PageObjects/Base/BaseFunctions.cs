using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace KineticTests.PageObjects.Base
{
	public class BaseFunctions : Elements
	{
		public void LaunchBrowser()
		{
			driver = new ChromeDriver();

			driver.Navigate().GoToUrl("https://the-internet.kineticskunk.co.za/");
			Wait2Seconds();
			driver.Manage().Window.Maximize();
		}
		public void CloseBrowser()
		{
			driver.Quit();
		}
		public enum ElementTypes
		{
			TextBox = 1,
			DropDown = 2,
			CheckBox = 3,
			Button = 4,
		}

		#region Waits
		public void Wait2Seconds()
		{
			Thread.Sleep(2000);
		}
		#endregion

		private void _clickElementBy(By by)
		{
			try
			{
				var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 120));
				var WaitForElement1 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
				var WaitForElement2 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
				var WAitForElement3 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
				Wait2Seconds();
				driver.FindElement(by).Click();
			}
			catch (Exception)
			{

			}
		}

		public void ClickElementByID(string id)
		{
			try
			{
				_clickElementBy(By.Id(id));
			}
			catch (Exception)
			{
				throw new Exception("Unable to click on element using ID: " + id);
			}
		}

		public void ClickElementByXPath(string xpath)
		{
			try
			{
				_clickElementBy(By.XPath(xpath));
			}
			catch (Exception)
			{
				throw new Exception("Unable to click on element using XPath: " + xpath);

			}
		}

		public void WaitUntilButtonIsVisible(string buttonID)
		{
			var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 120));
			wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(buttonID)));
		}

		public void WaitUntilElementIsVisible(string id, ElementTypes elementType)
		{
			var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 120));

			switch (elementType)
			{

				case ElementTypes.Button:
					wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(id)));
					wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(id)));
					break;
				case ElementTypes.DropDown:
					wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(id)));
					wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(id)));
					break;
				case ElementTypes.TextBox:
					wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(id)));
					break;
				default:
					wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(id)));
					break;

			}

		}

		public void SelectDropdownValues(string id, string text)
		{
			IWebElement element = driver.FindElement(By.Id(id));
			SelectElement selectElement = new SelectElement(element);
			selectElement.SelectByText(text);
			Wait2Seconds();
		}

		public void DragAndDrop(IWebElement sourceElement, IWebElement destinationElement)
		{
			Actions actions = new Actions(driver);
			actions.DragAndDrop(sourceElement, destinationElement).Perform();
		}
	}
}
