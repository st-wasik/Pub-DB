create view ProductsView as
select p.id, p.name, pr.name as producer_name, p.price, p.alcohol_percentage, p.volume, p.RowVersion
from Products p join Producers pr on p.producer_id = pr.id

create view OrdersView as
select o.id, w.name as warehouse_name, pu.name as pub_name, pr.name as producer_name, o.[Incoming/Outcoming], o.status, o.date, dbo.totalPrice(o.id) as total
from Orders o 
	 join Warehouses w on o.warehouse_id = w.id 
	 left join Pubs pu on o.pub_id = pu.id 
	 left join Producers pr on o.producer_id = pr.id

create view OrderDetailsView as
select o.id, o.order_id, p.name as product_name, o.quantity, p.price, ROUND(o.quantity*p.price,2) as amount from OrderDetails o join Products p on o.product_id=p.id

create view WarehousesStockView as
select ws.id, w.name as warehouse_name, p.name as product_name, ws.quantity
from WarehousesStock ws join Warehouses w on ws.warehouse_id=w.id join
	Products p on ws.product_id = p.id
	
create view mostPopularProducers as
	select p.name, placedOrdersCount from (
		select producer_id, COUNT(*) placedOrdersCount from Orders o
		where producer_id is not null AND status = 'Completed'
		group by o.producer_id
		order by count(*) desc offset 0 rows
	) subq join Producers p on subq.producer_id = p.id

