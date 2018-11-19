INSERT INTO dbo.Products
(
    name,
    producer_id,
    price,
    alcohol_percentage,
    volume
)
VALUES
(   'Wyborowa',   -- name - varchar(30)
    (SELECT id FROM dbo.Producers WHERE id=7),    -- producer_id - int
    39, -- price - money
    40,    -- alcohol_percentage - int
    0.7   -- volume - real
),
(   'Jack Daniels',   -- name - varchar(30)
    (SELECT id FROM dbo.Producers WHERE id=18),    -- producer_id - int
    159, -- price - money
    45,    -- alcohol_percentage - int
    1.0   -- volume - real
),
(   'Żubrówka',   -- name - varchar(30)
    (SELECT id FROM dbo.Producers WHERE id=19),    -- producer_id - int
    29, -- price - money
    40,    -- alcohol_percentage - int
    0.7   -- volume - real
),
(   'Soplica',   -- name - varchar(30)
    (SELECT id FROM dbo.Producers WHERE id=20),    -- producer_id - int
    39, -- price - money
    40,    -- alcohol_percentage - int
    0.7   -- volume - real
),
(   'Finlandia',   -- name - varchar(30)
    (SELECT id FROM dbo.Producers WHERE id=21),    -- producer_id - int
    49, -- price - money
    40,    -- alcohol_percentage - int
    1.0   -- volume - real
),
(   'Jim Beam',   -- name - varchar(30)
    (SELECT id FROM dbo.Producers WHERE id=22),    -- producer_id - int
    65, -- price - money
    40,    -- alcohol_percentage - int
    0.7   -- volume - real
),
(   'Ballantines',   -- name - varchar(30)
    (SELECT id FROM dbo.Producers WHERE id=23),    -- producer_id - int
    59, -- price - money
    40,    -- alcohol_percentage - int
    0.5   -- volume - real
),
(   'Don Julio Blanco',   -- name - varchar(30)
    (SELECT id FROM dbo.Producers WHERE id=24),    -- producer_id - int
    169, -- price - money
    35,    -- alcohol_percentage - int
    0.7   -- volume - real
),
(   'Lubelska',   -- name - varchar(30)
    (SELECT id FROM dbo.Producers WHERE id=25),    -- producer_id - int
    25, -- price - money
    30,    -- alcohol_percentage - int
    0.5   -- volume - real
),
(   'Stock',   -- name - varchar(30)
    (SELECT id FROM dbo.Producers WHERE id=26),    -- producer_id - int
    29, -- price - money
    37,    -- alcohol_percentage - int
    0.5   -- volume - real
);
