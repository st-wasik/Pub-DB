alter table Address
add check(building_no>0),
add column [RowVersion]  INT DEFAULT 1 NOT NULL;

alter table Pubs
add unique(name),
[e-mail] varchar(50) unique,
telephone_no varchar(12) unique,
add column [RowVersion]  INT DEFAULT 1 NOT NULL;

alter table Producers
add unique(name),
[e-mail] varchar(50) unique,
telephone_no varchar(12) unique,
add column [RowVersion]  INT DEFAULT 1 NOT NULL;

alter table Products
add unique(name),
check(price>0),
check(alcohol_percentage>0),
check(volume>0),
add column [RowVersion]  INT DEFAULT 1 NOT NULL;

alter table Warehouses
add unique(name),
add column [RowVersion]  INT DEFAULT 1 NOT NULL;

alter table Orders
alter column [Incoming/Outcoming] varchar(15);

alter table OrderDetails
add check(quantity>0);