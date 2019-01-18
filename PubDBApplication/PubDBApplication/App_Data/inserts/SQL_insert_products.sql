SET IDENTITY_INSERT [dbo].[Products] ON
INSERT INTO [dbo].[Products] ([id], [name], [producer_id], [price], [alcohol_percentage], [volume], [RowVersion]) VALUES (1, N'Wyborowa', 1, CAST(39.0000 AS Money), 40, 0.7, 1)
INSERT INTO [dbo].[Products] ([id], [name], [producer_id], [price], [alcohol_percentage], [volume], [RowVersion]) VALUES (2, N'Jack Daniels', 1, CAST(159.0000 AS Money), 45, 1, 1)
INSERT INTO [dbo].[Products] ([id], [name], [producer_id], [price], [alcohol_percentage], [volume], [RowVersion]) VALUES (3, N'Zubrówka', 2, CAST(29.0000 AS Money), 40, 0.7, 1)
INSERT INTO [dbo].[Products] ([id], [name], [producer_id], [price], [alcohol_percentage], [volume], [RowVersion]) VALUES (4, N'Soplica', 2, CAST(39.0000 AS Money), 40, 0.7, 1)
INSERT INTO [dbo].[Products] ([id], [name], [producer_id], [price], [alcohol_percentage], [volume], [RowVersion]) VALUES (5, N'Finlandia', 3, CAST(49.0000 AS Money), 40, 1, 1)
INSERT INTO [dbo].[Products] ([id], [name], [producer_id], [price], [alcohol_percentage], [volume], [RowVersion]) VALUES (6, N'Jim Beam', 3, CAST(65.0000 AS Money), 40, 0.7, 1)
INSERT INTO [dbo].[Products] ([id], [name], [producer_id], [price], [alcohol_percentage], [volume], [RowVersion]) VALUES (7, N'Ballantines', 4, CAST(59.0000 AS Money), 40, 0.5, 1)
INSERT INTO [dbo].[Products] ([id], [name], [producer_id], [price], [alcohol_percentage], [volume], [RowVersion]) VALUES (8, N'Don Julio Blanco', 4, CAST(169.0000 AS Money), 35, 0.7, 1)
INSERT INTO [dbo].[Products] ([id], [name], [producer_id], [price], [alcohol_percentage], [volume], [RowVersion]) VALUES (9, N'Lubelska', 5, CAST(25.0000 AS Money), 30, 0.5, 1)
INSERT INTO [dbo].[Products] ([id], [name], [producer_id], [price], [alcohol_percentage], [volume], [RowVersion]) VALUES (10, N'Stock', 5, CAST(29.0000 AS Money), 37, 0.5, 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
