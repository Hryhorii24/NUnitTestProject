namespace NUnitTestProject.Pages.Globalsqa.DemoTestingSite
{
    internal class DatePickerPage
    {

        IWebDriver driver;
        public DatePickerPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GlobalsqaHomePageURL()
        {
            return "https://www.globalsqa.com/demo-site/datepicker/";
        }

        public IWebElement IframeElement => driver.FindElement(By.CssSelector("#post-2661 > div.twelve.columns > div > div > " +
            "div.single_tab_div.resp-tab-content.resp-tab-content-active > p > iframe"));

        public IWebElement DataPickerElement => driver.FindElement(By.CssSelector("#datepicker"));

        public IWebElement CurrentDayOption => driver.FindElement(By.ClassName("ui-datepicker-today"));


    }
}
