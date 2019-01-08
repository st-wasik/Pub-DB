INSERT INTO dbo.Pubs
(
	id,
    name,
    adress_id,
    [e-mail],
    telephone_no
)
VALUES
(   1, 'Pod Strzechą', -- name - varchar(30)
    3,  -- adress_id - int
    'pod_strzecha@gmail.com', -- e-mail - varchar(50)
    '929-847-374'  -- telephone_no - varchar(12)
),
(   2, 'Smakowity Pub', -- name - varchar(30)
    2,  -- adress_id - int
    'smakowity@gmail.com', -- e-mail - varchar(50)
    '928-374-628'  -- telephone_no - varchar(12)
),
(   3, 'Pijalnia', -- name - varchar(30)
    1,  -- adress_id - int
    'pijalnia@wp.pl', -- e-mail - varchar(50)
    '828-475-738'  -- telephone_no - varchar(12)
),
(   4, 'Kolorowa', -- name - varchar(30)
    5,  -- adress_id - int
    'kolorowa@op.pl', -- e-mail - varchar(50)
    '929-384-723'  -- telephone_no - varchar(12)
),
(   5, 'Ice Pub', -- name - varchar(30)
    4,  -- adress_id - int
    'ice_pub@gmail.com', -- e-mail - varchar(50)
    '626-374-728'  -- telephone_no - varchar(12)
);
