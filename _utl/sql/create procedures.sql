


-- create PROCEDURE spCheckDocument
--     @Document char(11)
-- as
--     select case when exists(
--         select [id]
--         from [Customer]
--         where [Document] = @Document

--     )
--     then cast(1 as bit)
--     else cast(0 as bit) 
-- end



-- create procedure spCheckEmail
--     @Email varchar(160)
-- as 
--     select case when exists(
--         select [Id]
--         from [Customer]
--         where [Email] = @Email
--     )  
--     then cast (1 as bit)
--     else cast (0 as bit)
-- end



-- create procedure spCreateAddress
--     @Id UNIQUEIDENTIFIER,
--     @CustomerId UNIQUEIDENTIFIER,
--     @Number varchar(10),
--     @Complement varchar(60),
--     @District varchar(60),
--     @City varchar(60),
--     @State char(2),
--     @Country char(2),
--     @ZipCode char(8),
--     @Type int

-- as
-- insert into [Address]
--     (
--     [Id],
--     [CustomerId],
--     [Number],
--     [Complement],
--     [District],
--     [City],
--     [State],
--     [Country],
--     [ZipCode],
--     [Type]

--     )
--     values(
--         @Id,
--         @CustomerId,
--         @Number,
--         @Complement,
--         @District,
--         @City,
--         @State,
--         @Country,
--         @ZipCode,
--         @Type
--     )


-- create procedure [spCreateCustomer]
--     @Id  UNIQUEIDENTIFIER,
--     @FirstName varchar(40),
--     @LastName varchar(40),
--     @Document char(11),
--     @Email varchar(160),
--     @Phone varchar(13)
-- as
-- insert into [Customer]
--     (
--     [Id],
--     [FirstName],
--     [LastName],
--     [Document],
--     [Email],
--     [Phone]

--     )
-- values(
--         @Id,
--         @FirstName,
--         @LastName,
--         @Document,
--         @Email,
--         @Phone
--     )



create procedure [spGetCustomerOrdersCount]
    @Document char(11)
as
    select 
        c.[Id],
        concat(c.[FirstName],' ', c.[LastName]) as [Name],
        [Document]
    from 
        [Customer] as c
    where 
        c.[document] = @Document

