SET IDENTITY_INSERT [dbo].[Pubs] ON
INSERT INTO [dbo].[Pubs] ([id], [name], [adress_id], [e-mail], [telephone_no], [RowVersion]) VALUES (1, N'Pod Strzecha', 3, N'pod_strzecha@gmail.com', N'929-847-374', 1)
INSERT INTO [dbo].[Pubs] ([id], [name], [adress_id], [e-mail], [telephone_no], [RowVersion]) VALUES (2, N'Smakowity Pub', 2, N'smakowity@gmail.com', N'928-374-628', 1)
INSERT INTO [dbo].[Pubs] ([id], [name], [adress_id], [e-mail], [telephone_no], [RowVersion]) VALUES (3, N'Pijalnia', 1, N'pijalnia@wp.pl', N'828-475-738', 1)
INSERT INTO [dbo].[Pubs] ([id], [name], [adress_id], [e-mail], [telephone_no], [RowVersion]) VALUES (4, N'Kolorowa', 5, N'kolorowa@op.pl', N'929-384-723', 1)
INSERT INTO [dbo].[Pubs] ([id], [name], [adress_id], [e-mail], [telephone_no], [RowVersion]) VALUES (5, N'Ice Pub', 4, N'ice_pub@gmail.com', N'626-374-728', 1)
SET IDENTITY_INSERT [dbo].[Pubs] OFF
