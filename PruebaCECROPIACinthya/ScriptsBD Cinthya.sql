USE [PruebaCECROPIACinthya]
GO

/****** Object:  Table [dbo].[BloodTypes]    Script Date: 02/06/2018 20:58:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[BloodTypes](
	[ID] [int] NOT NULL,
	[BloodType] [varchar](50) NULL,
 CONSTRAINT [PK_BloodTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO




-----------------------------------------------------------------


GO

/****** Object:  Table [dbo].[Countries]    Script Date: 02/06/2018 20:59:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Countries](
	[ID] [int] NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO



--------------------------------------------------------------


GO

/****** Object:  Table [dbo].[Patients]    Script Date: 02/06/2018 20:59:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Patients](
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](100) NULL,
	[ID] [varchar](50) NOT NULL,
	[DateBirth] [date] NULL,
	[Nationality] [int] NULL,
	[Diseases] [varchar](max) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[BloodType] [int] NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Patients]  WITH CHECK ADD  CONSTRAINT [FK__Patients__BloodT__0519C6AF] FOREIGN KEY([BloodType])
REFERENCES [dbo].[BloodTypes] ([ID])
GO

ALTER TABLE [dbo].[Patients] CHECK CONSTRAINT [FK__Patients__BloodT__0519C6AF]
GO

ALTER TABLE [dbo].[Patients]  WITH CHECK ADD  CONSTRAINT [FK__Patients__Nation__060DEAE8] FOREIGN KEY([Nationality])
REFERENCES [dbo].[Countries] ([ID])
GO

ALTER TABLE [dbo].[Patients] CHECK CONSTRAINT [FK__Patients__Nation__060DEAE8]
GO


---------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[AddPatient]    Script Date: 02/07/2018 00:41:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[AddPatient] 
	@FirstName varchar(50),
	@LastName varchar(100), 
	@ID varchar(50), 
	@DateBirth date, 
	@Nationality int, 
	@Diseases varchar (MAX), 
	@PhoneNumber varchar (50), 
	@BloodType int
AS
BEGIN
	
	SET NOCOUNT ON;

    Insert into dbo.Patients (FirstName, LastName, ID, DateBirth, Nationality, Diseases, PhoneNumber, BloodType) 
    values(@FirstName, @LastName, @ID, @DateBirth, @Nationality, @Diseases, @PhoneNumber, @BloodType) 
END


--------------------------------------------------------------------


GO
/****** Object:  StoredProcedure [dbo].[DeletePatient]    Script Date: 02/07/2018 00:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[DeletePatient] 
	@ID varchar(50)
AS
BEGIN
	
	SET NOCOUNT ON;

    Delete from dbo.Patients  
	where ID = @ID 
END


------------------------------------------------------------------



GO
/****** Object:  StoredProcedure [dbo].[SearchPatient]    Script Date: 02/07/2018 00:42:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SearchPatient] 
	@ID varchar(50)
AS
BEGIN
	
	SET NOCOUNT ON;

    select p.FirstName, p.LastName, p.ID, p.DateBirth, c.ID as Nacionality, p.Diseases, p.PhoneNumber, b.ID as BloodType from dbo.Countries as c 
	inner join dbo.Patients p
	on c.ID = p.Nationality
	inner join dbo.BloodTypes b
	on b.ID = p.BloodType
	where p.ID = @ID
    
END


---------------------------------------------------------------


GO
/****** Object:  StoredProcedure [dbo].[UpdatePatient]    Script Date: 02/07/2018 00:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[UpdatePatient] 
	@FirstName varchar(50),
	@LastName varchar(100), 
	@ID varchar(50), 
	@DateBirth date, 
	@Nationality int, 
	@Diseases varchar (MAX), 
	@PhoneNumber varchar (50), 
	@BloodType int
AS
BEGIN
	
	SET NOCOUNT ON;

    Update dbo.Patients
    set FirstName = @FirstName, 
		LastName = @LastName, 		 
		DateBirth = @DateBirth, 
		Nationality = @Nationality, 
		Diseases = @Diseases, 
		PhoneNumber = @PhoneNumber, 
		BloodType = @BloodType
	where ID = @ID 
END
