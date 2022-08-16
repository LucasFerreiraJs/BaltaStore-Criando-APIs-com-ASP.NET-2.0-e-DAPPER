
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Entities;
using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Customer : Entity
    {
        //public string Firstname { get; private set; }
        //public string LastName { get; private set; }


        public readonly IList<Address> _address;

        public Name Name { get; set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Address { get { return _address.ToArray(); } }


        public Customer(
            Name name,
          Document document,
          Email email,
          string phone
        )
        {

            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            _address = new List<Address>();

        }

        public override string ToString()
        {
            return Name.ToString();
        }


        public void AddAdress(Address address) {
            // validar endereco

            // add endereco

            _address.Add(address);  
        }
    }

}