create or replace trigger trig1 on AddingToPubs
instead of insert
as
begin
insert into Address 
select building_no, street, city, postal_code
from inserted;
insert into Pubs(name,adress_id) select name, (select a.id from Address a where a.street = inserted.street) from inserted;
end

create trigger Address_build_no
ON Address
INSTEAD OF insert
AS
BEGIN
if((SELECT building_no FROM inserted)<1)
BEGIN
RAISERROR('NUMER BUDYNKU NIE MOZE BYC MNIEJSZY NIZ 1',16,1);
rollback;
return
END
insert into Address(building_no,street,city,postal_code) select building_no,street,city,postal_code from inserted;
END







