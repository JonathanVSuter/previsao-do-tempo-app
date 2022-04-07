USE [previsao_do_tempo_db.dev]
GO

/****** Object:  Table [dbo].[Clima_Tempo]    Script Date: 07/04/2022 20:46:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clima_Tempo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tempo] [varchar](5) NOT NULL,
	[Maxima] [float] NOT NULL,
	[Minima] [float] NOT NULL,
	[Iuv] [float] NOT NULL,
 CONSTRAINT [PK_Clima] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


/*==================================================================================================================================================*/

USE [previsao_do_tempo_db.dev]
GO

/****** Object:  Table [dbo].[Cidade]    Script Date: 07/04/2022 20:46:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cidade](
	[Id] [int] NOT NULL,
	[Nome] [nchar](70) NOT NULL,
	[Uf] [nchar](2) NOT NULL,
 CONSTRAINT [PK_Cidade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/*==================================================================================================================================================*/

USE [previsao_do_tempo_db.dev]
GO

/****** Object:  Table [dbo].[Previsao_Tempo]    Script Date: 07/04/2022 20:46:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Previsao_Tempo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCidade] [int] NOT NULL,
	[IdClimaTempo] [int] NOT NULL,
	[DataConsulta] [date] NOT NULL,
	[DataClima] [date] NOT NULL,
 CONSTRAINT [PK_Previsao_Tempo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Previsao_Tempo]  WITH CHECK ADD  CONSTRAINT [FK_Cidade_Previsao_Tempo] FOREIGN KEY([IdCidade])
REFERENCES [dbo].[Cidade] ([Id])
GO

ALTER TABLE [dbo].[Previsao_Tempo] CHECK CONSTRAINT [FK_Cidade_Previsao_Tempo]
GO

ALTER TABLE [dbo].[Previsao_Tempo]  WITH CHECK ADD  CONSTRAINT [FK_Clima_Tempo_Previsao_Tempo] FOREIGN KEY([IdClimaTempo])
REFERENCES [dbo].[Clima_Tempo] ([Id])
GO

ALTER TABLE [dbo].[Previsao_Tempo] CHECK CONSTRAINT [FK_Clima_Tempo_Previsao_Tempo]
GO


