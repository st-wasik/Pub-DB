alter table Adress
add check(building_no>0);

alter table Pubs
add unique(name),
e-mail varchar(50) not null unique;

alter table Producers
add unique(name),
e-mail varchar(50) not null unique;

alter table Products
add unique(name),
check(price>0),
check(alcohol_percentage>0),
check(volume>0);

alter table Warehouses
add unique(name);

alter table Orders
alter column [Incoming/Outcoming] varchar(15);

alter table OrderDetails
add check(quantity>0);