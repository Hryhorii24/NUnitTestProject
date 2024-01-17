namespace NUnitTestProject.Pages.Globalsqa.DemoTestingSite
{
    internal class TooltipPage
    {
        IWebDriver driver;
        public TooltipPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GlobalsqaDemoTestingSiteTooltipPageURL()
        {
            return "https://www.globalsqa.com/demo-site/tooltip/";
        }


        #region Image Based tab
        public IWebElement ImageBasedTab => driver.FindElement(By.Id("Image Based"));

        public IWebElement ImageBasedIframeElement => driver.FindElement(By.CssSelector("#post-2679 > div.twelve.columns > " +
            "div > div > div.single_tab_div.resp-tab-content.resp-tab-content-active > p:nth-child(2) > iframe"));

        public IWebElement CountryNameLabel => driver.FindElement(By.CssSelector("body > div:nth-child(1) > div > h3 > a"));

        public IWebElement CountryNameTooltip => driver.FindElement(By.ClassName("map"));

        #endregion


        #region Video Based tab
        public IWebElement VideoBasedTab => driver.FindElement(By.Id("Video Based"));

        public IWebElement VideoBasedIframeElement => driver.FindElement(By.CssSelector("#post-2679 > div.twelve.columns > " +
            "div > div > div.single_tab_div.resp-tab-content.resp-tab-content-active > p:nth-child(2) > iframe"));

        public IWebElement TooltipElement => driver.FindElement(By.ClassName("ui-tooltip-content"));


        public IWebElement LikeButton => driver.FindElement(By.CssSelector("body > div.tools > span > " +
            "button.ui-widget.ui-controlgroup-item.ui-button.ui-corner-left"));

        public IWebElement DislikeButton => driver.FindElement(By.CssSelector("body > div.tools > span > " +
            "button.ui-widget.ui-button-icon-only.ui-controlgroup-item.ui-button.ui-corner-right"));

        public IWebElement AddToWatchLaterButton => driver.FindElement(By.CssSelector("body > div.tools > div > " +
            "button.ui-widget.ui-controlgroup-item.ui-button.ui-corner-left"));

        public IWebElement AddToFavoritesOrPlaylistButton => driver.FindElement(By.CssSelector("body > div.tools > div > " +
            "button.menu.ui-widget.ui-button-icon-only.ui-controlgroup-item.ui-button.ui-corner-right"));

        public IWebElement ShareThisVideoButton => driver.FindElement(By.CssSelector("body > div.tools > " +
            "button:nth-child(3)"));

        public IWebElement FlagAsInappropriateButton => driver.FindElement(By.CssSelector("body > div.tools > " +
            "button.ui-button.ui-corner-all.ui-widget.ui-button-icon-only"));

        #endregion


        #region Forms Based tab
        public IWebElement FormsBasedTab => driver.FindElement(By.Id("Forms Based"));

        public IWebElement FormsBasedIframeElement => driver.FindElement(By.CssSelector("#post-2679 > " +
            "div.twelve.columns > div > div > div.single_tab_div.resp-tab-content.resp-tab-content-active > p > iframe"));


        public IWebElement FirstNameInputField => driver.FindElement(By.Id("firstname"));
        public IWebElement FirstNameTooltip => driver.FindElement(By.CssSelector("#ui-id-1 > div"));

        public IWebElement LastNameInputField => driver.FindElement(By.Id("lastname"));
        public IWebElement LastNameTooltip => driver.FindElement(By.CssSelector("#ui-id-2 > div"));

        public IWebElement AddressInputField => driver.FindElement(By.Id("address"));
        public IWebElement AddressTooltip => driver.FindElement(By.CssSelector("#ui-id-3 > div"));

        #endregion




    }
}
