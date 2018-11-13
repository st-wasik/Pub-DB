INSERT INTO dbo.WarehousesStock
(
    warehouse_id,
    product_id,
    quantity
)
VALUES
(   (SELECT id FROM dbo.Warehouses WHERE id=1), -- warehouse_id - int
    (SELECT id FROM dbo.Products WHERE id=2), -- product_id - int
    500  -- quantity - int
),
(   (SELECT id FROM dbo.Warehouses WHERE id=2), -- warehouse_id - int
    (SELECT id FROM dbo.Products WHERE id=3), -- product_id - int
    156  -- quantity - int
),
(   (SELECT id FROM dbo.Warehouses WHERE id=3), -- warehouse_id - int
    (SELECT id FROM dbo.Products WHERE id=4), -- product_id - int
    90  -- quantity - int
),
(   (SELECT id FROM dbo.Warehouses WHERE id=4), -- warehouse_id - int
    (SELECT id FROM dbo.Products WHERE id=5), -- product_id - int
    87  -- quantity - int
),
(   (SELECT id FROM dbo.Warehouses WHERE id=5), -- warehouse_id - int
    (SELECT id FROM dbo.Products WHERE id=6), -- product_id - int
    10  -- quantity - int
),
(   (SELECT id FROM dbo.Warehouses WHERE id=6), -- warehouse_id - int
    (SELECT id FROM dbo.Products WHERE id=7), -- product_id - int
    201  -- quantity - int
),
(   (SELECT id FROM dbo.Warehouses WHERE id=7), -- warehouse_id - int
    (SELECT id FROM dbo.Products WHERE id=8), -- product_id - int
    68  -- quantity - int
),
(   (SELECT id FROM dbo.Warehouses WHERE id=8), -- warehouse_id - int
    (SELECT id FROM dbo.Products WHERE id=9), -- product_id - int
    56  -- quantity - int
),
(   (SELECT id FROM dbo.Warehouses WHERE id=9), -- warehouse_id - int
    (SELECT id FROM dbo.Products WHERE id=10), -- product_id - int
    100  -- quantity - int
),
(   (SELECT id FROM dbo.Warehouses WHERE id=10), -- warehouse_id - int
    (SELECT id FROM dbo.Products WHERE id=11), -- product_id - int
    50  -- quantity - int
);