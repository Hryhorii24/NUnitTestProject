using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Pages.globalsqa
{
    internal class SamplePageTest
    {
        IWebDriver driver;
        public SamplePageTest(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GlobalsqaSamplePageTestURL()
        {
            return "https://www.globalsqa.com/samplepagetest/";
        }

        public IWebElement UploadFileElement => driver.FindElement(By.CssSelector("#wpcf7-f2598-p2599-o1 > form > p > span > input"));

        public IWebElement NameField => driver.FindElement(By.CssSelector("#g2599-name"));

        public IWebElement EmailField => driver.FindElement(By.CssSelector("#g2599-email"));

        public IWebElement ExperienceDropdown => driver.FindElement(By.CssSelector("#g2599-experienceinyears"));

        
        // Expertise checkboxes
        public IWebElement FunctionalTestingCheckbox => driver.FindElement(By.XPath("//*[@id=\"contact-form-2599\"]/form/div[5]/label[2]"));

        // Education radio buttons
        public IWebElement PostGraduateRadioButton => driver.FindElement(By.XPath("//*[@id=\"contact-form-2599\"]/form/div[6]/label[3]"));

        
        public IWebElement CommentTextArea => driver.FindElement(By.CssSelector("#contact-form-comment-g2599-comment"));

        public IWebElement SubmitButton => driver.FindElement(By.CssSelector("#contact-form-2599 > form > p.contact-submit > button"));

        #region Contact form submission

        public IWebElement OutputUploadField => driver.FindElement(By.CssSelector("#wpcf7-f2598-p2599-o1 > form > p > span > input"));

        public IWebElement ContactFormSubmissionNameField => driver.FindElement(By.CssSelector("#contact-form-2599 > " +
            "blockquote > p:nth-child(1)"));

        public IWebElement ContactFormSubmissionEmailField => driver.FindElement(By.CssSelector("#contact-form-2599 > " +
            "blockquote > p:nth-child(2)"));

        public IWebElement ContactFormSubmissionWebsiteField => driver.FindElement(By.CssSelector("#contact-form-2599 > " +
            "blockquote > p:nth-child(3)"));

        public IWebElement ContactFormSubmissionExperienceField => driver.FindElement(By.CssSelector("#contact-form-2599 > " +
            "blockquote > p:nth-child(4)"));

        public IWebElement ContactFormSubmissionExpertiseField => driver.FindElement(By.CssSelector("#contact-form-2599 > " +
            "blockquote > p:nth-child(5)"));

        public IWebElement ContactFormSubmissionEducationField => driver.FindElement(By.CssSelector("#contact-form-2599 > " +
            "blockquote > p:nth-child(6)"));

        public IWebElement ContactFormSubmissionCommentField => driver.FindElement(By.CssSelector("#contact-form-2599 > " +
            "blockquote > p:nth-child(7)"));

        #endregion
    }
}
