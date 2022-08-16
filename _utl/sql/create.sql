

create Database BaltaStore;
use BaltaStore;

create table [Customer](
    [Id] UNIQUEIDENTIFIER primary key NOT NULL,
    [FirstName] varchar(40) not null,
    [LastName] varchar(40) not null,
    [Document] char(11) not null,
    [Email] varchar(160) not null,
    [Phone] varchar(13) not null
)


create table[Address](
    [Id] UNIQUEIDENTIFIER primary key not null,
    [CustomerId] UNIQUEIDENTIFIER not null,
    [Number] varchar(10) NOT NULL,
    [Complement] varchar(40) not null,
    [District] varchar(60) not null,
    [City] varchar(60) not null,
    [State] char(2) not null,
    [Country] char(2) not null,
    [ZipCode] char(8) not null,
    [Type] int not null default(1),
    FOREIGN key ([CustomerId]) references [Customer]([Id])
) 


create table [Product](
    [Id] UNIQUEIDENTIFIER primary key not null,
    [Title] varchar(255) not null,
    [Description] text not null,
    [image] varchar(1024) not null,
    [Price] money not null,
    [QuantityOnHand] decimal(10,2) not null
    
)
 

create table [Order](
    [Id] UNIQUEIDENTIFIER primary key not null,
    [CustomerId] UNIQUEIDENTIFIER not null,
    [CreateDate] datetime not null default(getdate()),
    [Status] int not null default(1),
    foreign key ([CustomerId]) references [Customer]([Id])    
)


create table [OrderItem](
    [Id] UNIQUEIDENTIFIER not null,
    [OrderId] UNIQUEIDENTIFIER not null,
    [ProductId] UNIQUEIDENTIFIER not null,
    [Quantity] decimal(10,2) not null,
    [Price] Money not null,
    FOREIGN key([OrderId]) references [Order]([Id]),
    foreign key([ProductId]) references [Product]([Id])
 )



create table [Delivery](
    [Id] UNIQUEIDENTIFIER primary key not null,
    [OrderId] UNIQUEIDENTIFIER not null,
    [CreateDate] Datetime not null Default(getDate()),
    [EstimatedDeliveryDate] DateTime not null,
    [Status] int not null default(1),
    foreign key ([OrderId]) references [Order]([Id])

)

