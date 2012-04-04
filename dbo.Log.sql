CREATE TABLE [dbo].[Log]
(
	[Id]				[INT]			NOT NULL	 IDENTITY(1,1)
		CONSTRAINT PK_Log PRIMARY KEY CLUSTERED,
	[TimeStamp]			[DATETIME]		NOT NULL,
	[Level]				[NVARCHAR](5)	NOT NULL,
	[Logger]			[NVARCHAR](200) NOT NULL,
	[Message]			[NVARCHAR](MAX) NOT NULL,
	[ExceptionType]		[NVARCHAR](MAX) NULL,
	[Operation]			[NVARCHAR](MAX) NULL,
	[ExceptionMessage]	[NVARCHAR](MAX) NULL,
	[StackTrace]		[NVARCHAR](MAX) NULL
)