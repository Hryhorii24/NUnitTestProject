namespace TestProject.Pages.globalsqa
{
    internal class HomePage
    {

        IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string HomePageURL()
        {
            return "https://www.globalsqa.com/";
        }


        #region Testers hub menu
        public IWebElement TestersHubMenuItem => driver.FindElement(By.Id("menu-item-2822"));

        #region Demo Testing Site options
        public IWebElement DemoTestingSiteMenuItem => driver.FindElement(By.Id("menu-item-2823"));
        public IWebElement TooltipMenuItem => driver.FindElement(By.Id("menu-item-2831"));

        public IWebElement ProgressBarMenuItem => driver.FindElement(By.Id("menu-item-2832"));
        public IWebElement DatePickerMenuItem => driver.FindElement(By.Id("menu-item-2827"));
        public IWebElement DragAndDropMenuItem => driver.FindElement(By.Id("menu-item-2829"));

        #endregion

        public IWebElement SamplePageTest => driver.FindElement(By.Id("menu-item-2846"));
        #endregion

    }
}