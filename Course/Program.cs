using System;
using System.Collections.Generic;
using System.Linq;
using EFCoreCourse.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertBulkData();
            InsertOrder();
            Query();
        }

        private static void Query()
        {
            using var db = new Data.ApplicationContext();
            var queryByMethod = db.Products
                                .Where(p=>p.ProductType!=ValueObjects.ProductType.GoodsForResale)
                                .OrderBy(p=>p.Id)
                                .ToList();

            var orderQueryByMethod = db.Orders
                                .Include(p=>p.Itens)
                                .ThenInclude(p=>p.Product)
                                .ToList();
        }

        private static void InsertOrder()
        {
            using var db = new Data.ApplicationContext();

            var client = db.Clients.FirstOrDefault();
            var product = db.Products.FirstOrDefault();

            var order = new Order 
            {
                ClientId = client.Id,
                OrderStatus =ValueObjects.OrderStatus.Completed,
                Note="teste",
                ShippintType=ValueObjects.ShippingType.CIF,               
                BeginIn = DateTime.Now,
                EndIn = DateTime.Now,
                Itens = new List<OrderItem>
                {
                    new OrderItem
                    {
                        ProductId = product.Id,
                        Discount = 0,
                        Quantity = 1,
                        Value = 10,
                    }
                }            
            };   

            db.Orders.Add(order);
            db.SaveChanges();        

        }

        private static void InsertBulkData()
        {
            var product = new Product
            {
                Description = "Product test",
                BarCode = "1234567890",
                Value = 10,
                ProductType = ValueObjects.ProductType.GoodsForResale,
                Status = true                
            };

            var productList = new[]
            {
                new Product
                {
                    Description = "Product test2",
                    BarCode = "123456000",
                    Value = 10,
                    ProductType = ValueObjects.ProductType.GoodsForResale,
                    Status = true                
                },
                new Product
                {
                    Description = "Product Service",
                    BarCode = "1234567890",
                    Value = 50,
                    ProductType = ValueObjects.ProductType.Service,
                    Status = true                
                },
                new Product
                {
                    Description = "Product Package",
                    BarCode = "123344450",
                    Value = 1,
                    ProductType = ValueObjects.ProductType.Package,
                    Status = true                
                },
            };



            var client = new Client
            {
                Name = "Gabriel Pedroso",
                PostalCode = "12244858",
                City = "SJC",
                State= "SP",
                Phone = "996582594",
            };

            using var db = new Data.ApplicationContext();
            // db.AddRange(product, client);
            db.Products.AddRange(productList);
            var registers = db.SaveChanges();
            Console.WriteLine($"Total: {registers} ");        
        }
    }
}
