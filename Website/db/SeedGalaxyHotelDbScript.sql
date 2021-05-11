DELETE FROM [dbo].[Reservations]
GO
DELETE FROM [dbo].[Guests]
GO
DELETE FROM [dbo].[Rooms]
GO
DELETE FROM [dbo].[PaymentMethods]
GO
DELETE FROM [dbo].[Addresses]
GO

SET IDENTITY_INSERT [dbo].[Addresses] ON 
GO
INSERT [dbo].[Addresses] ([Id], [Street], [City], [State], [Country], [ZipCode]) VALUES (1, N'13th Space Road, Brooklyn', N'New York', N'New York', N'United States of America', N'13021')
GO
INSERT [dbo].[Addresses] ([Id], [Street], [City], [State], [Country], [ZipCode]) VALUES (2, N'12th Hollywood road, Hollywood', N'Los Angeles', N'New York', N'United States of America', N'33024')
GO
INSERT [dbo].[Addresses] ([Id], [Street], [City], [State], [Country], [ZipCode]) VALUES (3, N'Piazza Plebiscito 1, Naples', N'Naples', N'', N'Italy', N'80100')
GO
INSERT [dbo].[Addresses] ([Id], [Street], [City], [State], [Country], [ZipCode]) VALUES (4, N'14th Valley Road', N'London', N'New York', N'United States of America', N'WC2N 5DU')
GO
SET IDENTITY_INSERT [dbo].[Addresses] OFF
GO
SET IDENTITY_INSERT [dbo].[PaymentMethods] ON 
GO
INSERT [dbo].[PaymentMethods] ([Id], [Alias], [CardNumber], [DueDate]) VALUES (1, N'Private Credit Card 1', N'123412349876598765', CAST(N'2021-08-28T10:25:09.4799091+02:00' AS DateTimeOffset))
GO
INSERT [dbo].[PaymentMethods] ([Id], [Alias], [CardNumber], [DueDate]) VALUES (2, N'Private Credit Card 2', N'123412349876598766', CAST(N'2021-08-28T10:25:09.4871490+02:00' AS DateTimeOffset))
GO
INSERT [dbo].[PaymentMethods] ([Id], [Alias], [CardNumber], [DueDate]) VALUES (3, N'Private Credit Card 3', N'123412349876598767', CAST(N'2021-08-28T10:25:09.4871614+02:00' AS DateTimeOffset))
GO
INSERT [dbo].[PaymentMethods] ([Id], [Alias], [CardNumber], [DueDate]) VALUES (4, N'Private Credit Card 4', N'123412349876598768', CAST(N'2021-08-28T10:25:09.4871635+02:00' AS DateTimeOffset))
GO
SET IDENTITY_INSERT [dbo].[PaymentMethods] OFF
GO
SET IDENTITY_INSERT [dbo].[Guests] ON 
GO
INSERT [dbo].[Guests] ([Id], [FirstName], [LastName], [AddressId], [PaymentMethodId]) VALUES (1, N'John', N'Doe', 1, 1)
GO
INSERT [dbo].[Guests] ([Id], [FirstName], [LastName], [AddressId], [PaymentMethodId]) VALUES (2, N'Alex', N'Harvey', 2, 2)
GO
INSERT [dbo].[Guests] ([Id], [FirstName], [LastName], [AddressId], [PaymentMethodId]) VALUES (3, N'Antonio', N'Esposito', 3, 3)
GO
INSERT [dbo].[Guests] ([Id], [FirstName], [LastName], [AddressId], [PaymentMethodId]) VALUES (4, N'Mark', N'River', 4, 4)
GO
SET IDENTITY_INSERT [dbo].[Guests] OFF
GO
SET IDENTITY_INSERT [dbo].[Rooms] ON 
GO
INSERT [dbo].[Rooms] ([Id], [Name], [Floor], [PricePerNight]) VALUES (1, N'Andromeda', 1, CAST(200.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Rooms] ([Id], [Name], [Floor], [PricePerNight]) VALUES (2, N'Whirpool', 1, CAST(150.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Rooms] ([Id], [Name], [Floor], [PricePerNight]) VALUES (3, N'Sombrero', 1, CAST(100.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Rooms] OFF
GO
SET IDENTITY_INSERT [dbo].[Reservations] ON 
GO
INSERT [dbo].[Reservations] ([Id], [CheckIn], [CheckOut], [TotalPrice], [GuestId], [RoomId]) VALUES (1, CAST(N'2020-08-28T10:25:09.4921003+02:00' AS DateTimeOffset), CAST(N'2020-08-29T10:25:09.4921050+02:00' AS DateTimeOffset), CAST(200.00 AS Decimal(18, 2)), 1, 1)
GO
INSERT [dbo].[Reservations] ([Id], [CheckIn], [CheckOut], [TotalPrice], [GuestId], [RoomId]) VALUES (2, CAST(N'2020-08-28T10:25:09.4921003+02:00' AS DateTimeOffset), CAST(N'2020-08-29T10:25:09.4921050+02:00' AS DateTimeOffset), CAST(150.00 AS Decimal(18, 2)), 2, 2)
GO
INSERT [dbo].[Reservations] ([Id], [CheckIn], [CheckOut], [TotalPrice], [GuestId], [RoomId]) VALUES (3, CAST(N'2020-08-28T10:25:09.4921003+02:00' AS DateTimeOffset), CAST(N'2020-08-29T10:25:09.4921050+02:00' AS DateTimeOffset), CAST(100.00 AS Decimal(18, 2)), 3, 3)
GO
SET IDENTITY_INSERT [dbo].[Reservations] OFF
GO
