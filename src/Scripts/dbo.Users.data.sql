SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([Id], [Username], [Password], [RoleId]) VALUES (-1, N'Patrick', N'123456', -1)
INSERT INTO [dbo].[Users] ([Id], [Username], [Password], [RoleId]) VALUES (1, N'Amadou ', N'56789', -2)
SET IDENTITY_INSERT [dbo].[Users] OFF
