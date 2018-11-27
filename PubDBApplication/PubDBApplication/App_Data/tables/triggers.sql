create or alter trigger InsertingToPubsView on PubsView
instead of insert
as
begin
insert into Address 
select building_no, street, city, postal_code
from inserted;
insert into Pubs(name,adress_id,e-mail,telephone_no) select name, (select a.id from Address a where a.street = inserted.street and a.building_no = inserted.building_no and
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
if((SELECT COUNT(*) FROM Address a, inserted WHERE a.street = inserted.street and a.building_no = inserted.building_no and
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
if((
select 1 from Pubs p, inserted where p.id = inserted.pub_id and p.[e-mail] is null and p.telephone_no is null
union
select 1 from Producers r, inserted where r.id = inserted.producer_id and r.[e-mail] is null and r.telephone_no is null
)>0)
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

create trigger MinPrice on Orders
after update
as
begin
if(totalPrice(select id from updated)<1000)
begin
RAISERROR('Zamowienie nie moze byc mniejsze niz 1000 zl',16,1);
rollback;
return
end
end

create trigger OrderInsert on OrdersView
instead of insert
as
begin
insert into Orders 
select (select w.id from Warehouses w join inserted i on i.name = w.name),
(select p.id from Pubs p join inserted i on i.name = p.name),
(select r.id from Producers r join inserted i on i.name = r.name),
[Incoming/Outcoming],
status,
date
from inserted;
end