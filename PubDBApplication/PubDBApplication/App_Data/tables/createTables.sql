create table Address
(
id int primary key identity (1,1), 
building_no int not null check(building_no>0),
street varchar(30) not null,
city varchar(30) not null,
postal_code varchar(6)
);

create table Pubs
(
id int primary key identity (1,1),
name varchar(30) not null unique,
adress_id int references Address(id) not null,
e-mail varchar(50) not null unique
);

create table Producers
(
id int primary key identity (1,1),
name varchar(30) not null unique,
adress_id int references Address(id) not null,
e-mail varchar(50) not null unique
);

create table Products
(
id int primary key identity (1,1),
name varchar(30) not null unique,
producer_id int references Producers(id) not null,
price money not null check(price>0),
alcohol_percentage int not null check(alcohol_percentage>0),
volume real not null check(volume>0)
);

create table Warehouses
(
id int primary key identity (1,1),
name varchar(30) not null unique
);

create table Orders
(
id int primary key identity (1,1),
warehouse_id int references Warehouses(id) not null,
pub_id int references Pubs(id),
producer_id int references Producers(id),
[Incoming/Outcoming] varchar(15) not null,
status varchar(30) not null,
[date] date not null
);

create table OrderDetails
(
id int primary key identity (1,1),
order_id int references Orders(id) not null,
quantity int not null check(quantity>0),
product_id int references Products(id) not null
);

create table WarehousesStock
(
id int primary key identity (1,1),
warehouse_id int references Warehouses(id) not null,
product_id int references Products(id) not null,
quantity int not null
);
