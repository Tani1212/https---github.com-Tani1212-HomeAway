using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test_Framework;

namespace Tests
{
    [TestClass]
    public class TestExPart1
    {
        static string Url = "http://store.demoqa.com ";
        static string title = "ONLINE STORE | Toolsqa Dummy Test site";

        [TestMethod]
        public void orderAndVerfiyAmount()
        {
           
            Browser_ExPart1.Goto(Url);
            Assert.IsTrue(Browser_ExPart1.Checktitle(title));

            Assert.IsTrue(Browser_ExPart1.VerfiyAmount());
            Assert.IsTrue(Browser_ExPart1.SubmitOrder());

        }


        [TestMethod]
        public void verifyEmptyCart()
        {
            string textToVerify = "Oops, there is nothing in your cart.";
            string text = string.Empty;
            
            Browser_ExPart1.Goto(Url);      
            text=Browser_ExPart1.EmptyCartText();
            Assert.IsTrue(text == textToVerify);

        }
        [TestMethod]
        public void verifyAccountdetails()
        {
            //Todo: Not able to register to site (didnt get email with password, seems to be an issue with smtp service.)

        }

       
    }
}
