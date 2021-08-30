using System;
using System.Collections.Generic;
using EFCoreCourse.ValueObjects;

namespace EFCoreCourse.Domain
{
    public class Order
    {
        public int Id {get; set;}
        public int ClientId {get; set;}
        public Client Client {get; set;}
        public DateTime BeginIn {get; set;}
        public DateTime EndIn {get; set;}
        public OrderStatus OrderStatus {get; set;}
        public ShippingType ShippintType {get; set;}
        public string Note {get; set;}
        public ICollection<OrderItem> Itens {get; set;}
    }
}