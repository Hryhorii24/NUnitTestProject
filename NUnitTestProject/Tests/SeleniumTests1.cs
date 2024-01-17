
using NUnitTestProject.Pages.Globalsqa.DemoTestingSite;
using TestProject.Pages.globalsqa;

namespace SeleniumTests.Tests
{

    class SeleniumTests1
    {
        readonly string driverPath = AppDomain.CurrentDomain.BaseDirectory;
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(driverPath);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void AfterTest()
        {
            System.Threading.Thread.Sleep(1000);
            driver.Dispose();
        }


        [Test]
        public void VerifySettingTheCurrentDate()
        {
            var HomePage = new HomePage(driver);

            driver.Url = HomePage.HomePageURL();

            Actions actions = new Actions(driver);

            // Select Progress Bar option
            actions.MoveToElement(HomePage.TestersHubMenuItem).Perform();
            actions.MoveToElement(HomePage.DemoTestingSiteMenuItem).Perform();
            actions.MoveToElement(HomePage.DatePickerMenuItem).Click().Perform();


            var globalsqaDatePickerPage = new DatePickerPage(driver);

            driver.SwitchTo().Frame(globalsqaDatePickerPage.IframeElement);

            // Select current date in the Date Picker
            globalsqaDatePickerPage.DataPickerElement.Click();
            globalsqaDatePickerPage.CurrentDayOption.Click();


            string dateValue = globalsqaDatePickerPage.DataPickerElement.GetAttribute("value");
            string dateFormatPattern = @"^(0[1-9]|1[0-2])/(0[1-9]|[12][0-9]|3[01])/\d{4}$";

            Assert.That(Regex.IsMatch(dateValue, dateFormatPattern), $"Date {dateValue} invalid data format.");

        }

        [Test]
        public void VerifyDownloadingWithProgressBar()
        {
            var HomePage = new HomePage(driver);

            driver.Url = HomePage.HomePageURL();

            Actions actions = new Actions(driver);

            // Select Progress Bar option
            actions.MoveToElement(HomePage.TestersHubMenuItem).Perform();
            actions.MoveToElement(HomePage.DemoTestingSiteMenuItem).Perform();
            actions.MoveToElement(HomePage.ProgressBarMenuItem).Click().Perform();

            var globalsqaProgressBarPage = new ProgressBarPage(driver);

            driver.SwitchTo().Frame(globalsqaProgressBarPage.IframeElement);

            globalsqaProgressBarPage.StartDownloadButton.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.TextToBePresentInElement(globalsqaProgressBarPage.DownloadingStatusElement, "Complete!"));

            Assert.That(globalsqaProgressBarPage.DownloadingStatusElement.Text, Is.EqualTo("Complete!"), "Wrong download status was received");

        }

        [Test]
        public void ApplyApplication()
        {
            var uploadImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", "Images", "Picture2.png");
            var name = "Deniel";
            var email = "den2023@gmail.com";
            var comment = "My comment";
            Console.WriteLine(uploadImagePath);

            var HomePage = new HomePage(driver);

            driver.Url = HomePage.HomePageURL();

            Actions actions = new Actions(driver);

            actions.MoveToElement(HomePage.TestersHubMenuItem).Perform();
            actions.MoveToElement(HomePage.SamplePageTest).Click().Perform();

            var globalsqaSamplePageTest = new SamplePageTest(driver);

            globalsqaSamplePageTest.UploadFileElement.SendKeys(uploadImagePath);

            globalsqaSamplePageTest.NameField.SendKeys(name);
            globalsqaSamplePageTest.EmailField.SendKeys(email);

            SelectElement selectOption = new SelectElement(globalsqaSamplePageTest.ExperienceDropdown);
            selectOption.SelectByText("3-5");

            globalsqaSamplePageTest.FunctionalTestingCheckbox.Click();

            globalsqaSamplePageTest.PostGraduateRadioButton.Click();

            globalsqaSamplePageTest.CommentTextArea.SendKeys(comment);

            globalsqaSamplePageTest.SubmitButton.Click();


            Console.WriteLine(globalsqaSamplePageTest.ContactFormSubmissionNameField.Text);

            Assert.Multiple(() =>
            {

                // Verify attached image
                //Assert.That(globalsqaSamplePageTest.OutputUploadField.GetAttribute("value"), Is.EqualTo(uploadFile),
                //    $"File {uploadFile} is not attached.");



                // Verify Name field
                Assert.That(globalsqaSamplePageTest.ContactFormSubmissionNameField.Text, Does.Contain(name));
                // Verify Email field
                Assert.That(globalsqaSamplePageTest.ContactFormSubmissionEmailField.Text, Does.Contain(email));
                // Verify Website field
                Assert.That(globalsqaSamplePageTest.ContactFormSubmissionWebsiteField.Text, Does.Contain("Website:"));
                // Verify Experience field
                Assert.That(globalsqaSamplePageTest.ContactFormSubmissionExperienceField.Text, Does.Contain("3-5"));
                // Verify Expertise field
                Assert.That(globalsqaSamplePageTest.ContactFormSubmissionExpertiseField.Text, Does.Contain("Functional Testing"));
                // Verify Education field
                Assert.That(globalsqaSamplePageTest.ContactFormSubmissionEducationField.Text, Does.Contain("Post Graduate"));
                // Verify Comment field
                Assert.That(globalsqaSamplePageTest.ContactFormSubmissionCommentField.Text, Does.Contain(comment));
            });

        }

        [Test]
        public void VerifyTooltipOnCoutryName()
        {
            var HomePage = new HomePage(driver);

            driver.Url = HomePage.HomePageURL();

            Actions actions = new Actions(driver);

            actions.MoveToElement(HomePage.TestersHubMenuItem).Perform();
            actions.MoveToElement(HomePage.DemoTestingSiteMenuItem).Perform();
            actions.MoveToElement(HomePage.TooltipMenuItem).Click().Perform();

            var globalsqaDemoTestingSiteTooltipPage = new TooltipPage(driver);

            driver.SwitchTo().Frame(globalsqaDemoTestingSiteTooltipPage.ImageBasedIframeElement);

            actions.MoveToElement(globalsqaDemoTestingSiteTooltipPage.CountryNameLabel).Perform();

            string altText = globalsqaDemoTestingSiteTooltipPage.CountryNameTooltip.GetAttribute("alt");

            Assert.That(altText, Is.EqualTo("Vienna, Austria"));
        }

        [Test]
        public void VerifyTooltipsOnVideoButtons()
        {
            var HomePage = new HomePage(driver);

            driver.Url = HomePage.HomePageURL();

            Actions actions = new Actions(driver);

            actions.MoveToElement(HomePage.TestersHubMenuItem).Perform();
            actions.MoveToElement(HomePage.DemoTestingSiteMenuItem).Perform();
            actions.MoveToElement(HomePage.TooltipMenuItem).Click().Perform();

            var globalsqaDemoTestingSiteTooltipPage = new TooltipPage(driver);

            globalsqaDemoTestingSiteTooltipPage.VideoBasedTab.Click();

            driver.SwitchTo().Frame(globalsqaDemoTestingSiteTooltipPage.VideoBasedIframeElement);


            actions.MoveToElement(globalsqaDemoTestingSiteTooltipPage.LikeButton).Perform();
            var tooltipLikeButton = globalsqaDemoTestingSiteTooltipPage.TooltipElement.Text;

            actions.MoveToElement(globalsqaDemoTestingSiteTooltipPage.DislikeButton).Perform();
            var tooltipDislikeButton = globalsqaDemoTestingSiteTooltipPage.TooltipElement.Text;

            actions.MoveToElement(globalsqaDemoTestingSiteTooltipPage.AddToWatchLaterButton).Perform();
            var tooltipAddToWatchLaterButton = globalsqaDemoTestingSiteTooltipPage.TooltipElement.Text;

            actions.MoveToElement(globalsqaDemoTestingSiteTooltipPage.AddToFavoritesOrPlaylistButton).Perform();
            var tooltipAddToFavoritesOrPlaylistButton = globalsqaDemoTestingSiteTooltipPage.TooltipElement.Text;

            actions.MoveToElement(globalsqaDemoTestingSiteTooltipPage.ShareThisVideoButton).Perform();
            var tooltipShareThisVideoButton = globalsqaDemoTestingSiteTooltipPage.TooltipElement.Text;

            actions.MoveToElement(globalsqaDemoTestingSiteTooltipPage.FlagAsInappropriateButton).Perform();
            var tooltipFlagAsInappropriateButton = globalsqaDemoTestingSiteTooltipPage.TooltipElement.Text;

            Assert.Multiple(() =>
            {
                Assert.That(tooltipLikeButton, Is.EqualTo("I like this"));
                Assert.That(tooltipDislikeButton, Is.EqualTo("I dislike this"));
                Assert.That(tooltipAddToWatchLaterButton, Is.EqualTo("Add to Watch Later"));
                Assert.That(tooltipAddToFavoritesOrPlaylistButton, Is.EqualTo("Add to favorites or playlist"));
                Assert.That(tooltipShareThisVideoButton, Is.EqualTo("Share this video"));
                Assert.That(tooltipFlagAsInappropriateButton, Is.EqualTo("Flag as inappropriate"));
            });
        }

        [Test]
        public void VerifyTooltipsOnInputFields()
        {
            var HomePage = new HomePage(driver);

            driver.Url = HomePage.HomePageURL();

            Actions actions = new Actions(driver);

            actions.MoveToElement(HomePage.TestersHubMenuItem).Perform();
            actions.MoveToElement(HomePage.DemoTestingSiteMenuItem).Perform();
            actions.MoveToElement(HomePage.TooltipMenuItem).Click().Perform();

            var tooltipPage = new TooltipPage(driver);

            tooltipPage.FormsBasedTab.Click();

            driver.SwitchTo().Frame(tooltipPage.FormsBasedIframeElement);

            string[] myStringArray = new string[3];

            actions.MoveToElement(tooltipPage.FirstNameInputField).Perform();
            var tooltipFirstNameInputField = tooltipPage.FirstNameTooltip.Text;
            myStringArray[0] = tooltipFirstNameInputField;
            //Console.WriteLine(tooltipFirstNameInputField);

            actions.MoveToElement(tooltipPage.LastNameInputField).Perform();
            var tooltipLastNameInputField = tooltipPage.LastNameTooltip.Text;
            myStringArray[1] = tooltipLastNameInputField;
            //Console.WriteLine(tooltipLastNameInputField);

            actions.MoveToElement(tooltipPage.AddressInputField).Perform();
            var tooltipAddressInputField = tooltipPage.AddressTooltip.Text;
            myStringArray[2] = tooltipAddressInputField;
            //Console.Write(tooltipAddressInputField);

            for (int i = 0; i < myStringArray.Length; i++)
            {
                Console.WriteLine(myStringArray[i]);
            }

            Assert.Multiple(() =>
            {
                Assert.That(tooltipFirstNameInputField, Is.EqualTo("Please provide your firstname."));
                Assert.That(tooltipLastNameInputField, Is.EqualTo("Please provide also your lastname."));
                Assert.That(tooltipAddressInputField, Is.EqualTo("Your home or work address."));
            });
        }

        [Test]
        public void VerifyMovingSpecificTile()
        {
            var HomePage = new HomePage(driver);

            driver.Url = HomePage.HomePageURL();

            Actions actions = new Actions(driver);

            actions.MoveToElement(HomePage.TestersHubMenuItem).Perform();
            actions.MoveToElement(HomePage.DemoTestingSiteMenuItem).Perform();
            actions.MoveToElement(HomePage.DragAndDropMenuItem).Click().Perform();

            var dragAndDropPage = new DragAndDropPage(driver);

            driver.SwitchTo().Frame(dragAndDropPage.PhotoManagerTabIftameElement);

            int tileToMoveNumber = 1;

            string selectedTileTitle = DragAndDropPage.TileToMoveTitle(driver, tileToMoveNumber).Text;

            actions.MoveToElement(DragAndDropPage.SelectSpecificTileToMove(driver, tileToMoveNumber)).ClickAndHold().Perform();
            actions.MoveToElement(dragAndDropPage.TrashBinElement).Release().Perform();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => DragAndDropPage.SelectSpecificTileInTrashBin(driver, 1).Displayed);

            string textContent = (string)((IJavaScriptExecutor)driver).ExecuteScript(
            "return arguments[0].textContent;",
            DragAndDropPage.TileInTrashBinTitle(driver, 1));

            bool SelectedElementIsNotFound = true;
            foreach (var h5Element in dragAndDropPage.allTileTitlesInGallary)
            {
                if (h5Element.Text == selectedTileTitle)
                {
                    SelectedElementIsNotFound = false;
                    break;
                }
            }

            Assert.That(textContent, Is.EqualTo(selectedTileTitle));

            Assert.That(SelectedElementIsNotFound, Is.True);

        }

        [Test]
        public void VerifyMovingDraggableObgect()
        {
            var HomePage = new HomePage(driver);

            driver.Url = HomePage.HomePageURL();

            Actions actions = new Actions(driver);

            actions.MoveToElement(HomePage.TestersHubMenuItem).Perform();
            actions.MoveToElement(HomePage.DemoTestingSiteMenuItem).Perform();
            actions.MoveToElement(HomePage.DragAndDropMenuItem).Click().Perform();

            var dragAndDropPage = new DragAndDropPage(driver);

            dragAndDropPage.AcceptedElementsTab.Click();

            driver.SwitchTo().Frame(dragAndDropPage.AcceptedElementsIframeElement);

            actions.MoveToElement(dragAndDropPage.DragableElement).ClickAndHold().Perform();
            actions.MoveToElement(dragAndDropPage.DropArea).Release().Perform();

            string dropAreaMessage = dragAndDropPage.DropArea.Text;

            Assert.That(dropAreaMessage, Is.EqualTo("Dropped!"));
        }

        [Test]
        public void VerifyMovingDraggableObgectToOuterArea()
        {
            var HomePage = new HomePage(driver);

            driver.Url = HomePage.HomePageURL();

            Actions actions = new Actions(driver);

            actions.MoveToElement(HomePage.TestersHubMenuItem).Perform();
            actions.MoveToElement(HomePage.DemoTestingSiteMenuItem).Perform();
            actions.MoveToElement(HomePage.DragAndDropMenuItem).Click().Perform();

            var dragAndDropPage = new DragAndDropPage(driver);

            dragAndDropPage.PropagationTab.Click();

            driver.SwitchTo().Frame(dragAndDropPage.PropagationIftameElement);

            int yOffset = dragAndDropPage.OuterDroppableArea.Location.Y - dragAndDropPage.DraggableSquareElement.Location.Y;
            int xOffset = dragAndDropPage.OuterDroppableArea.Location.X - dragAndDropPage.DraggableSquareElement.Location.X;

            actions.MoveToElement(dragAndDropPage.DraggableSquareElement).ClickAndHold().Perform();
            actions.MoveByOffset(xOffset, yOffset).Release().Perform();

            Assert.That(dragAndDropPage.OuterDroppableAreaMessage.Text, Is.EqualTo("Dropped!"));
        }
    }
}
