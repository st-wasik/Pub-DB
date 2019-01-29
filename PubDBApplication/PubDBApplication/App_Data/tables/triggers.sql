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












