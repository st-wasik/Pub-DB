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
adress_id int not null,
[e-mail] varchar(50),
telephone_no varchar(12),
[RowVersion] INT DEFAULT 1 NOT NULL,
CONSTRAINT UniqNamePubs UNIQUE (name),
constraint FKPubsAddress foreign key (adress_id) references Address(id)
);

create table Producers
(
id int primary key identity (1,1),
name varchar(30) not null,
adress_id int not null,
[e-mail] varchar(50),
telephone_no varchar(12),
[RowVersion]  INT DEFAULT 1 NOT NULL,
CONSTRAINT UniqNameProducers unique(name),
constraint FKProducersAddress foreign key (adress_id) references Address(id)
);

create table Products
(
id int primary key identity (1,1),
name varchar(30) not null,
producer_id int not null,
price money not null,
alcohol_percentage int not null,
volume real not null,
[RowVersion]  INT DEFAULT 1 NOT NULL,
CONSTRAINT UniqNameProducts unique(name),
constraint CKPrice check (price>0),
constraint CKVolume check (volume>0),
constraint CKAlco check (alcohol_percentage>0),
constraint FKProducer foreign key (producer_id) references Producers(id)
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
warehouse_id int not null,
pub_id int,
producer_id int,
[Incoming/Outcoming] varchar(15) not null,
status varchar(30) not null,
[date] datetime not null,
constraint FKOrdersPubs foreign key (pub_id) references Pubs(id),
constraint FKOrdersProducers foreign key (producer_id) references Producers(id),
constraint FKOrdersWarehouses foreign key (warehouse_id) references Warehouses(id)
);

create table OrderDetails
(
id int primary key identity (1,1),
order_id int not null,
quantity int not null,
product_id int not null,
constraint CKQuantityOD check (quantity>0),
constraint FKOrders foreign key (order_id) references Orders(id) on delete cascade,
constraint FKODProducts foreign key (product_id) references Products(id)
);

create table WarehousesStock
(
id int primary key identity (1,1),
warehouse_id int not null,
product_id int not null,
quantity int not null,
constraint CKQuantityWS check (quantity>-1),
constraint FKWSWarehouses foreign key (warehouse_id) references Warehouses(id),
constraint FKWSProducts foreign key (product_id) references Products(id)
);
