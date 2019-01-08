INSERT INTO dbo.Products
(
	id,
    name,
    producer_id,
    price,
    alcohol_percentage,
    volume
)
VALUES
(   1, 'Wyborowa',   -- name - varchar(30)
    1,    -- producer_id - int
    39, -- price - money
    40,    -- alcohol_percentage - int
    0.7   -- volume - real
),
(   2, 'Jack Daniels',   -- name - varchar(30)
    1,    -- producer_id - int
    159, -- price - money
    45,    -- alcohol_percentage - int
    1.0   -- volume - real
),
(   3, 'Żubrówka',   -- name - varchar(30)
    2,    -- producer_id - int
    29, -- price - money
    40,    -- alcohol_percentage - int
    0.7   -- volume - real
),
(   4, 'Soplica',   -- name - varchar(30)
    2,    -- producer_id - int
    39, -- price - money
    40,    -- alcohol_percentage - int
    0.7   -- volume - real
),
(   5, 'Finlandia',   -- name - varchar(30)
    3,    -- producer_id - int
    49, -- price - money
    40,    -- alcohol_percentage - int
    1.0   -- volume - real
),
(   6, 'Jim Beam',   -- name - varchar(30)
    3,    -- producer_id - int
    65, -- price - money
    40,    -- alcohol_percentage - int
    0.7   -- volume - real
),
(   7, 'Ballantines',   -- name - varchar(30)
    4,    -- producer_id - int
    59, -- price - money
    40,    -- alcohol_percentage - int
    0.5   -- volume - real
),
(   8, 'Don Julio Blanco',   -- name - varchar(30)
    4,    -- producer_id - int
    169, -- price - money
    35,    -- alcohol_percentage - int
    0.7   -- volume - real
),
(   9,'Lubelska',   -- name - varchar(30)
    5,    -- producer_id - int
    25, -- price - money
    30,    -- alcohol_percentage - int
    0.5   -- volume - real
),
(   10,'Stock',   -- name - varchar(30)
    5,    -- producer_id - int
    29, -- price - money
    37,    -- alcohol_percentage - int
    0.5   -- volume - real
);
