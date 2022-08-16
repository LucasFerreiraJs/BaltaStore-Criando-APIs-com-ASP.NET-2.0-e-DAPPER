using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Input;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Shared.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {


        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid() {

            var command = new CreateCustomerCommand();
            command.FirstName = "Lucas";
            command.LastName = "Teste";
            command.Document = "28659170377";
            command.EMail = "apenasumteste@gmail.com";
            command.Phone = "11999999997";

            Assert.AreEqual(true, command.Valid());

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(command);

            Assert.AreEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);

        }
    }
}
