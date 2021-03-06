USE [SportCenter]
GO
SET IDENTITY_INSERT [dbo].[Sports] ON 

INSERT [dbo].[Sports] ([Id], [Name]) VALUES (1, N'Voley')
INSERT [dbo].[Sports] ([Id], [Name]) VALUES (2, N'Futbol')
SET IDENTITY_INSERT [dbo].[Sports] OFF
SET IDENTITY_INSERT [dbo].[Courts] ON 

INSERT [dbo].[Courts] ([Id], [Name], [SportForeignKey]) VALUES (1, N'Padel Court 1', 1)
INSERT [dbo].[Courts] ([Id], [Name], [SportForeignKey]) VALUES (2, N'Padel Court 2', 1)
INSERT [dbo].[Courts] ([Id], [Name], [SportForeignKey]) VALUES (3, N'Futbol Court 1', 2)
INSERT [dbo].[Courts] ([Id], [Name], [SportForeignKey]) VALUES (4, N'Futbol Court 2', 2)
SET IDENTITY_INSERT [dbo].[Courts] OFF
SET IDENTITY_INSERT [dbo].[Members] ON 

INSERT [dbo].[Members] ([Id], [Name], [Phone]) VALUES (2, N'Member1', N'676789098')
INSERT [dbo].[Members] ([Id], [Name], [Phone]) VALUES (3, N'Member2', N'676789098')
SET IDENTITY_INSERT [dbo].[Members] OFF
SET IDENTITY_INSERT [dbo].[Bookings] ON 

INSERT [dbo].[Bookings] ([Id], [MemberForeignKey], [CourtForeignKey], [CreatedDate], [BookingDate]) VALUES (1, 2, 2, CAST(N'2019-01-21T15:29:18.9532469' AS DateTime2), CAST(N'2019-01-17T14:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bookings] ([Id], [MemberForeignKey], [CourtForeignKey], [CreatedDate], [BookingDate]) VALUES (2, 3, 3, CAST(N'2019-01-21T15:29:18.9556981' AS DateTime2), CAST(N'2019-01-17T21:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Bookings] OFF
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190114194220_InitialMigration', N'2.2.1-servicing-10028')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190116204147_FullModelCreated', N'2.2.1-servicing-10028')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190117090752_ModelImprovements', N'2.2.1-servicing-10028')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190117102225_SeedingData', N'2.2.1-servicing-10028')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190121142919_UserMemberNonRelation', N'2.2.1-servicing-10028')
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Password], [Name], [CreatedDate]) VALUES (1, N'12341234', N'Admin', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Users] ([Id], [Password], [Name], [CreatedDate]) VALUES (2, N'12341234', N'User1', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Users] OFF
