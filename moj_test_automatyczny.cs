using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Sitecore.Rocks.UI.RuleEditors;

/*    Kroki:
    1. Wejdź i maximalizuj stronę "http://automationpractice.com"
    2. Kliknij kategorię "Dresses"
    3. Kliknij subkategorię "Summer dress"
    4. Kliknij przycisk "Printed Chiffon Dress"
    5. Zmień ilość(quantity) klikając przycisk „+” jeden raz
    6. Rozwiń listę "size" i wybierz rozmiar "M"
    7. Zmień kolor, klikając w zielony przycisk(green)
    8. Kliknij przycisk "Add to cart"
    9. Kliknij przycisk "Continue shopping"
    10. Kliknij kategorię "Women"
    11. Kliknij subkategorię "Tops"
    12. Kliknij subkategorię "Blouses"
    13. Kliknij przycisk "Blouse"
    14. Zmień ilość(quantity) wpisując 5
    15. Rozwiń listę "size" i wybierz rozmiar "L"
    16. Wybierz kolor biały klikając przycisk "White"
    17. Kliknij przycisk "Add to cart"
    18. Kliknij przycisk "Proceed to checkout"
    19. Kliknij przycisk "Proceed to checkout"
    20. Wpisz email adres w polu należącym do "Create an account"
    21. Kliknij przycisk "Create an account"
    22. Wybierz radio button Title "Mr" / Zaznacz radio button Title "Mr"
    23. Uzupełnij pole "First name"
    24. Uzupełnij pole "Last name"
    25. Uzupełnij pole "Password” (minimum 5 znaków)
    26. Zaznacz check box "Sign up for our newsletter" & "Receive special offers from our partners"
    27. Uzupełnij pole “adres” (ulica)
    28. Uzupełnij pole "city" (Washington)
    29. Rozwiń listę "State"
    30. Wybierz Washington
    31. Uzupełnij pole "Zip-code"
    32. Wpisz numer telefonu w polu "mobile phone"
    33. Kliknij w pole "Assign an address alias for future reference"
    34. Zaznacz wszystko(Ctrl+A)
    35. Usuń tekst
    36. Wpisz adres
    37. Kliknij przycisk "Register"
    38. Kliknij przycisk "Proceed to checkout"
    39. Zaznacz check box "Terms of service"
    40. Kliknij przycisk "Proceed to checkout"
    41. Kliknij przycisk "Pay by bank wire"
    42. Kliknij przycisk "I confirm my order"
*/

/*
 * author: kjaniak
 */

namespace SeleniumWebdriver
{
    class SeleniumExample
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            // 1.Wejdź i maximalizuj stronę "http://automationpractice.com"
            driver = new ChromeDriver("C:\\Chromedriver\\");
            driver.Url = "http://automationpractice.com/index.php";
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void myNewTest()
        {
            // 2.Kliknij kategorię "Dresses"
            driver.FindElement(By.CssSelector(".sf-menu > li:nth-child(2) > a:nth-child(1)")).Click();
            // 3.Kliknij subkategorię "Summer dress"
            driver.FindElement(By.XPath("//*[@id=\"subcategories\"]/ul/li[3]/div[1]/a")).Click();
            // 4.Kliknij przycisk "Printed Chiffon Dress"
            driver.FindElement(By.PartialLinkText("Chiffon")).Click();
            // 5.Zmień ilość(quantity) klikając przycisk „+” jeden raz
            driver.FindElement(By.CssSelector("a.btn:nth-child(4) > span:nth-child(1)")).Click();
            // 6.Rozwiń listę "size" i wybierz rozmiar "M"
            driver.FindElement(By.Id("group_1")).Click();
            driver.FindElement(By.CssSelector("#group_1 > option:nth-child(2)")).Click();
            // 7.Zmień kolor, klikając w zielony przycisk(green)
            driver.FindElement(By.Id("color_15")).Click();
            // 8.Kliknij przycisk "Add to cart"
            driver.FindElement(By.Name("Submit")).Click();
            // 9.Kliknij przycisk "Continue shopping"
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"layer_cart\"]/div[1]/div[2]/div[4]/span")));
            driver.FindElement(By.XPath("//*[@id=\"layer_cart\"]/div[1]/div[2]/div[4]/span")).Click();
            // 10.Kliknij kategorię "Women"
            driver.FindElement(By.CssSelector("#block_top_menu > ul > li:nth-child(1) > a")).Click();
            // 11.Kliknij subkategorię "Tops"
            driver.FindElement(By.LinkText("Tops")).Click();
            // 12.Kliknij subkategorię "Blouses"
            driver.FindElement(By.PartialLinkText("Blo")).Click();
            // 13.Kliknij przycisk "Blouse"
            driver.FindElement(By.CssSelector("#center_column > ul > li > div > div.right-block > h5 > a")).Click();
            // 14.Zmień ilość(quantity) wpisując 5
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("qty")));
            driver.FindElement(By.Name("qty")).Click();
            driver.FindElement(By.Name("qty")).Clear();
            driver.FindElement(By.Name("qty")).SendKeys("5");
            // 15.Rozwiń listę "size" i wybierz rozmiar "L"
            driver.FindElement(By.Id("group_1")).Click();
            driver.FindElement(By.CssSelector("#group_1 > option:nth-child(3)")).Click();
            // 16.Wybierz kolor biały klikając przycisk "White"
            driver.FindElement(By.Name("White")).Click();
            // 17.Kliknij przycisk "Add to cart"
            driver.FindElement(By.Name("Submit")).Click();
            // 18.Kliknij przycisk "Proceed to checkout"
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"layer_cart\"]/div[1]/div[2]/div[4]/a")));
            driver.FindElement(By.XPath("//*[@id=\"layer_cart\"]/div[1]/div[2]/div[4]/a")).Click();
            // 19.Kliknij przycisk "Proceed to checkout"
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"center_column\"]/p[2]/a[1]")));
            driver.FindElement(By.XPath("//*[@id=\"center_column\"]/p[2]/a[1]")).Click();
            // 20.Wpisz email adres w polu należącym do "Create an account"
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("email_create")));
            driver.FindElement(By.Id("email_create")).SendKeys("buymesomenewclothes@blabla.com");
            // 21.Kliknij przycisk "Create an account"
            driver.FindElement(By.Name("SubmitCreate")).Click();
            // 22.Wybierz radio button Title "Mr" / Zaznacz radio button Title "Mr"
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("uniform-id_gender1")));
            driver.FindElement(By.Id("uniform-id_gender1")).Click();
            // 23.Uzupełnij pole "First name"
            driver.FindElement(By.Name("customer_firstname")).SendKeys("John");
            // 24.Uzupełnij pole "Last name"
            driver.FindElement(By.Name("customer_lastname")).SendKeys("Kowalski");
            // 25.Uzupełnij pole "Password” (minimum 5 znaków)
            driver.FindElement(By.Id("passwd")).SendKeys("mypasswd123");
            // 26.Zaznacz check box "Sign up for our newsletter" & "Receive special offers from our partners"
            driver.FindElement(By.Id("newsletter")).Click();
            driver.FindElement(By.Id("optin")).Click();
            // 27.Uzupełnij pole “adres” (ulica)
            driver.FindElement(By.Name("address1")).SendKeys("VeryNice Street 4");
            // 28.Uzupełnij pole "city"(Washington)
            driver.FindElement(By.Id("city")).SendKeys("Washington");
            // 29.Rozwiń listę "State"
            // 30.Wybierz Washington
            driver.FindElement(By.Id("id_state")).Click();
            driver.FindElement(By.CssSelector("#id_state > option:nth-child(51)")).Click();
            // 31.Uzupełnij pole "Zip-code"
            driver.FindElement(By.Id("postcode")).SendKeys("20002");
            // 32.Wpisz numer telefonu w polu "mobile phone"
            driver.FindElement(By.Name("phone_mobile")).SendKeys("0123456789");
            // 33.Kliknij w pole "Assign an address alias for future reference"
            // 34.Zaznacz wszystko(Ctrl + A)
            // 35.Usuń tekst
            // 36.Wpisz adres
            driver.FindElement(By.Id("alias")).Clear();
            driver.FindElement(By.Id("alias")).SendKeys("myalias123");
            // 37.Kliknij przycisk "Register"
            driver.FindElement(By.Id("submitAccount")).Click();
            // 38.Kliknij przycisk "Proceed to checkout"
            driver.FindElement(By.CssSelector("#center_column > form > p > button")).Click();
            // 39.Zaznacz check box "Terms of service"
            driver.FindElement(By.Name("cgv")).Click();
            // 40.Kliknij przycisk "Proceed to checkout"
            driver.FindElement(By.Name("processCarrier")).Click();
            // 41.Kliknij przycisk "Pay by bank wire"
            driver.FindElement(By.CssSelector("#HOOK_PAYMENT > div:nth-child(1) > div > p > a")).Click();
            // 42.Kliknij przycisk "I confirm my order"
            driver.FindElement(By.CssSelector("#cart_navigation > button")).Click();
        }
        
        [TearDown]
        public void closeBrowser()
        {
            //driver.Close();
        }
    }
}

