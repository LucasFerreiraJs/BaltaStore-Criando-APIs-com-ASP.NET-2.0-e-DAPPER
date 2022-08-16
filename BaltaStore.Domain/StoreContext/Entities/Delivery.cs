using BaltaStore.Domain.StoreContext.Enums;
using FluentValidator;
using BaltaStore.Shared.Entities;
using System;

namespace BaltaStore.Domain.StoreContext.Entities
{

    public class Delivery : Entity
    {

        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }


        public Delivery(DateTime estimatedDeliveryDate) {
            CreateDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }


        public void Ship() {

            // não entregar para datas no passado
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel() {

            Status = EDeliveryStatus.Canceled;
        }
        
    }
}