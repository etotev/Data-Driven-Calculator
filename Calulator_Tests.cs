using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DataDriverTestsCalculator
{

    public class Tests
    {
        private WebDriver driver;
        IWebElement firstNum;
        IWebElement secondNum;
        IWebElement operatorField;
        IWebElement calculateButton;
        IWebElement resetButton;
        IWebElement resultField;

        [OneTimeSetUp]
        public void Setup()
        {

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            this.driver = new ChromeDriver(options);
            driver.Url = "https://number-calculator.nakov.repl.co/";
            driver.Manage().Window.Maximize();

            firstNum = driver.FindElement(By.Id("number1"));
            secondNum = driver.FindElement(By.Id("number2"));
            operatorField = driver.FindElement(By.Id("operation"));
            calculateButton = driver.FindElement(By.Id("calcButton"));
            resetButton = driver.FindElement(By.Id("resetButton"));
            resultField = driver.FindElement(By.Id("result"));
        }


        [OneTimeTearDown]
        public void Exit()
        {
            driver.Close();
        }



        [TestCase("2", "3", "+", "Result: 5")]
        [TestCase("2", "8", "+", "Result: 10")]
        [TestCase("2", "1", "-", "Result: 1")]
        [TestCase("1", "1", "-", "Result: 0")]
        [TestCase("0", "3", "+", "Result: 3")]
        [TestCase("0", "0", "+", "Result: 0")]
        [TestCase("text", "text1", "+", "Result: invalid input")]
        [TestCase("2", "t3xt", "+", "Result: invalid input")]
        [TestCase("-2", "-3", "*", "Result: 6")]
        [TestCase("-2", "3", "+", "Result: 1")]
        [TestCase("10", "2", "/", "Result: 5")]
        [TestCase("-2", "10", "/", "Result: -0.2")]


        public void Calculator_DD_Tests(string num1, string num2, string operation,string result)
        {
            resetButton.Click();

            firstNum.Click();
            firstNum.SendKeys(num1);
            secondNum.Click();
            secondNum.SendKeys(num2);
            operatorField.Click();
            operatorField.SendKeys(operation);
            calculateButton.Click();

            Assert.That(resultField.Text, Is.EqualTo(result));
        }
    }
}