using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Input;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BaltaStore.Api.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _handler;

        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }


        [HttpGet]
        [Route("customers")]
        [ResponseCache(Duration = 60)]
        public IEnumerable<ListCustomerQueryResult> Get()
        {

            var customers = _repository.Get();
            return customers;

        }

        [HttpGet]
        [Route("customers/{id:Guid}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            var customer = _repository.GetCustomer(id);
            return customer;
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            var orders = _repository.GetOrders(id);
            return orders;
        }


        [HttpPost]
        [Route("customers")]
        //public CreateCustomerCommandResult Post(
        public Object Post(
            [FromBody] CreateCustomerCommand command
            )
        {

            var result = (CreateCustomerCommandResult)_handler.Handle(command);
            if (_handler.Invalid)
            {
                return BadRequest(_handler.Notifications);
            }


            return result;
        }



        //[HttpPut]
        //[Route("customers/{id}")]
        //public Customer Put(
        //    Guid id,
        //   [FromBody] CreateCustomerCommand command
        //    )
        //{
        //    var name = new Name(command.FirstName, command.LastName);
        //    var document = new Document(command.Document);
        //    var email = new Email(command.EMail);
        //    var customer = new Customer(name, document, email, command.Phone);

        //    return customer;
        //}


        //[HttpDelete]
        //[Route("customers/{id}")]
        //public object Delete(Guid id)
        //{


        //    return new { message = "cliente removido com sucesso" };
        //}


    }
}
