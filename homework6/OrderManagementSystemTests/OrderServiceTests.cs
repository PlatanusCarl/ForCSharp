﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderManagementSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        OrderService orderService = new OrderService();

        OrderItem item1 = new OrderItem(1, 10, 1);
        OrderItem item2 = new OrderItem(2, 5, 10);
        OrderItem item3 = new OrderItem(3, 15, 100);

        [TestInitialize]
        public void init()
        {

        }

        [TestMethod()]
        public void addOrderTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void deleteOrderTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void editOrderTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void searchOrderTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void searchOrderTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void searchOrderTest2()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void sortOrderTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ExportTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ImportTest()
        {
            Assert.Fail();
        }
    }
}