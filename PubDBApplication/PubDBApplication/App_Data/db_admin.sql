:r C:\Users\St.Wasik\source\repos\Pub-DB\PubDBApplication\PubDBApplication\App_Data\tables\dropConstraints.sql

:r C:\Users\St.Wasik\source\repos\Pub-DB\PubDBApplication\PubDBApplication\App_Data\tables\createTables.sql

:r C:\Users\St.Wasik\source\repos\Pub-DB\PubDBApplication\PubDBApplication\App_Data\tables\dropTables.sql

:r C:\Users\St.Wasik\source\repos\Pub-DB\PubDBApplication\PubDBApplication\App_Data\tables\triggers.sql

:r C:\Users\St.Wasik\source\repos\Pub-DB\PubDBApplication\PubDBApplication\App_Data\procedures\procedures.sql

:r C:\Users\St.Wasik\source\repos\Pub-DB\PubDBApplication\PubDBApplication\App_Data\inserts\SQL_insert_address.sql

:r C:\Users\St.Wasik\source\repos\Pub-DB\PubDBApplication\PubDBApplication\App_Data\inserts\SQL_insert_pubs.sql
:r C:\Users\St.Wasik\source\repos\Pub-DB\PubDBApplication\PubDBApplication\App_Data\inserts\SQL_insert_producers.sql
:r C:\Users\St.Wasik\source\repos\Pub-DB\PubDBApplication\PubDBApplication\App_Data\inserts\SQL_insert_products.sql

:r C:\Users\St.Wasik\source\repos\Pub-DB\PubDBApplication\PubDBApplication\App_Data\inserts\SQL_insert_warehouses.sql

drop view ProducersView

insert into Address values (-1,' ', ' ', ' ', ' ')


drop function totalPrice



create function totalPrice (@id int)
returns money
begin
return (select COALESCE(SUM(od.quantity*p.price),0) from OrderDetails od join Products p on od.product_id = p.id where od.order_id = @id)
end

DECLARE @t INT
select @t = 1
select dbo.totalPrice(@t)




create trigger MinPrice on Orders
after update
as
begin
declare @id INT
select @id=id from updated
if((dbo.totalPrice(@id))<1000)
begin
RAISERROR('Order''s value cannot be less than 1000.',16,1);
rollback;
return
end
end

alter table Pubs 
drop constraint [UQ__Pubs__8A7656FC244AFD14]


delete from Address



select * from sys.



set identity_insert Warehouses off

alter trigger MinPrice on Orders
after update
as
begin
declare @id INT
select @id=id from inserted
if((dbo.totalPrice(@id))<1000)
begin
RAISERROR('Order''s value cannot be less than 1000.',16,1);
rollback;
return
end
end
GO













alter trigger MinPrice on Orders
after update
as
begin
declare @id INT
select into @id=id from inserted
if((dbo.totalPrice(@id))<1000)
begin
RAISERROR('Order''s value cannot be less than 1000.',16,1);
rollback;
return
end
end
GO

alter TRIGGER updateStock ON dbo.Orders
AFTER UPDATE
AS
DECLARE @prodId INT;
DECLARE @quantity INT;
DECLARE @warId INT = (SELECT warehouse_id FROM inserted);
DECLARE orderProducts CURSOR FOR SELECT product_id,quantity FROM dbo.OrderDetails,inserted WHERE order_id = inserted.id;
DECLARE @stockQuantity INT;
BEGIN

IF((SELECT 1 from inserted where status = 'Completed')>0)
BEGIN

If((SELECT 1 from inserted where [Incoming/Outcoming] = 'Incoming')>0) --z magazynu
BEGIN
OPEN orderProducts
FETCH NEXT FROM orderProducts INTO @prodId,@quantity;

WHILE @@FETCH_STATUS=0
BEGIN

SELECT @stockQuantity = quantity FROM WarehousesStock WHERE warehouse_id = @warId AND product_id = @prodId;

IF(@stockQuantity- @quantity >0)
BEGIN
BEGIN TRANSACTION Tran1;
UPDATE WarehousesStock
SET quantity = quantity - @quantity
WHERE warehouse_id = @warId AND product_id = @prodId;
COMMIT TRANSACTION Tran1;
END

ELSE
BEGIN
RAISERROR('Not enough stock in warehouse.',1,1);
ROLLBACK
END

FETCH NEXT FROM orderProducts INTO @prodId,@quantity;
END
END

ELSE --do magazynu
BEGIN
OPEN orderProducts
FETCH NEXT FROM orderProducts INTO @prodId,@quantity;

WHILE @@FETCH_STATUS=0
BEGIN

IF((SELECT 1 FROM WarehousesStock WHERE warehouse_id = @warId AND product_id = @prodId) > 0) -- jesli istnieje wpis
BEGIN
BEGIN TRANSACTION Tran2;
UPDATE WarehousesStock
SET quantity = quantity + @quantity
WHERE warehouse_id = @warId AND product_id = @prodId;
COMMIT TRANSACTION Tran2;
END

ELSE --jesli nowy produkt
BEGIN
BEGIN TRANSACTION Tran3;
INSERT INTO WarehousesStock VALUES (@warId,@prodId,@quantity);
COMMIT TRANSACTION Tran3;
END
FETCH NEXT FROM orderProducts INTO @prodId,@quantity;
END
END

CLOSE orderProducts
DEALLOCATE orderProducts

END

END


create view mostPopularProducers as
	select p.name, placedOrdersCount from (
		select producer_id, COUNT(*) placedOrdersCount from Orders o
		where producer_id is not null AND status = 'Completed'
		group by o.producer_id
		order by count(*) desc offset 0 rows
	) subq join Producers p on subq.producer_id = p.id

