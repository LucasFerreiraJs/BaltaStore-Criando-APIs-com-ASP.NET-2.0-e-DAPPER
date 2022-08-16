using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {

        public string Address { get; set; }
        public Email(string address)
        {
            Address = address;


            AddNotifications(new ValidationContract()
                .Requires()
                .IsEmail(Address, "Email", "Email inválido")

                );
        }

        public override string ToString()
        {
            return $"{Address}";
        }
    }
}
