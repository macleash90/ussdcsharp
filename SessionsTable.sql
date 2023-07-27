
CREATE TABLE [dbo].[UssdSessions](

    [Id] [bigint] IDENTITY(1,1) NOT NULL,

    [Type] [varchar](50) NOT NULL,

    [SessionId] [varchar](300) NOT NULL,

    [Mobile] [varchar](50) NOT NULL,

    [ServiceCode] [varchar](50) NULL,

    [Message] [varchar](100) NOT NULL,

    [MessageDescription] [varchar](255) NULL,

    [Tag] [varchar](100) NULL,

    [Operator] [varchar](50) NULL,

    [CreatedAt] [datetime] NULL,

    [UpdatedAt] [datetime] NULL,

    [MerchantId] [bigint] NULL,

    [MerchantName] [varchar](100) NULL,

CONSTRAINT [PK_UssdSessions] PRIMARY KEY CLUSTERED

(

    [Id] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

)
GO