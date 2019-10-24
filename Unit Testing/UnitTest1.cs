using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ItemRestService.Controllers;
using ItemRestService;
using ModelLib;
using System.Collections.Generic;

namespace Unit_Testing
{
    [TestClass]
    public class UnitTest1
    {

        private static readonly List<Item> items = new List<Item>()
         {
         new Item(1,"Bread","Low",33),
         new Item(2,"Bread","Middle",21),
         new Item(3,"Beer","low",70.5),
         new Item(4,"Soda","High",21.4),
         new Item(5,"Milk","Low",55.8)
         };


        [TestMethod]
        public void TestGetById()
        {
            ItemsController controller = new ItemsController();

            Assert.AreEqual(controller.Get(2).Id, items[1].Id);
            Assert.AreEqual(controller.Get(2).Name, items[1].Name);
            Assert.AreEqual(controller.Get(2).Quality, items[1].Quality);
            Assert.AreEqual(controller.Get(2).Quantity, items[1].Quantity);
        }


        //[TestMethod]
        //public void  TestGet()
        //{

        //    ItemsController controller = new ItemsController();
        //    Assert.IsTrue(controller.Get().Equals(items));
        //}
    }
}
