using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace KineticTests.PageObjects.Base
{
	public class Elements
	{
		public IWebDriver driver;
		public TestContext TestContext { get; set; }

		//Checkboxes
		public IWebElement chkbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/input[1]"));
		public IWebElement unchkdbox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/input[2]"));

		//Drag and Drop
		public IWebElement drag => driver.FindElement(By.Id("column-a"));
		public IWebElement drop => driver.FindElement(By.Id("column-b"));
	}
}
