create table Adress
(
id int primary key,
nr int not null,
street varchar(30) not null,
city varchar(30) not null,
[post code] varchar(6)
);
GO;
------
create table Pubs
(
id int primary key,
name varchar(30) not null,
[adress id] int references Adress(id) not null
);
GO;
------
create table Producents
(
id int primary key,
name varchar(30) not null,
[adress id] int references Adress(id) not null
);
GO;
------
create table Products
(
id int primary key,
name varchar(30) not null,
[producent id] int references Producents(id) not null,
price money not null
);
GO;
------
create table Magazines
(
id int primary key,
name varchar(30) not null
);
GO;
------
create table Orders
(
id int primary key,
[magazine id] int references Magazines(id) not null,
[pub id] int references Pubs(id),
[producent id] int references Producents(id),
[Incoming/Outcoming] int not null,
status varchar(30) not null,
[date] date not null
);
GO;
------
create table [Order Details]
(
id int primary key,
[order id] int references Orders(id) not null,
quantity int not null,
[product id] int references Products(id) not null
);
GO;
------
create table [Magazines Stock]
(
id int primary key,
[magazine id] int references Magazines(id) not null,
[product id] int references Products(id) not null,
quantity int not null
);
GO;