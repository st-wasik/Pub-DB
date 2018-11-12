create view AddingToPubs
AS
SELECT p.name, a.building_no, a.street, a.city, a.postal_code FROM Pubs p join Address a on p.adress_id=a.id;

create or replace trigger trig1 on AddingToPubs
instead of insert
as
begin
insert into Address 
select building_no, street, city, postal_code
from inserted;
insert into Pubs(name,adress_id) select name, (select a.id from Address a where a.street = inserted.street) from inserted;
end
