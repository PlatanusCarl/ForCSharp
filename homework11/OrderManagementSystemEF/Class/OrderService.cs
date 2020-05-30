using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrderManagementSystemEF.Class
{
    public class OrderService
    {
        public static Order Get(string id)
        {
            using (var entity = new OrderContext())
            {
                return entity.Orders.Find(id);
            }
        }
        public static List<Order> GetAll()
        {
            using (var entity = new OrderContext())
            {
                return entity.Orders.ToList();
            }
        }
        public static void Add(Order order)
        {
            using (var entity = new OrderContext())
            {
                try
                {
                    entity.Orders.Add(order);
                    entity.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach(var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach(var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("属性：{0}错误{1} ",
                                    validationError.PropertyName,
                                    validationError.ErrorMessage);
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
        public static void Remove(string id)
        {
            using (var entity = new OrderContext())
            {
                try
                {
                    entity.Orders.Find(id).ItemList.Clear();
                    entity.Orders.Remove(entity.Orders.Find(id));
                    entity.SaveChanges();
                }
                catch(DbUpdateException ex)
                {
                    Console.WriteLine(ex.InnerException.ToString());
                }
            }
        }

        public static void Edit(string id,Order order)
        {
            using (var entity = new OrderContext())
            {
                try
                {
                    Order order1 = entity.Orders.Find(id);
                    entity.Orders.Remove(new Order(id));
                    entity.Orders.Add(new Order(order1.CustomerId, order.ItemList));
                    entity.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static  List<Order> QueryByCustomer(string customername)
        {
            using (var entity = new OrderContext())
            {
                var query = from o in entity.Orders
                            where o.Customer.Name == customername
                            orderby o.Customer.Name
                            select o;
                return query.ToList<Order>();
            }
        }
        public static List<Order> QueryByItem(string itemid)
        {
            OrderItem orderitem = new OrderItem();
            orderitem.ItemId = itemid;
            using (var entity = new OrderContext())
            {
                var query = from o in entity.Orders
                            where o.ItemList.TrueForAll(orderitem.Same)
                            select o;
                return query.ToList<Order>();
            }
        }
        public static void Export(string path)
        {
            XmlSerializer xmlserializer = new XmlSerializer(typeof(List<Order>));
                using (FileStream exportStream = new FileStream(path, FileMode.Create))
                {
                    try
                    {
                        xmlserializer.Serialize(exportStream, GetAll());
                    }
                    catch(InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.InnerException.StackTrace);
                        Console.WriteLine(ex.InnerException.Message);
                        Console.WriteLine(ex.InnerException.Source);
                   }

                }
        }
        public static void Import(string path)
        {
            XmlSerializer xmlserializer = new XmlSerializer(typeof(List<Order>));
            using (var entity = new OrderContext())
            {
                using (FileStream importStream = new FileStream(path, FileMode.Open))
                {
                    try
                    {
                        List<Order> temp = (List<Order>)xmlserializer.Deserialize(importStream);
                        temp.ForEach(o =>
                        {
                            if (!entity.Orders.Contains(o))
                                entity.Orders.Add(o);
                        });
                        entity.SaveChanges();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
