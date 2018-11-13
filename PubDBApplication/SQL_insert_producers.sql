INSERT INTO dbo.Producers
(
    name,
    adress_id,
    [e-mail],
    telephone_no
)
VALUES
(   'Wyborowa S.A.', -- name - varchar(30)
    (SELECT id FROM dbo.Address WHERE id=6),  -- adress_id - int
    'wyborowa@gmail.com', -- e-mail - varchar(50)
    '923092943'  -- telephone_no - varchar(12)
),
(   'Sopot Beverages Sp. z o.o.', -- name - varchar(30)
    (SELECT id FROM dbo.Address WHERE id=7),  -- adress_id - int
    'sopot.beverages@wp.pl', -- e-mail - varchar(50)
    '843920574'  -- telephone_no - varchar(12)
),
(   'Alkopol Sp. z o.o.', -- name - varchar(30)
    (SELECT id FROM dbo.Address WHERE id=8),  -- adress_id - int
    'alkopol@wp.pl', -- e-mail - varchar(50)
    '939485029'  -- telephone_no - varchar(12)
),
(   'Ambrozja S.A.', -- name - varchar(30)
    (SELECT id FROM dbo.Address WHERE id=9),  -- adress_id - int
    'ambrozja@op.pl', -- e-mail - varchar(50)
    '929056923'  -- telephone_no - varchar(12)
),
(   'Drink-pol Sp. z o.o.', -- name - varchar(30)
    (SELECT id FROM dbo.Address WHERE id=10),  -- adress_id - int
    'drink-pol@gmial.com', -- e-mail - varchar(50)
    '928394201'  -- telephone_no - varchar(12)
),
(   'Le grande Sp. z o.o.', -- name - varchar(30)
    (SELECT id FROM dbo.Address WHERE id=11),  -- adress_id - int
    'le_grande@wp.pl', -- e-mail - varchar(50)
    '273847205'  -- telephone_no - varchar(12)
),
(   'Sauron S.A.', -- name - varchar(30)
    (SELECT id FROM dbo.Address WHERE id=12),  -- adress_id - int
    'sauron_sa@gmail.com', -- e-mail - varchar(50)
    '929304928'  -- telephone_no - varchar(12)
),
(   'Szampańska półka', -- name - varchar(30)
    (SELECT id FROM dbo.Address WHERE id=13),  -- adress_id - int
    'robert_smolis@wp.pl', -- e-mail - varchar(50)
    '939328843'  -- telephone_no - varchar(12)
),
(   'Wine Garage', -- name - varchar(30)
    (SELECT id FROM dbo.Address WHERE id=14),  -- adress_id - int
    'wine.garage@wp.p', -- e-mail - varchar(50)
    '342843905'  -- telephone_no - varchar(12)
),
(   'Solanum Sp. z o.o.', -- name - varchar(30)
    (SELECT id FROM dbo.Address WHERE id=15),  -- adress_id - int
    'solanum@op.pl', -- e-mail - varchar(50)
    '929384964'  -- telephone_no - varchar(12)
);