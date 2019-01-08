create table Address
(
id int primary key identity (1,1), 
building_no int not null,
street varchar(30) not null,
city varchar(30) not null,
postal_code varchar(6),
[RowVersion]  INT DEFAULT 1 NOT NULL,
constraint CKBuildNo check (building_no>0),
CONSTRAINT UniqAddress UNIQUE (building_no, street, city, postal_code)
);

create table Pubs
(
id int primary key identity (1,1),
name varchar(30) not null,
adress_id int references Address(id) not null,
[e-mail] varchar(50),
telephone_no varchar(12),
[RowVersion] INT DEFAULT 1 NOT NULL,
CONSTRAINT UniqNamePubs UNIQUE (name)
);

create table Producers
(
id int primary key identity (1,1),
name varchar(30) not null,
adress_id int references Address(id) not null,
[e-mail] varchar(50),
telephone_no varchar(12),
[RowVersion]  INT DEFAULT 1 NOT NULL,
CONSTRAINT UniqNameProducers unique(name)
);

create table Products
(
id int primary key identity (1,1),
name varchar(30) not null,
producer_id int references Producers(id) not null,
price money not null,
alcohol_percentage int not null,
volume real not null,
[RowVersion]  INT DEFAULT 1 NOT NULL,
CONSTRAINT UniqNameProducts unique(name),
constraint CKPrice check (price>0),
constraint CKVolume check (volume>0),
constraint CKAlco check (alcohol_percentage>0)
);

create table Warehouses
(
id int primary key identity (1,1),
name varchar(30) not null,
[RowVersion]  INT DEFAULT 1 NOT NULL,
CONSTRAINT UniqNameWarehouses unique(name)
);

create table Orders
(
id int primary key identity (1,1),
warehouse_id int references Warehouses(id) not null,
pub_id int references Pubs(id),
producer_id int references Producers(id),
[Incoming/Outcoming] varchar(15) not null,
status varchar(30) not null,
[date] datetime not null
);

create table OrderDetails
(
id int primary key identity (1,1),
order_id int not null,
quantity int not null,
product_id int references Products(id) not null,
constraint CKQuantityOD check (quantity>0),
constraint FKOrders foreign key (order_id) references Orders(id) on delete cascade
);

create table WarehousesStock
(
id int primary key identity (1,1),
warehouse_id int references Warehouses(id) not null,
product_id int references Products(id) not null,
quantity int not null,
constraint CKQuantityWS check (quantity>-1)
);
