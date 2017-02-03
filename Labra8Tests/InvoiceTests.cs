using Microsoft.VisualStudio.TestTools.UnitTesting;
using JAMK.IT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.Tests
{
    [TestClass()]
    public class InvoiceTests
    {
       

        [TestMethod()]
        public void AddItemTest()
        {
            // arrange
            InvoiceItem kalja1 = new InvoiceItem("Karhu-olut", 1.5, 5);
            InvoiceItem makkara = new InvoiceItem("Wilhelm", 2.5, 4);
            InvoiceItem hammastahna = new InvoiceItem("Pepsodent", 2.30, 2);

            Invoice invoice = new Invoice();
            invoice.Customer = "Pete";
            invoice.AddItem(kalja1);
            invoice.AddItem(makkara);
            invoice.AddItem(hammastahna);
            
            double expected = 1.5*5 + 2.5*4 +2.3*2;

            //act
            double actual = invoice.Total;

            // assert
            Assert.AreEqual(expected, actual);
        }

    }
}