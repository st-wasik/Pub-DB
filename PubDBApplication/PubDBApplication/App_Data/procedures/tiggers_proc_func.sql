create trigger RequiredData on Orders
after insert
as
begin
	if((
		select 1 from Pubs p, inserted where p.id = inserted.pub_id and p.[e-mail] is null and p.telephone_no is null
		union
		select 1 from Producers r, inserted where r.id = inserted.producer_id and r.[e-mail] is null and r.telephone_no is null
	)>0)
	begin
		RAISERROR('E-mail or telephone numer required to place an order.',16,1);
		rollback
		return
	end
end

GO

create trigger MinPrice on Orders
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

CREATE TRIGGER updateStock ON dbo.Orders
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

GO

create unique index UniqTelProducers on Producers(telephone_no) where telephone_no is not null
GO
create unique index UniqTelPubs on Pubs(telephone_no) where telephone_no is not null
GO
create unique index UniqEmailProducers on Producers([e-mail]) where [e-mail] is not null
GO
create unique index UniqEmailPubs on Pubs([e-mail]) where [e-mail] is not null
GO

CREATE FUNCTION saleStats (@days INT)
returns @stats TABLE
(minOrderAmount MONEY, maxOrderAmount MONEY, avgOrderAmount MONEY, sumOrderAmount MONEY,
	totalSoldQuantity INT, servedCustomers INT, mostPopularProduct VARCHAR(30))
AS
BEGIN
DECLARE @tempOrders TABLE (id INT, pub_id INT)
DECLARE @tempDetails TABLE (product_name VARCHAR(30), quantity INT)
DECLARE @tempPrices TABLE (orderAmount MONEY)
DECLARE @customersCount INT
DECLARE @min MONEY;
DECLARE @max MONEY;
DECLARE @avg MONEY;
DECLARE @sum MONEY;
DECLARE @totalQ INT;
DECLARE @productName VARCHAR(30);

INSERT INTO @tempOrders
	SELECT id, pub_id FROM Orders WHERE DATEDIFF(DAY, Orders.date ,SYSDATETIME()) <=@days AND
										status = 'Completed' AND [Incoming/Outcoming] = 'Incoming' AND
										pub_id is not null
INSERT INTO @tempDetails
	SELECT  product_name, quantity from OrderDetailsView where order_id in (select id from @tempOrders)

SELECT @customersCount = COUNT(distinct pub_id) FROM @tempOrders

IF (SELECT COUNT(*) FROM @tempOrders) = 0 OR @customersCount = 0
BEGIN RETURN END

INSERT INTO @tempPrices
	SELECT dbo.totalPrice(id) as orderAmount FROM @tempOrders;

SELECT @min = MIN(orderAmount) FROM @tempPrices
SELECT @max =  MAX(orderAmount) FROM @tempPrices
SELECT @avg =  (SUM(orderAmount) / @customersCount) FROM @tempPrices
SELECT @sum = SUM(orderAmount) FROM @tempPrices
SELECT @totalQ = SUM(quantity) FROM @tempDetails
SELECT TOP 1 @productName = product_name from 
(
	SELECT product_name, SUM(quantity) as totalQuantity from @tempDetails group by product_name
) subquery order by totalQuantity desc

INSERT INTO @stats values(@min, @max, @avg, @sum, @totalQ, @customersCount, @productName )
RETURN
END

GO

--Zestawienie sprzedaży dla podanego klienta za ostatni miesiąc (LINQ)
create function customerStats (@customerId INT)
returns @productsList TABLE
(	
	ProductName varchar(30),
	Quantity INT,
	Amount MONEY
)
as
begin
DECLARE @orders TABLE (id INT);
insert into @orders 
	select id from Orders where pub_id = @customerId AND 
								DATEDIFF(DAY, Orders.date ,SYSDATETIME()) <= 31 AND
								Orders.status = 'Completed'

if ((select COUNT(*) from @orders) = 0) BEGIN RETURN END

INSERT INTO @productsList 
	select product_name, SUM(quantity), SUM(amount) from OrderDetailsView 
		where order_id in (select id from @orders) group by product_name 
RETURN 
END

GO

create function totalPrice (@id int)
returns money
begin
return (select COALESCE(SUM(od.quantity*p.price),0) from OrderDetails od join Products p on od.product_id = p.id where od.order_id = @id)
end

GO










