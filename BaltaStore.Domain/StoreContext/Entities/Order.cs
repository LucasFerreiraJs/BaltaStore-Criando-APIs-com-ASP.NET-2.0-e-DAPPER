using BaltaStore.Domain.StoreContext.Enums;
using FluentValidator;
using System;
using BaltaStore.Shared.Entities;

using System.Collections.Generic;
using System.Linq;

namespace BaltaStore.Domain.StoreContext.Entities
{

    public class Order : Entity
    {

        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items { get { return _items.ToArray(); } }
        //public IList<OrderItem> Items { get; private set; }
        public IList<Delivery> Deliveries => _deliveries.ToArray();



        public Order(Customer customer)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }


        public void AddItem(Product prod, decimal quantity)
        {

            if (prod.QuantityOnHand < quantity)
            {
                AddNotification("orderItem", $"Produto {prod.Title} não tem {quantity} em estoque");
            }

            var item = new OrderItem(prod, quantity);
            _items.Add(item);
        }



        public void AddDelivery(Delivery delivery)
        {
            _deliveries.Add(delivery);
        }


        //  criar um pedido
        public void Place()
        {
            //gera numero pedido
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();

            // validar 
            if (_items.Count == 0)
            {
                AddNotification("Order", "Este pedido não possui itens");
            }
        }

        // pgar um pedido

        public void Pay()
        {

            Status = EOrderStatus.Paid;
        }

        //enviar um pedido
        public void Ship()
        {

            // a cada 5 produtos = uma nova entrega
            var deliveries = new List<Delivery>();
            int count = 1;

            foreach (var item in _items)
            {
                if (count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
            }

            // envia e add aas entregas
            deliveries.ForEach(item => item.Ship());
            deliveries.ForEach(item => _deliveries.Add(item));

        }

        //cancelar um pedido
        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(item => item.Cancel());
        }

    }
}