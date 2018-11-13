INSERT INTO dbo.Orders
(
    warehouse_id,
    pub_id,
    producer_id,
    [Incoming/Outcoming],
    status,
    date
)
VALUES
(   (SELECT id FROM dbo.Warehouses WHERE id=10),        -- warehouse_id - int
    (SELECT id FROM dbo.Pubs WHERE id=1),        -- pub_id - int
    (SELECT id FROM dbo.Producers WHERE id=7),        -- producer_id - int
    'Incoming',       -- Incoming/Outcoming - varchar(15)
    'x',       -- status - varchar(30)
    GETDATE() -- date - date
),
(   (SELECT id FROM dbo.Warehouses WHERE id=9),        -- warehouse_id - int
    (SELECT id FROM dbo.Pubs WHERE id=2),        -- pub_id - int
    (SELECT id FROM dbo.Producers WHERE id=18),        -- producer_id - int
    'Incoming',       -- Incoming/Outcoming - varchar(15)
    'x',       -- status - varchar(30)
    GETDATE() -- date - date
),
(   (SELECT id FROM dbo.Warehouses WHERE id=8),        -- warehouse_id - int
    (SELECT id FROM dbo.Pubs WHERE id=3),        -- pub_id - int
    (SELECT id FROM dbo.Producers WHERE id=19),        -- producer_id - int
    'Incoming',       -- Incoming/Outcoming - varchar(15)
    'x',       -- status - varchar(30)
    GETDATE() -- date - date
),
(   (SELECT id FROM dbo.Warehouses WHERE id=8),        -- warehouse_id - int
    (SELECT id FROM dbo.Pubs WHERE id=4),        -- pub_id - int
    (SELECT id FROM dbo.Producers WHERE id=20),        -- producer_id - int
    'Incoming',       -- Incoming/Outcoming - varchar(15)
    'x',       -- status - varchar(30)
    GETDATE() -- date - date
),
(   (SELECT id FROM dbo.Warehouses WHERE id=9),        -- warehouse_id - int
    (SELECT id FROM dbo.Pubs WHERE id=5),        -- pub_id - int
    (SELECT id FROM dbo.Producers WHERE id=21),        -- producer_id - int
    'Outcoming',       -- Incoming/Outcoming - varchar(15)
    'x',       -- status - varchar(30)
    GETDATE() -- date - date
),
(   (SELECT id FROM dbo.Warehouses WHERE id=3),        -- warehouse_id - int
    (SELECT id FROM dbo.Pubs WHERE id=6),        -- pub_id - int
    (SELECT id FROM dbo.Producers WHERE id=22),        -- producer_id - int
    'Incoming',       -- Incoming/Outcoming - varchar(15)
    'x',       -- status - varchar(30)
    GETDATE() -- date - date
),
(   (SELECT id FROM dbo.Warehouses WHERE id=3),        -- warehouse_id - int
    (SELECT id FROM dbo.Pubs WHERE id=7),        -- pub_id - int
    (SELECT id FROM dbo.Producers WHERE id=23),        -- producer_id - int
    'Outcoming',       -- Incoming/Outcoming - varchar(15)
    'x',       -- status - varchar(30)
    GETDATE() -- date - date
),
(   (SELECT id FROM dbo.Warehouses WHERE id=1),        -- warehouse_id - int
    (SELECT id FROM dbo.Pubs WHERE id=8),        -- pub_id - int
    (SELECT id FROM dbo.Producers WHERE id=24),        -- producer_id - int
    'Incoming',       -- Incoming/Outcoming - varchar(15)
    'x',       -- status - varchar(30)
    GETDATE() -- date - date
),
(   (SELECT id FROM dbo.Warehouses WHERE id=4),        -- warehouse_id - int
    (SELECT id FROM dbo.Pubs WHERE id=9),        -- pub_id - int
    (SELECT id FROM dbo.Producers WHERE id=25),        -- producer_id - int
    'Outcoming',       -- Incoming/Outcoming - varchar(15)
    'x',       -- status - varchar(30)
    GETDATE() -- date - date
),
(   (SELECT id FROM dbo.Warehouses WHERE id=1),        -- warehouse_id - int
    (SELECT id FROM dbo.Pubs WHERE id=10),        -- pub_id - int
    (SELECT id FROM dbo.Producers WHERE id=26),        -- producer_id - int
    'Outcoming',       -- Incoming/Outcoming - varchar(15)
    'x',       -- status - varchar(30)
    GETDATE() -- date - date
);