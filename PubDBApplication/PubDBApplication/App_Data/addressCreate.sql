create table Address
(
id int primary key,
building_no int not null,
street varchar(30) not null,
city varchar(30) not null,
postal_code varchar(6)
);

create table Pubs
(
id int primary key,
name varchar(30) not null,
adress_id int references Address(id) not null
);

create table Producers
(
id int primary key,
name varchar(30) not null,
adress_id int references Address(id) not null
);

create table Products
(
id int primary key,
name varchar(30) not null,
producer_id int references Producers(id) not null,
price money not null,
alcohol_percentage int not null,
volume real not null
);

create table Warehouses
(
id int primary key,
name varchar(30) not null
);

create table Orders
(
id int primary key,
warehouse_id int references Warehouses(id) not null,
pub_id int references Pubs(id),
producer_id int references Producers(id),
[Incoming/Outcoming] int not null,
status varchar(30) not null,
[date] date not null
);

create table OrderDetails
(
id int primary key,
order_id int references Orders(id) not null,
quantity int not null,
product_id int references Products(id) not null
);

create table WarehousesStock
(
id int primary key,
warehouse_id int references Warehouses(id) not null,
product_id int references Products(id) not null,
quantity int not null
);
