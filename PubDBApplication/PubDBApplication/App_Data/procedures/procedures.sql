create procedure createRaport @Id int
AS
if(@Id<1)
begin
RAISERROR('NIE MOZNA PODAC ID MNIEJSZEGO NIZ 1',16,1)
return
end
SELECT * FROM OrderDetails od JOIN Orders o on od.order_id = o.id WHERE o.pub_id=@Id;