using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject.Pages.Globalsqa.DemoTestingSite
{
    internal class DragAndDropPage
    {
        IWebDriver driver;
        public DragAndDropPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string TooltipPageURL()
        {
            return "https://www.globalsqa.com/demo-site/draganddrop/";
        }

        #region Photo Manager tab

        public IWebElement PhotoManagerIftameElement => driver.FindElement(By.Id("Photo Manager"));

        public IWebElement PhotoManagerTabIftameElement => driver.FindElement(By.CssSelector("#post-2669 > div.twelve.columns > " +
            "div > div > div.single_tab_div.resp-tab-content.resp-tab-content-active > p > iframe"));

        public IWebElement GallaryElement => driver.FindElement(By.Id("gallery"));

        public IWebElement TrashBinElement => driver.FindElement(By.Id("trash"));

        #region Tile to move

        public IList<IWebElement> allTileTitlesInGallary => driver.FindElements(By.CssSelector("#gallery > li > h5"));

        internal static IWebElement SelectSpecificTileToMove(IWebDriver driver, int tileToMoveNumber=0)
        {
            return driver.FindElement(By.CssSelector($"#gallery > li:nth-child({tileToMoveNumber})"));
        }

        internal static IWebElement TileToMoveTitle(IWebDriver driver, int tileToMoveNumber)
        {
            return driver.FindElement(By.CssSelector($"#gallery > li:nth-child({tileToMoveNumber}) > h5"));
        }

        #endregion

        #region Tile in trash bin

        internal static IWebElement SelectSpecificTileInTrashBin(IWebDriver driver, int tileInTrashBinNumber)
        {
            return driver.FindElement(By.CssSelector($"#trash > ul > li:nth-child({tileInTrashBinNumber})"));
        }

        internal static IWebElement TileInTrashBinTitle(IWebDriver driver, int tileInTrashBinNumber)
        {
            return driver.FindElement(By.CssSelector($"#trash > ul > li:nth-child({tileInTrashBinNumber}) > h5"));
        }

        #endregion

        #endregion

        #region Photo Accepted Elements tab

        public IWebElement AcceptedElementsTab => driver.FindElement(By.Id("Accepted Elements"));

        public IWebElement AcceptedElementsIframeElement => driver.FindElement(By.CssSelector("#post-2669 > " +
            "div.twelve.columns > div > div > div.single_tab_div.resp-tab-content.resp-tab-content-active > p > iframe"));

        public IWebElement NotDragableElement => driver.FindElement(By.Id("draggable-nonvalid"));

        public IWebElement DragableElement => driver.FindElement(By.Id("draggable"));

        public IWebElement DropArea => driver.FindElement(By.Id("droppable"));

        #endregion

        #region Propagation tab

        public IWebElement PropagationTab => driver.FindElement(By.Id("Propagation"));

        public IWebElement PropagationIftameElement => driver.FindElement(By.CssSelector("#post-2669 > " +
            "div.twelve.columns > div > div > div.single_tab_div.resp-tab-content.resp-tab-content-active > p > iframe"));

        public IWebElement DraggableSquareElement => driver.FindElement(By.Id("draggable"));

        public IWebElement OuterDroppableArea => driver.FindElement(By.Id("droppable"));

        public IWebElement OuterDroppableAreaMessage => driver.FindElement(By.CssSelector("#droppable > p"));

        #endregion

    }
}
