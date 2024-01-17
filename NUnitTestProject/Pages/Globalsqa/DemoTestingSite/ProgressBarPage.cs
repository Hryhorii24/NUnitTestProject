namespace NUnitTestProject.Pages.Globalsqa.DemoTestingSite
{
    internal class ProgressBarPage
    {
        IWebDriver driver;
        public ProgressBarPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GlobalsqaHomePageURL()
        {
            return "https://www.globalsqa.com/demo-site/progress-bar/";
        }

        public IWebElement StartDownloadButton => driver.FindElement(By.CssSelector("#downloadButton"));

        public IWebElement IframeElement => driver.FindElement(By.CssSelector("#post-2671 > div.twelve.columns > div > div > " +
            "div.single_tab_div.resp-tab-content.resp-tab-content-active > p > iframe"));

        #region Progress bar popup

        public IWebElement DownloadingStatusElement => driver.FindElement(By.CssSelector("#dialog > div.progress-label"));

        #endregion
    }
}
