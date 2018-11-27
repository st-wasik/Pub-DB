create trigger InsertingToPubsView on PubsView
instead of insert
as
begin
begin try
insert into Address 
select building_no, street, city, postal_code
from inserted;
end try
begin catch
select ERROR_MESSAGE() as Error_message;
end catch
insert into Pubs(name,adress_id) select name, (select a.id from Address a where a.street = inserted.street and a.building_no = inserted.building_no and
a.city = inserted.city and a.postal_code = inserted.postal_code) 
from inserted;
end

create trigger Address_build_no
ON Address
AFTER insert
AS
BEGIN
if((SELECT building_no FROM inserted)<1)
BEGIN
RAISERROR('NUMER BUDYNKU NIE MOZE BYC MNIEJSZY NIZ 1',16,1);
rollback;
return
END
END

create trigger UniqueAddress on Address
after insert
as
begin
if((SELECT COUNT(*) FROM Address a WHERE where a.street = inserted.street and a.building_no = inserted.building_no and
a.city = inserted.city and a.postal_code = inserted.postal_code)>1)
begin
RAISERROR('Adres już istnieje w bazie danych',16,1);
rollback;
return
end
end

create trigger RequiredData on Orders
after insert
as
begin
if((select 1 from Pubs p, Producers r where (p.id = inserted.pub_id and (p.[e-mail] = null or p.telephone_no = null) or (r.id = inserted.producer_id and (r.[e-mail] = null or r.telephone_no = null)) == 1)
begin
RAISERROR('By zlozyc zamowienie potrzebny jest e-mail lub numer telefonu',16,1);
rollback
return
end
end

create function totalPrice (@id int)
returns money
begin
return (select SUM(od.quantity*p.price) from OrderDetails od join Products p on od.product_id = p.id where od.order_id = @id)
end



