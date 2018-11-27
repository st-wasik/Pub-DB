create trigger InsertingToPubsView on PubsView
instead of insert
as
begin
insert into Address 
select building_no, street, city, postal_code
from inserted;
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
PRINT N'Address already exists in DataBase';
rollback;
return
end
end







