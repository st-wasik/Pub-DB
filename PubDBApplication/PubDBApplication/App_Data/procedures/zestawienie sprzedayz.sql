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

--select * from customerStats(1)

--drop function customerStats