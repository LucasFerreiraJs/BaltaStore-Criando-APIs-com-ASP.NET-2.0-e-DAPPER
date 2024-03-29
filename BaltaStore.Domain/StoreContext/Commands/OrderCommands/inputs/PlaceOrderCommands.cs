﻿using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Domain.StoreContext.Commands.OrderCommands.inputs
{
    public class PlaceOrderCommands: Notifiable, ICommand
    {

        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }


        public PlaceOrderCommands() {
            OrderItems = new List<OrderItemCommand>();
        }

        public bool Valid() {

            AddNotifications(new ValidationContract()
                .HasLen(Customer.ToString(), 36, "Customer", "Identificador do Cliente inválido")
                .IsGreaterThan(OrderItems.Count, 0, "Items", "Nenhum  item do pedido foi encontrado")
                );

            return IsValid;
        }
    }

    public class OrderItemCommand
    {
        public Guid Product { get; set; }

        public decimal Quantity { get; set; }
    }

}
