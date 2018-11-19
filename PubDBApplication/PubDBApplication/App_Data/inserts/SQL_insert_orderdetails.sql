INSERT INTO dbo.OrderDetails
(
    order_id,
    quantity,
    product_id
)
VALUES
(   (SELECT id FROM dbo.Orders WHERE id=1), -- order_id - int
    3, -- quantity - int
    (SELECT id FROM dbo.Products WHERE id=2)  -- product_id - int
),
(   (SELECT id FROM dbo.Orders WHERE id=2), -- order_id - int
    1, -- quantity - int
    (SELECT id FROM dbo.Products WHERE id=3)  -- product_id - int
),
(   (SELECT id FROM dbo.Orders WHERE id=3), -- order_id - int
    8, -- quantity - int
    (SELECT id FROM dbo.Products WHERE id=4)  -- product_id - int
),
(   (SELECT id FROM dbo.Orders WHERE id=4), -- order_id - int
    5, -- quantity - int
    (SELECT id FROM dbo.Products WHERE id=5)  -- product_id - int
),
(   (SELECT id FROM dbo.Orders WHERE id=5), -- order_id - int
    3, -- quantity - int
    (SELECT id FROM dbo.Products WHERE id=6)  -- product_id - int
),
(   (SELECT id FROM dbo.Orders WHERE id=6), -- order_id - int
    8, -- quantity - int
    (SELECT id FROM dbo.Products WHERE id=7)  -- product_id - int
),
(   (SELECT id FROM dbo.Orders WHERE id=7), -- order_id - int
    4, -- quantity - int
    (SELECT id FROM dbo.Products WHERE id=8)  -- product_id - int
),
(   (SELECT id FROM dbo.Orders WHERE id=8), -- order_id - int
    1, -- quantity - int
    (SELECT id FROM dbo.Products WHERE id=9)  -- product_id - int
),
(   (SELECT id FROM dbo.Orders WHERE id=9), -- order_id - int
    5, -- quantity - int
    (SELECT id FROM dbo.Products WHERE id=10)  -- product_id - int
),
(   (SELECT id FROM dbo.Orders WHERE id=10), -- order_id - int
    4, -- quantity - int
    (SELECT id FROM dbo.Products WHERE id=11)  -- product_id - int
);