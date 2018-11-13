INSERT INTO dbo.Pubs
(
    name,
    adress_id,
    [e-mail],
    telephone_no
)
VALUES
(   'Pod Strzechą', -- name - varchar(30)
    (SELECT id FROM dbo.Address WHERE id=10),  -- adress_id - int
    'pod_strzecha@gmail.com', -- e-mail - varchar(50)
    '929847374'  -- telephone_no - varchar(12)
),
(   'Smakowity Pub', -- name - varchar(30)
    (SELECT id FROM dbo.Address WHERE id=8),  -- adress_id - int
    'smakowity@gmail.com', -- e-mail - varchar(50)
    '928374628'  -- telephone_no - varchar(12)
),
(   'Pijalnia', -- name - varchar(30)
    (SELECT id FROM dbo.Address WHERE id=11),  -- adress_id - int
    'pijalnia@wp.pl', -- e-mail - varchar(50)
    '828475738'  -- telephone_no - varchar(12)
),
(   'Kolorowa', -- name - varchar(30)
    (SELECT id FROM dbo.Address WHERE id=7),  -- adress_id - int
    'kolorowa@op.pl', -- e-mail - varchar(50)
    '929384723'  -- telephone_no - varchar(12)
),
(   'Ice Pub', -- name - varchar(30)
    (SELECT id FROM dbo.Address WHERE id=18),  -- adress_id - int
    'ice_pub@gmail.com', -- e-mail - varchar(50)
    '626374728'  -- telephone_no - varchar(12)
),
(   'U Frani', -- name - varchar(30)
    (SELECT id FROM dbo.Address WHERE id=13),  -- adress_id - int
    'u.frani@gmail.com', -- e-mail - varchar(50)
    '838482774'  -- telephone_no - varchar(12)
),
(   'Pod Ladą', -- name - varchar(30)
    (SELECT id FROM dbo.Address WHERE id=14),  -- adress_id - int
    'pod_lada@gmail.com', -- e-mail - varchar(50)
    '384883727'  -- telephone_no - varchar(12)
),
(   'Shark', -- name - varchar(30)
    (SELECT id FROM dbo.Address WHERE id=15),  -- adress_id - int
    'shark@gmail.com', -- e-mail - varchar(50)
    '734757837'  -- telephone_no - varchar(12)
),
(   'Ciekawski', -- name - varchar(30)
    (SELECT id FROM dbo.Address WHERE id=16),  -- adress_id - int
    'ciekawski@wp.pl', -- e-mail - varchar(50)
    '877484593'  -- telephone_no - varchar(12)
),
(   'Fizkas', -- name - varchar(30)
    (SELECT id FROM dbo.Address WHERE id=19),  -- adress_id - int
    'fizkas@gmail.com', -- e-mail - varchar(50)
    '886857375'  -- telephone_no - varchar(12)
);