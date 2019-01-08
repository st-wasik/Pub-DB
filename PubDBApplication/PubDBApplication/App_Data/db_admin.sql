:r C:\Users\St.Wasik\source\repos\Pub-DB\PubDBApplication\PubDBApplication\App_Data\tables\dropConstraints.sql

:r C:\Users\St.Wasik\source\repos\Pub-DB\PubDBApplication\PubDBApplication\App_Data\tables\createTables.sql

:r C:\Users\St.Wasik\source\repos\Pub-DB\PubDBApplication\PubDBApplication\App_Data\tables\dropTables.sql

:r C:\Users\St.Wasik\source\repos\Pub-DB\PubDBApplication\PubDBApplication\App_Data\tables\triggers.sql

:r C:\Users\St.Wasik\source\repos\Pub-DB\PubDBApplication\PubDBApplication\App_Data\procedures\procedures.sql

select name from sys

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


