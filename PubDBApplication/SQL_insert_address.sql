INSERT INTO dbo.Address
(
    building_no,
    street,
    city,
    postal_code
)
VALUES
(   -- 1
	1,  -- building_no - int
    'Topolowa', -- street - varchar(30)
    'Buk', -- city - varchar(30)
    '64-320'  -- postal_code - varchar(6)
),
(	--2
	2,  -- building_no - int
    'Kwiatowa', -- street - varchar(30)
    'Dopiewo', -- city - varchar(30)
    '64-385'  -- postal_code - varchar(6)
),
(	--3
	14,  -- building_no - int
    'Orzechowa', -- street - varchar(30)
    'Poznań', -- city - varchar(30)
    '64-385'  -- postal_code - varchar(6)
),
(	--4
	134,  -- building_no - int
    'Powstańców Wielkopolskich', -- street - varchar(30)
    'Poznań', -- city - varchar(30)
    '62-380'  -- postal_code - varchar(6)
),
(	--5
	9,  -- building_no - int
    'Alberta Einsteina', -- street - varchar(30)
    'Wrocław', -- city - varchar(30)
    '37-515'  -- postal_code - varchar(6)
),
(	--6 
	56,  -- building_no - int
    'Nad Miedzą Poznań', -- street - varchar(30)
    'Warszawa', -- city - varchar(30)
    '85-420'  -- postal_code - varchar(6)
),
(	--7
	25,  -- building_no - int
    'Sopocka', -- street - varchar(30)
    'Gdańsk', -- city - varchar(30)
    '72-600'  -- postal_code - varchar(6)
),
(	--8
	48,  -- building_no - int
    'Rolna', -- street - varchar(30)
    'Poznań', -- city - varchar(30)
    '64-385'  -- postal_code - varchar(6)
),
(	--9
	13,  -- building_no - int
    'Gronowa', -- street - varchar(30)
    'Zielona Góra', -- city - varchar(30)
    '22-750'  -- postal_code - varchar(6)
),
(	--10
	97,  -- building_no - int
    'Sikorskiego', -- street - varchar(30)
    'Wrocław', -- city - varchar(30)
    '38-515'  -- postal_code - varchar(6)
);