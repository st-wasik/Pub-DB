create view AddingToPubs
AS
SELECT p.name, a.building_no, a.street, a.city, a.postal_code FROM Pubs p join Address a on p.adress_id=a.id;