/** Create the LearningCenter DB**/
CREATE DATABASE [LearningCenter]
GO

USE [LearningCenter]
GO

/** Create the Users Table **/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[UserPassword] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/** Create the ClassMaster Table **/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Classes](
	[ClassId] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [nvarchar](50) NOT NULL,
	[ClassDescription] [nvarchar](50) NOT NULL,
	[ClassPrice] [float] NOT NULL,
	[ClassSessions] [int] NOT NULL,
 CONSTRAINT [PK_ClassMaster] PRIMARY KEY CLUSTERED 
(
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/** Create the UserClasses Table **/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserClasses](
	[ClassId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_UserClasses] PRIMARY KEY CLUSTERED 
(
	[ClassId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/** Create the dependencies **/
ALTER TABLE [dbo].[UserClasses]  WITH CHECK ADD  CONSTRAINT [FK_UserClasses_ClassMaster] FOREIGN KEY([ClassId])
REFERENCES [dbo].[ClassMaster] ([ClassId])
GO

ALTER TABLE [dbo].[UserClasses] CHECK CONSTRAINT [FK_UserClasses_ClassMaster]
GO

ALTER TABLE [dbo].[UserClasses]  WITH CHECK ADD  CONSTRAINT [FK_UserClasses_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO

ALTER TABLE [dbo].[UserClasses] CHECK CONSTRAINT [FK_UserClasses_Users]
GO

/** Populate the Users Table **/


/** Populate the Classes Table **/


/** Populate the UserClasses Table **/