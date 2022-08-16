using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Input
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }



        public bool Valid()
        {


            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 40, "FirstName", "O nome deve conter no máximo 40 caracteres")
                .HasMinLen(LastName, 3, "LastName", "O sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(LastName, 40, "LastName", "O sobrenome deve conter no máximo 40 caracteres")
                .IsEmail(EMail, "Email", "O Email é inválido")
                .HasLen(Document, 11, "Document", "CPF inválido")
                );

            return IsValid;
        }

    }
}
