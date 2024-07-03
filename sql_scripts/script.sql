USE [master]
GO
/****** Object:  Database [BDindumentaria]    Script Date: 3/7/2024 02:32:44 ******/
CREATE DATABASE [BDindumentaria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BDindumentaria', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BDindumentaria.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BDindumentaria_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BDindumentaria_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BDindumentaria] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDindumentaria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BDindumentaria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BDindumentaria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BDindumentaria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BDindumentaria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BDindumentaria] SET ARITHABORT OFF 
GO
ALTER DATABASE [BDindumentaria] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BDindumentaria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BDindumentaria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BDindumentaria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BDindumentaria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BDindumentaria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BDindumentaria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BDindumentaria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BDindumentaria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BDindumentaria] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BDindumentaria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BDindumentaria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BDindumentaria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BDindumentaria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BDindumentaria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BDindumentaria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BDindumentaria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BDindumentaria] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BDindumentaria] SET  MULTI_USER 
GO
ALTER DATABASE [BDindumentaria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BDindumentaria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BDindumentaria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BDindumentaria] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BDindumentaria] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BDindumentaria] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BDindumentaria] SET QUERY_STORE = ON
GO
ALTER DATABASE [BDindumentaria] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BDindumentaria]
GO
/****** Object:  Table [dbo].[Indumentaria]    Script Date: 3/7/2024 02:32:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Indumentaria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[TipoMaterial] [varchar](50) NOT NULL,
	[Prenda] [varchar](50) NOT NULL,
	[caracteristicaPropia] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteIndumentaria]    Script Date: 3/7/2024 02:32:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteIndumentaria]
    @Id INT
AS
BEGIN
    DELETE FROM Indumentaria WHERE Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertIndumentaria]    Script Date: 3/7/2024 02:32:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertIndumentaria]
    @Codigo VARCHAR(50),
    @Cantidad INT,
    @TipoMaterial VARCHAR(50),
    @CaracteristicaPropia VARCHAR(50)
AS
BEGIN
    INSERT INTO Indumentaria (Codigo, Cantidad, TipoMaterial, CaracteristicaPropia)
    VALUES (@Codigo, @Cantidad, @TipoMaterial, @CaracteristicaPropia);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectAllIndumentaria]    Script Date: 3/7/2024 02:32:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SelectAllIndumentaria]
AS
BEGIN
    SELECT * FROM Indumentaria;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateIndumentaria]    Script Date: 3/7/2024 02:32:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateIndumentaria]
    @Id INT,
    @Codigo VARCHAR(50),
    @Cantidad INT,
    @TipoMaterial VARCHAR(50),
    @CaracteristicaPropia VARCHAR(50)
AS
BEGIN
    UPDATE Indumentaria
    SET Codigo = @Codigo,
        Cantidad = @Cantidad,
        TipoMaterial = @TipoMaterial,
        CaracteristicaPropia = @CaracteristicaPropia
    WHERE Id = @Id;
END
GO
USE [master]
GO
ALTER DATABASE [BDindumentaria] SET  READ_WRITE 
GO
