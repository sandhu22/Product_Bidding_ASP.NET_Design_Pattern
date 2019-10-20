SET IDENTITY_INSERT [dbo].[Buyer] ON
INSERT INTO [dbo].[Buyer] ([Id], [BuyerName], [BuyerAccountNumber]) VALUES (1, N'John Smith', N'06-9912-7812345-12')
INSERT INTO [dbo].[Buyer] ([Id], [BuyerName], [BuyerAccountNumber]) VALUES (2, N'Anthony Watson', N'06-9912-1234234-34')
SET IDENTITY_INSERT [dbo].[Buyer] OFF
SET IDENTITY_INSERT [dbo].[Product] ON
INSERT INTO [dbo].[Product] ([Id], [ProductName], [StartingPrice], [IsSold]) VALUES (3, N'Apple iPhone 6s', CAST(700.00 AS Decimal(18, 2)), 0)
INSERT INTO [dbo].[Product] ([Id], [ProductName], [StartingPrice], [IsSold]) VALUES (4, N'Lorex Watch ', CAST(1000.00 AS Decimal(18, 2)), 0)
INSERT INTO [dbo].[Product] ([Id], [ProductName], [StartingPrice], [IsSold]) VALUES (5, N'antique products- gramophone', CAST(1200.00 AS Decimal(18, 2)), 0)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Seller] ON
INSERT INTO [dbo].[Seller] ([Id], [SellerName], [ContactNumber]) VALUES (1, N' Antique Products Pvt LTD', N'02105678901')
INSERT INTO [dbo].[Seller] ([Id], [SellerName], [ContactNumber]) VALUES (2, N' Electronics PVT Limited', N'02134567890')
SET IDENTITY_INSERT [dbo].[Seller] OFF
SET IDENTITY_INSERT [dbo].[Bid] ON
INSERT INTO [dbo].[Bid] ([Id], [ProductId], [BuyerId], [SellerId], [BidPrice]) VALUES (1, 3, 1, 1, CAST(1000.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Bid] ([Id], [ProductId], [BuyerId], [SellerId], [BidPrice]) VALUES (2, 3, 2, 1, CAST(1500.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Bid] ([Id], [ProductId], [BuyerId], [SellerId], [BidPrice]) VALUES (3, 4, 2, 1, CAST(1200.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Bid] OFF
