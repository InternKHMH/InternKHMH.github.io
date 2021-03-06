USE [InternShip]
GO
/****** Object:  Table [dbo].[FeatureGroup]    Script Date: 06/21/2018 22:00:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeatureGroup](
	[featureGroupID] [int] IDENTITY(1,1) NOT NULL,
	[featureGroupName] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[featureGroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusCheck]    Script Date: 06/21/2018 22:00:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusCheck](
	[StatusID] [int] NOT NULL,
	[StatusName] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[StatusCheck] ([StatusID], [StatusName]) VALUES (1, N'Completed')
INSERT [dbo].[StatusCheck] ([StatusID], [StatusName]) VALUES (2, N'Processing')
INSERT [dbo].[StatusCheck] ([StatusID], [StatusName]) VALUES (3, N'Active')
INSERT [dbo].[StatusCheck] ([StatusID], [StatusName]) VALUES (4, N'InActive')
/****** Object:  Table [dbo].[Roles]    Script Date: 06/21/2018 22:00:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Roles] ON
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (2, N'Manager')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (3, N'ScrumMaster')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (4, N'Intern')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (5, N'User')
SET IDENTITY_INSERT [dbo].[Roles] OFF
/****** Object:  Table [dbo].[Projects]    Script Date: 06/21/2018 22:00:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](100) NULL,
	[ManagerName] [nvarchar](50) NULL,
	[Leadername] [nvarchar](50) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[StatusID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Projects] ON
INSERT [dbo].[Projects] ([ProjectID], [ProjectName], [ManagerName], [Leadername], [StartDate], [EndDate], [StatusID]) VALUES (1, N'Intern_KHMH', N'Phuong vo', N'abc', CAST(0x0000A8DB00000000 AS DateTime), CAST(0x0000A91400000000 AS DateTime), 1)
INSERT [dbo].[Projects] ([ProjectID], [ProjectName], [ManagerName], [Leadername], [StartDate], [EndDate], [StatusID]) VALUES (2, N'Intern_Hhdl', N'Phuong vo', N'abc', CAST(0x0000A89A00000000 AS DateTime), CAST(0x0000A8E400000000 AS DateTime), 2)
INSERT [dbo].[Projects] ([ProjectID], [ProjectName], [ManagerName], [Leadername], [StartDate], [EndDate], [StatusID]) VALUES (3, N'Intern-ldd', N'Long Hoang', N'abc', CAST(0x0000A87D00000000 AS DateTime), CAST(0x0000A8E300000000 AS DateTime), 1)
INSERT [dbo].[Projects] ([ProjectID], [ProjectName], [ManagerName], [Leadername], [StartDate], [EndDate], [StatusID]) VALUES (4, N'Intern Manager 2018', NULL, NULL, CAST(0x0000A8D600000000 AS DateTime), CAST(0x0000A91600000000 AS DateTime), 4)
INSERT [dbo].[Projects] ([ProjectID], [ProjectName], [ManagerName], [Leadername], [StartDate], [EndDate], [StatusID]) VALUES (5, N'Student manager', NULL, NULL, CAST(0x0000A8D400000000 AS DateTime), CAST(0x0000A8F800000000 AS DateTime), 4)
INSERT [dbo].[Projects] ([ProjectID], [ProjectName], [ManagerName], [Leadername], [StartDate], [EndDate], [StatusID]) VALUES (9, N'student manager 2018', NULL, NULL, CAST(0x0000A8DB00000000 AS DateTime), CAST(0x0000A91400000000 AS DateTime), 4)
SET IDENTITY_INSERT [dbo].[Projects] OFF
/****** Object:  Table [dbo].[Users]    Script Date: 06/21/2018 22:00:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Passwords] [varchar](50) NULL,
	[FullName] [nvarchar](50) NULL,
	[Stat] [bit] NULL,
	[RoleID] [int] NULL,
	[userdes] [nvarchar](200) NULL,
	[University] [nvarchar](50) NULL,
	[imagecover] [varchar](200) NULL,
	[imagelogin] [varchar](200) NULL,
	[userAddress] [nvarchar](100) NULL,
	[specialized] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([UserID], [UserName], [Passwords], [FullName], [Stat], [RoleID], [userdes], [University], [imagecover], [imagelogin], [userAddress], [specialized]) VALUES (1, N'phamvankhanh', N'123', N'Phạm Văn Khánh', 1, 4, N'Là sinh viên ĐH Trần Đại Nghĩa Nguyễn Oanh Gò Vấp niên khóa 2014-2018', N'Trần Đại Nghĩa', N'1.jpg', N'1.jpg', NULL, NULL)
INSERT [dbo].[Users] ([UserID], [UserName], [Passwords], [FullName], [Stat], [RoleID], [userdes], [University], [imagecover], [imagelogin], [userAddress], [specialized]) VALUES (2, N'ducminh', N'123', N'Phạm Đức Minh', 1, 4, N'Sinh viên chuyên ngành phần mềm tại Đại hoc FPT', N'FPT University', N'2.jpg', N'2.jpg', NULL, NULL)
INSERT [dbo].[Users] ([UserID], [UserName], [Passwords], [FullName], [Stat], [RoleID], [userdes], [University], [imagecover], [imagelogin], [userAddress], [specialized]) VALUES (3, N'huynguyen', N'123', N'nguyen huy', 1, 4, N'Sinh viên chuyên ngành điện điện tủ trường ĐH Sư Phạm Kỹ Thuật TP.HCM', N'SPKT TP.HCM', N'4.jpg', N'4.jpg', NULL, NULL)
INSERT [dbo].[Users] ([UserID], [UserName], [Passwords], [FullName], [Stat], [RoleID], [userdes], [University], [imagecover], [imagelogin], [userAddress], [specialized]) VALUES (4, N'hochuy', N'123', N'hoc huy', 1, 4, N'Sinh viên đại học FPT niên khóa 2015-2019', N'FPT University', N'5.jpg', N'5.jpg', NULL, NULL)
INSERT [dbo].[Users] ([UserID], [UserName], [Passwords], [FullName], [Stat], [RoleID], [userdes], [University], [imagecover], [imagelogin], [userAddress], [specialized]) VALUES (5, N'phuongvo', N'123', N'Phương võ', 1, 2, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserID], [UserName], [Passwords], [FullName], [Stat], [RoleID], [userdes], [University], [imagecover], [imagelogin], [userAddress], [specialized]) VALUES (6, N'manager2', N'123', N'Manager 2', 1, 2, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  Table [dbo].[Features]    Script Date: 06/21/2018 22:00:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Features](
	[FeatureID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NULL,
	[FeatureName] [nvarchar](50) NULL,
	[UserID] [int] NULL,
	[StatusID] [int] NULL,
	[startDate] [date] NULL,
	[endDate] [date] NULL,
	[Descrip] [text] NULL,
	[featureGroupID] [int] NULL,
	[comment] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[FeatureID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Features] ON
INSERT [dbo].[Features] ([FeatureID], [ProjectID], [FeatureName], [UserID], [StatusID], [startDate], [endDate], [Descrip], [featureGroupID], [comment]) VALUES (1, 1, N'Login via account', 4, 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Features] ([FeatureID], [ProjectID], [FeatureName], [UserID], [StatusID], [startDate], [endDate], [Descrip], [featureGroupID], [comment]) VALUES (2, 1, N'Login via G+', 4, 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Features] ([FeatureID], [ProjectID], [FeatureName], [UserID], [StatusID], [startDate], [endDate], [Descrip], [featureGroupID], [comment]) VALUES (3, 1, N'Login via facebook', 4, 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Features] ([FeatureID], [ProjectID], [FeatureName], [UserID], [StatusID], [startDate], [endDate], [Descrip], [featureGroupID], [comment]) VALUES (4, 1, N'Manage Project', 1, 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Features] ([FeatureID], [ProjectID], [FeatureName], [UserID], [StatusID], [startDate], [endDate], [Descrip], [featureGroupID], [comment]) VALUES (5, 1, N'View Project', 1, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Features] ([FeatureID], [ProjectID], [FeatureName], [UserID], [StatusID], [startDate], [endDate], [Descrip], [featureGroupID], [comment]) VALUES (6, 1, N'View Project Summary', 1, 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Features] ([FeatureID], [ProjectID], [FeatureName], [UserID], [StatusID], [startDate], [endDate], [Descrip], [featureGroupID], [comment]) VALUES (7, 1, N'View Detail Project', 1, 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Features] ([FeatureID], [ProjectID], [FeatureName], [UserID], [StatusID], [startDate], [endDate], [Descrip], [featureGroupID], [comment]) VALUES (8, 1, N'Create Project', 1, 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Features] ([FeatureID], [ProjectID], [FeatureName], [UserID], [StatusID], [startDate], [endDate], [Descrip], [featureGroupID], [comment]) VALUES (9, 1, N'Remove Project', 1, 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Features] ([FeatureID], [ProjectID], [FeatureName], [UserID], [StatusID], [startDate], [endDate], [Descrip], [featureGroupID], [comment]) VALUES (10, 1, N'Update Project', 1, 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Features] ([FeatureID], [ProjectID], [FeatureName], [UserID], [StatusID], [startDate], [endDate], [Descrip], [featureGroupID], [comment]) VALUES (11, 1, N'Assign Scrum Master', 1, 2, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Features] OFF
/****** Object:  Table [dbo].[ProjectMember]    Script Date: 06/21/2018 22:00:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectMember](
	[ProjectID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [Pk_ProjectMember] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC,
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ProjectMember] ([ProjectID], [UserID], [RoleID]) VALUES (1, 1, 4)
INSERT [dbo].[ProjectMember] ([ProjectID], [UserID], [RoleID]) VALUES (1, 2, 3)
INSERT [dbo].[ProjectMember] ([ProjectID], [UserID], [RoleID]) VALUES (1, 3, 4)
INSERT [dbo].[ProjectMember] ([ProjectID], [UserID], [RoleID]) VALUES (1, 4, 4)
INSERT [dbo].[ProjectMember] ([ProjectID], [UserID], [RoleID]) VALUES (1, 5, 2)
INSERT [dbo].[ProjectMember] ([ProjectID], [UserID], [RoleID]) VALUES (2, 1, 4)
INSERT [dbo].[ProjectMember] ([ProjectID], [UserID], [RoleID]) VALUES (2, 2, 4)
INSERT [dbo].[ProjectMember] ([ProjectID], [UserID], [RoleID]) VALUES (2, 6, 2)
INSERT [dbo].[ProjectMember] ([ProjectID], [UserID], [RoleID]) VALUES (9, 5, 2)
/****** Object:  Table [dbo].[ImagesFeature]    Script Date: 06/21/2018 22:00:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImagesFeature](
	[ImagesFeatureID] [int] IDENTITY(1,1) NOT NULL,
	[featureID] [int] NULL,
	[title] [nvarchar](100) NULL,
	[addDate] [date] NULL,
	[isCover] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ImagesFeatureID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF__Users__RoleID__29572725]    Script Date: 06/21/2018 22:00:29 ******/
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((5)) FOR [RoleID]
GO
/****** Object:  ForeignKey [FK_Features_FeatureGroup]    Script Date: 06/21/2018 22:00:29 ******/
ALTER TABLE [dbo].[Features]  WITH CHECK ADD  CONSTRAINT [FK_Features_FeatureGroup] FOREIGN KEY([featureGroupID])
REFERENCES [dbo].[FeatureGroup] ([featureGroupID])
GO
ALTER TABLE [dbo].[Features] CHECK CONSTRAINT [FK_Features_FeatureGroup]
GO
/****** Object:  ForeignKey [FK_Features_Projects]    Script Date: 06/21/2018 22:00:29 ******/
ALTER TABLE [dbo].[Features]  WITH CHECK ADD  CONSTRAINT [FK_Features_Projects] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Projects] ([ProjectID])
GO
ALTER TABLE [dbo].[Features] CHECK CONSTRAINT [FK_Features_Projects]
GO
/****** Object:  ForeignKey [FK_Features_StatusCheck]    Script Date: 06/21/2018 22:00:29 ******/
ALTER TABLE [dbo].[Features]  WITH CHECK ADD  CONSTRAINT [FK_Features_StatusCheck] FOREIGN KEY([StatusID])
REFERENCES [dbo].[StatusCheck] ([StatusID])
GO
ALTER TABLE [dbo].[Features] CHECK CONSTRAINT [FK_Features_StatusCheck]
GO
/****** Object:  ForeignKey [FK_Features_Users]    Script Date: 06/21/2018 22:00:29 ******/
ALTER TABLE [dbo].[Features]  WITH CHECK ADD  CONSTRAINT [FK_Features_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Features] CHECK CONSTRAINT [FK_Features_Users]
GO
/****** Object:  ForeignKey [fk_ImagesFeature_Features]    Script Date: 06/21/2018 22:00:29 ******/
ALTER TABLE [dbo].[ImagesFeature]  WITH CHECK ADD  CONSTRAINT [fk_ImagesFeature_Features] FOREIGN KEY([featureID])
REFERENCES [dbo].[Features] ([FeatureID])
GO
ALTER TABLE [dbo].[ImagesFeature] CHECK CONSTRAINT [fk_ImagesFeature_Features]
GO
/****** Object:  ForeignKey [FK_Project_Member]    Script Date: 06/21/2018 22:00:29 ******/
ALTER TABLE [dbo].[ProjectMember]  WITH CHECK ADD  CONSTRAINT [FK_Project_Member] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Projects] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectMember] CHECK CONSTRAINT [FK_Project_Member]
GO
/****** Object:  ForeignKey [FK_Project_User]    Script Date: 06/21/2018 22:00:29 ******/
ALTER TABLE [dbo].[ProjectMember]  WITH CHECK ADD  CONSTRAINT [FK_Project_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[ProjectMember] CHECK CONSTRAINT [FK_Project_User]
GO
/****** Object:  ForeignKey [FK_ProjectMember_Role]    Script Date: 06/21/2018 22:00:29 ******/
ALTER TABLE [dbo].[ProjectMember]  WITH CHECK ADD  CONSTRAINT [FK_ProjectMember_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[ProjectMember] CHECK CONSTRAINT [FK_ProjectMember_Role]
GO
/****** Object:  ForeignKey [FK_Project_StatusCheck]    Script Date: 06/21/2018 22:00:29 ******/
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Project_StatusCheck] FOREIGN KEY([StatusID])
REFERENCES [dbo].[StatusCheck] ([StatusID])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Project_StatusCheck]
GO
/****** Object:  ForeignKey [FK_Users_Roles]    Script Date: 06/21/2018 22:00:29 ******/
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
