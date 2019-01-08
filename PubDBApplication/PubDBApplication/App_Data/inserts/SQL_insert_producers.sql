INSERT INTO dbo.Producers
(
	id,
    name,
    adress_id,
    [e-mail],
    telephone_no
)
VALUES
(   1, 'Wyborowa S.A.', -- name - varchar(30)
    10,  -- adress_id - int
    'wyborowa@gmail.com', -- e-mail - varchar(50)
    '923-092-943'  -- telephone_no - varchar(12)
),
(   2, 'Alkopol Sp. z o.o.', -- name - varchar(30)
    8,  -- adress_id - int
    'alkopol@wp.pl', -- e-mail - varchar(50)
    '939-485-029'  -- telephone_no - varchar(12)
),
(   3, 'Drink-pol Sp. z o.o.', -- name - varchar(30)
    6,  -- adress_id - int
    'drink-pol@gmial.com', -- e-mail - varchar(50)
    '928-394-201'  -- telephone_no - varchar(12)
),
(   4, 'Le grande Sp. z o.o.', -- name - varchar(30)
    9,  -- adress_id - int
    'le_grande@wp.pl', -- e-mail - varchar(50)
    '273-847-205'  -- telephone_no - varchar(12)
),
(   5,'Solanum Sp. z o.o.', -- name - varchar(30)
    7,  -- adress_id - int
    'solanum@op.pl', -- e-mail - varchar(50)
    '929-384-964'  -- telephone_no - varchar(12)
);