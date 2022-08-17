using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Infra.StoreContext.DataContext;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BaltaStore.Infra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly BaltaDataContext _context;

        public CustomerRepository(BaltaDataContext context)
        {
            _context = context;
        }

        public bool CheckDocument(string document)
        {
            return _context
                .Connection
                .Query<bool>(
                    "spCheckDocument",
                    new { Document = document }, // Valor passado pro @parametro storedProcedure
                    commandType: CommandType.StoredProcedure
                ).FirstOrDefault();

            /*
               return _context
                    .Connection
                    .Query<bool>(
                        select * from customer 
                        where document=@document,
                        new { document = document }
                    ).FirstOrDefault();
             */

        }

        public bool CheckEmail(string email)
        {
            return _context
                .Connection
                .Query<bool>(
                    "spCheckEmail",
                    new { Email = email },
                    commandType: CommandType.StoredProcedure
                ).FirstOrDefault();
        }


        public void Save(Customer customer)
        {

            _context.Connection.Execute("spCreateCustomer",
                    new
                    {
                        Id = customer.Id,
                        FirstName = customer.Name.FirstName,
                        Lastname = customer.Name.LastName,
                        Document = customer.Document.Number,
                        Email = customer.Email.Address,
                        Phone = customer.Phone
                    },
                    commandType: CommandType.StoredProcedure
                );


            foreach (var address in customer.Address)
            {
                _context.Connection.Execute("spCreateAddress",
                    new
                    {
                        Id = address.Id,
                        CustomerId = customer.Id,
                        Number = address.Number,
                        Complement = address.Complement,
                        District = address.District,
                        City = address.City,
                        State = address.State,
                        Country = address.Country,
                        ZipCode = address.ZipCode,
                        Type = address.Type
                    }, commandType: CommandType.StoredProcedure
                    );
            }
        }

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            return _context
                .Connection
                .Query<CustomerOrdersCountResult>(
                    "spGetCustomerOrdersCount",
                    new { Document = document },
                    commandType: CommandType.StoredProcedure
                ).FirstOrDefault();
        }

        public IEnumerable<ListCustomerQueryResult> Get()
        {

            // List -> tem que colocar toList(); ao final da query
            return _context
                .Connection
                .Query<ListCustomerQueryResult>(
                    @"select 
                        [Id],
                        concat([Firstname], ' ', [Lastname]) as [Name],
                        [Document],
                        [Email]
                    from
                        [Customer]
                    ", new { }
                );
        }

        public GetCustomerQueryResult GetCustomer(Guid id)
        {
            return
               _context
               .Connection
               .Query<GetCustomerQueryResult>("SELECT [Id], CONCAT([FirstName], ' ', [LastName]) AS [Name], [Document], [Email] FROM [Customer] WHERE [Id]=@id", new { id = id })
               .FirstOrDefault();
        }

        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            return
              _context
              .Connection
              .Query<ListCustomerOrdersQueryResult>("", new { id = id });
        }
    }
}
