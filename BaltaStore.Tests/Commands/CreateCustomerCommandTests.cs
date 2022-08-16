using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Tests.Commands
{

    [TestClass]
    public class CreateCustomerCommandTests
    {


        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Lucas";
            command.LastName = "Teste";
            command.Document = "28659170377";
            command.EMail = "apenasumteste@gmail.com";
            command.Phone = "11999999997";

            Assert.AreEqual(true, command.Valid());

        }

    }
}
