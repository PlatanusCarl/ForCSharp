using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderManagementSystem;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
            nlist<OrderItem> list1 = new nlist<OrderItem> { item1, item2, item3 };
            Order order1 = new Order(1, "Li",list1);

            nlist<OrderItem> list2 = new nlist<OrderItem> { item2, item3, item1 };
            Order order2 = new Order(2, "Li", list2);

            nlist<OrderItem> list3 = new nlist<OrderItem> { };
            Order order3 = new Order(3, "Zhao", list3);

            orderService = new OrderService();
            orderService.addOrder(order1);
            orderService.addOrder(order3);
            orderService.addOrder(order2);
        }

        [TestMethod()]
        public void addOrderTest()
        {
            Order order4 = new Order();
            orderService.addOrder(order4);
            Assert.AreEqual(4,orderService.orderList.Count);
            CollectionAssert.Contains(orderService.orderList, order4);
        }

        [TestMethod()]
        public void deleteOrderTest()
        {
            Order order30 = new Order(3, "Zhao");
            orderService.deleteOrder(order30);
            Assert.AreEqual(2, orderService.orderList.Count);
            CollectionAssert.DoesNotContain(orderService.orderList,order30);
        }

        [TestMethod()]
        public void editOrderTest()
        {
            Order order30 = new Order(3, "Li");
            orderService.editOrder(order30);
            Assert.IsFalse(orderService.orderList[2].Customer == "Zhao");
        }

        [TestMethod()]
        public void searchOrderTest()
        {
            Order order30 = new Order(3, "Zhao");
            Assert.IsTrue(orderService.searchOrder(3).Equals(order30));
            Assert.IsTrue(orderService.searchOrder(4) == null);
        }

        [TestMethod()]
        public void searchOrderTest1()
        {
            Order order30 = new Order(3, "Zhao");
            Assert.IsTrue(orderService.searchOrder("Zhao").Equals(order30));
            Assert.IsTrue(orderService.searchOrder("Sun") == null);
        }

        [TestMethod()]
        public void searchOrderTest2()
        {
            Assert.IsTrue(orderService.searchOrder(item1).Count > 0);
        }

        [TestMethod()]
        public void sortOrderTest()
        {
            Order order10 = new Order(1, "Li");
            Order order20 = new Order(2, "Li");
            Order order30 = new Order(3, "Zhao");

            List<Order> ls =new List<Order> {order10,order20,order30};
            orderService.sortOrder();

            int flag = 1, i =0;
            foreach(Order o in orderService.orderList)
            {
                if (!o.Equals(ls[i]))
                    flag = 0;
                i++;
            }
            Assert.AreEqual(flag, 1);
        }

        [TestMethod()]
        public void ExportTest()
        {
            orderService.Export("C:\\Users\\Platanus\\Desktop\\new.xml");
            Assert.IsTrue(File.Exists("C:\\Users\\Platanus\\Desktop\\new.xml"));
        }

        [TestMethod()]
        public void ImportTest()
        {
            Order order10 = new Order(1, "Li");
            Order order20 = new Order(2, "Li");
            Order order30 = new Order(3, "Zhao");
            orderService.deleteOrder(order10);
            orderService.deleteOrder(order20);
            orderService.deleteOrder(order30);

            orderService.Import("C:\\Users\\Platanus\\Desktop\\new.xml");
            Assert.AreEqual(3, orderService.orderList.Count);
        }
    }
}