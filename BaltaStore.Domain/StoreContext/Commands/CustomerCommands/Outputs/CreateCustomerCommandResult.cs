﻿using BaltaStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs
{
    public class CreateCustomerCommandResult : ICommandResult
    {
        public CreateCustomerCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }



        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        /*

public CreateCustomerCommandResult() { }

public CreateCustomerCommandResult(Guid id, string name, string email)
{
 Id = id;
 Name = name;
 Email = email;
}

public Guid Id { get; set; }
public string Name{ get; set; }
public string Email{ get; set; }
*/
    }
}
