create view AddingToPubs
AS
SELECT p.name, a.building_no, a.street, a.city, a.postal_code FROM Pubs p join Address a on p.adress_id=a.id;

create view ProducersView as
select p.id, p.name, p.[e-mail], p.telephone_no, a.street, a.building_no, a.postal_code, a.city 
from Producers p join [Address] a on p.adress_id = a.id

create view PubsView as
select p.id, p.name, p.[e-mail], p.telephone_no, a.street, a.building_no, a.postal_code, a.city 
from Pubs p join Address a on p.adress_id = a.id

create view ProductsView as
select p.id, p.name, pr.name as producer_name, p.price, p.alcohol_percentage, p.volume 
from Products p join Producers pr on p.producer_id = pr.id

create view OrdersView as
select o.id, w.name as warehouse_name, pu.name as pub_name, pr.name as producer_name, o.[Incoming/Outcoming], o.status, o.date 
from Orders o join Warehouses w on o.warehouse_id = w.id join 
	Pubs pu on o.pub_id = pu.id join
	Producers pr on o.producer_id = pr.id

create view OrderDetailsView as
select o.id, o.order_id, o.quantity, p.name as product_name from OrderDetails o join Products p on o.product_id=p.id

create view WarehousesStockView as
select ws.id, w.name as warehouse_name, p.name as product_name, ws.quantity 4
from WarehousesStock ws join Warehouses w on ws.warehouse_id=w.id join
	Products p on ws.product_id = p.id


