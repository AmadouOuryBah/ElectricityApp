SET IDENTITY_INSERT [dbo].[Schedules] ON
INSERT INTO [dbo].[Schedules] ([Id], [Name], [Sun], [Mon], [Tue], [Wed], [Thu], [Fri], [Sat], [TotalHours]) VALUES (2, N'Режим1', 0, 0, 1, 1, 1, 1, 0, 9)
INSERT INTO [dbo].[Schedules] ([Id], [Name], [Sun], [Mon], [Tue], [Wed], [Thu], [Fri], [Sat], [TotalHours]) VALUES (3, N'Режим2', 0, 1, 1, 1, 1, 1, 1, 10)
INSERT INTO [dbo].[Schedules] ([Id], [Name], [Sun], [Mon], [Tue], [Wed], [Thu], [Fri], [Sat], [TotalHours]) VALUES (4, N'Режим3', 1, 1, 1, 1, 1, 1, 1, 8)
INSERT INTO [dbo].[Schedules] ([Id], [Name], [Sun], [Mon], [Tue], [Wed], [Thu], [Fri], [Sat], [TotalHours]) VALUES (6, N'Режим4', 1, 1, 1, 1, 1, 1, 1, 12)
SET IDENTITY_INSERT [dbo].[Schedules] OFF
