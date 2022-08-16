using BaltaStore.Domain.StoreContext.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BaltaStore.Api.Controllers
{
    public class CustomerController : Controller
    {

        [HttpGet]
        [Route("customers")]
        public List<Customer> Get()
        {

            return null;

        }

        [HttpGet]
        [Route("Customer/{id}")]
        public Customer GetById(Guid id)
        {

            return null;
        }

        [HttpGet]
        [Route("Customer/{id}/orders")]
        public List<Order> GetOrders(Guid id)
        {

            return null;
        }


        [HttpPost]
        [Route("customers")]
        public Customer Post(
            [FromBody] Customer customer
            )
        {
            return null;
        }



        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put(
            Guid id,
           [FromBody] Customer customer
            )
        {
            return null;
        }


        [HttpDelete]
        [Route("customers/{id}")]
        public string Delete(
            Guid id
            )
        {
            return null;
        }


    }
}
