using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Input;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Services;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Commands;
using FluentValidator;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler :
        Notifiable,
        ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<AddAddressCommand>
    {

        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {

            //  verificar cpf
            if (_repository.CheckDocument(command.Document))
            {
                AddNotification("Document", "Este cpf já está em uso");
                return null;
            }

            //  verificar email
            if (_repository.CheckEmail(command.EMail))
            {
                AddNotification("Email", "Esse email já está em uso");
                return null;
            }


            // criar VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.EMail);

            // criar entidade
            var customer = new Customer(name, document, email, command.Phone);

            //validar entidades e VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
            {
                return null;
            }

            // persistir no banco
            _repository.Save(customer);

            // Enviar email de boas Vindas
            _emailService.Send(email.Address, "Hello@balta.io", "Bem Vindo", "Seja bem vindo ao balta io");

            return new CreateCustomerCommandResult(customer.Id, name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
