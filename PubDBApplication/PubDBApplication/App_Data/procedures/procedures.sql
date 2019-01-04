create procedure createRaport @Id int
AS
if(@Id<1)
begin
RAISERROR('NIE MOZNA PODAC ID MNIEJSZEGO NIZ 1',16,1)
return
end
SELECT * FROM OrderDetails od JOIN Orders o on od.order_id = o.id WHERE o.pub_id=@Id;



CREATE FUNCTION getSaleStatistics (@days INT)
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
