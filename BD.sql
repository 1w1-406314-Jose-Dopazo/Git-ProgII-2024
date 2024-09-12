USE [master]
GO
/****** Object:  Database [1.5]    Script Date: 11/9/2024 22:39:49 ******/
CREATE DATABASE [1.5]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'1.5', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\1.5.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'1.5_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\1.5_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [1.5] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [1.5].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [1.5] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [1.5] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [1.5] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [1.5] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [1.5] SET ARITHABORT OFF 
GO
ALTER DATABASE [1.5] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [1.5] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [1.5] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [1.5] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [1.5] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [1.5] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [1.5] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [1.5] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [1.5] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [1.5] SET  ENABLE_BROKER 
GO
ALTER DATABASE [1.5] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [1.5] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [1.5] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [1.5] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [1.5] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [1.5] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [1.5] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [1.5] SET RECOVERY FULL 
GO
ALTER DATABASE [1.5] SET  MULTI_USER 
GO
ALTER DATABASE [1.5] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [1.5] SET DB_CHAINING OFF 
GO
ALTER DATABASE [1.5] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [1.5] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [1.5] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [1.5] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'1.5', N'ON'
GO
ALTER DATABASE [1.5] SET QUERY_STORE = ON
GO
ALTER DATABASE [1.5] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [1.5]
GO
/****** Object:  Table [dbo].[Articulos]    Script Date: 11/9/2024 22:39:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulos](
	[ID_Articulo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Precio_Unitario] [float] NULL,
 CONSTRAINT [PK_Articulos] PRIMARY KEY CLUSTERED 
(
	[ID_Articulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalles_Facturas]    Script Date: 11/9/2024 22:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalles_Facturas](
	[ID_Detalle_Factura] [int] IDENTITY(1,1) NOT NULL,
	[ID_Factura] [int] NULL,
	[ID_Articulo] [int] NULL,
	[Cantidad] [int] NULL,
 CONSTRAINT [PK_Detalles_Facturas] PRIMARY KEY CLUSTERED 
(
	[ID_Detalle_Factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facturas]    Script Date: 11/9/2024 22:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facturas](
	[ID_Factura] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NULL,
	[ID_Forma_Pago] [int] NULL,
	[Nom_Cliente] [varchar](100) NULL,
 CONSTRAINT [PK_Facturas] PRIMARY KEY CLUSTERED 
(
	[ID_Factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipos_Pagos]    Script Date: 11/9/2024 22:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipos_Pagos](
	[ID_Tipo_Pago] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Tipos_Pagos] PRIMARY KEY CLUSTERED 
(
	[ID_Tipo_Pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Articulos] ON 

INSERT [dbo].[Articulos] ([ID_Articulo], [Nombre], [Precio_Unitario]) VALUES (1, N'Pepsi', 1760)
INSERT [dbo].[Articulos] ([ID_Articulo], [Nombre], [Precio_Unitario]) VALUES (2, N'coca', 1790)
INSERT [dbo].[Articulos] ([ID_Articulo], [Nombre], [Precio_Unitario]) VALUES (3, N'Pizza Congelada', 1800)
INSERT [dbo].[Articulos] ([ID_Articulo], [Nombre], [Precio_Unitario]) VALUES (4, N'Galletas Oreo', 890)
SET IDENTITY_INSERT [dbo].[Articulos] OFF
GO
SET IDENTITY_INSERT [dbo].[Facturas] ON 

INSERT [dbo].[Facturas] ([ID_Factura], [Fecha], [ID_Forma_Pago], [Nom_Cliente]) VALUES (1, CAST(N'2024-09-07T00:00:00.000' AS DateTime), 3, N'Sergio')
INSERT [dbo].[Facturas] ([ID_Factura], [Fecha], [ID_Forma_Pago], [Nom_Cliente]) VALUES (2, CAST(N'2024-08-27T00:00:00.000' AS DateTime), 2, N'Luis')
INSERT [dbo].[Facturas] ([ID_Factura], [Fecha], [ID_Forma_Pago], [Nom_Cliente]) VALUES (4, CAST(N'2024-09-02T00:00:00.000' AS DateTime), 4, N'pepe')
INSERT [dbo].[Facturas] ([ID_Factura], [Fecha], [ID_Forma_Pago], [Nom_Cliente]) VALUES (5, CAST(N'2024-09-02T00:00:00.000' AS DateTime), 4, N'pepe')
INSERT [dbo].[Facturas] ([ID_Factura], [Fecha], [ID_Forma_Pago], [Nom_Cliente]) VALUES (6, CAST(N'2024-09-02T00:00:00.000' AS DateTime), 4, N'Salome')
INSERT [dbo].[Facturas] ([ID_Factura], [Fecha], [ID_Forma_Pago], [Nom_Cliente]) VALUES (7, CAST(N'2024-09-07T00:00:00.000' AS DateTime), 2, N'Alejandro')
SET IDENTITY_INSERT [dbo].[Facturas] OFF
GO
SET IDENTITY_INSERT [dbo].[Tipos_Pagos] ON 

INSERT [dbo].[Tipos_Pagos] ([ID_Tipo_Pago], [Nombre]) VALUES (1, N'Efectivo')
INSERT [dbo].[Tipos_Pagos] ([ID_Tipo_Pago], [Nombre]) VALUES (2, N'Transferencia')
INSERT [dbo].[Tipos_Pagos] ([ID_Tipo_Pago], [Nombre]) VALUES (3, N'Debito')
INSERT [dbo].[Tipos_Pagos] ([ID_Tipo_Pago], [Nombre]) VALUES (4, N'Fiado')
SET IDENTITY_INSERT [dbo].[Tipos_Pagos] OFF
GO
ALTER TABLE [dbo].[Detalles_Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Articulos] FOREIGN KEY([ID_Articulo])
REFERENCES [dbo].[Articulos] ([ID_Articulo])
GO
ALTER TABLE [dbo].[Detalles_Facturas] CHECK CONSTRAINT [FK_Articulos]
GO
ALTER TABLE [dbo].[Detalles_Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas] FOREIGN KEY([ID_Factura])
REFERENCES [dbo].[Facturas] ([ID_Factura])
GO
ALTER TABLE [dbo].[Detalles_Facturas] CHECK CONSTRAINT [FK_Facturas]
GO
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Tipos_Pagos] FOREIGN KEY([ID_Forma_Pago])
REFERENCES [dbo].[Tipos_Pagos] ([ID_Tipo_Pago])
GO
ALTER TABLE [dbo].[Facturas] CHECK CONSTRAINT [FK_Tipos_Pagos]
GO
/****** Object:  StoredProcedure [dbo].[SP_Actualizar_Detalle]    Script Date: 11/9/2024 22:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_Actualizar_Detalle]
@id int,
@id_articulo int,
@cantidad int,
@id_factura int
as
begin
update Detalles_Facturas set ID_Articulo=@id_articulo,Cantidad=@cantidad,ID_Factura=@id_factura where ID_Detalle_Factura=@id
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Actualizar_Factura]    Script Date: 11/9/2024 22:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Actualizar_Factura]
@fecha datetime,
@id_forma_pago int,
@nom_cliente varchar (100),
@id_factura int,
@nro_Factura int out
as
begin
update Facturas set ID_Forma_Pago = @id_forma_pago,Nom_Cliente=@nom_cliente,Fecha=@fecha where ID_Factura = @id_factura 
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Eliminar_Articulo]    Script Date: 11/9/2024 22:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Eliminar_Articulo]
@ID int
as
begin
delete Articulos where ID_Articulo = @ID
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Eliminar_Detalle]    Script Date: 11/9/2024 22:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Eliminar_Detalle]
@ID int
as
begin
delete Detalles_Facturas where ID_Detalle_Factura = @ID
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Eliminar_Factura]    Script Date: 11/9/2024 22:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Eliminar_Factura]
@ID int
as
begin
delete Detalles_Facturas where ID_Factura=@ID
delete Facturas where ID_Factura = @ID
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Eliminar_Tipo_Pago]    Script Date: 11/9/2024 22:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Eliminar_Tipo_Pago]
@ID int
as
begin
delete Tipos_Pagos where ID_Tipo_Pago = @ID
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Guardar_Articulo]    Script Date: 11/9/2024 22:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_Guardar_Articulo] 
@id int,
@nombre varchar (50),
@precio_unit float
as
begin
if exists (select ID_Articulo from Articulos where ID_Articulo = @id) update Articulos set Nombre=@nombre,Precio_Unitario=@precio_unit where ID_Articulo=@id
else Insert into Articulos (Nombre,Precio_Unitario) values (@nombre,@precio_unit)
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Guardar_Detalle]    Script Date: 11/9/2024 22:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Guardar_Detalle]
@ID_Factura int,
@ID_Articulo int,
@Cantidad int
as
begin
insert into Detalles_Facturas (ID_Factura,ID_Articulo,Cantidad) values (@ID_Factura,@ID_Articulo,@Cantidad)
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Guardar_Forma_Pago]    Script Date: 11/9/2024 22:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--use "1.5"

CREATE procedure [dbo].[SP_Guardar_Forma_Pago]
@id int,
@nombre varchar (50)
as
begin
if exists (select ID_Tipo_Pago from Tipos_Pagos where ID_Tipo_Pago=@id) update Tipos_Pagos set Nombre=@nombre where ID_Tipo_Pago=@id
else Insert into Tipos_Pagos(Nombre) values (@nombre)
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Nueva_Factura]    Script Date: 11/9/2024 22:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--use "1.5"

CREATE procedure [dbo].[SP_Nueva_Factura]

@fecha datetime,
@id_forma_pago int,
@nom_cliente varchar (100),
@nro_Factura int out
as
begin

Insert into Facturas (Fecha,ID_Forma_Pago,Nom_Cliente) values (@fecha,@id_forma_pago,@nom_cliente) 

set @nro_Factura = SCOPE_IDENTITY()

select @nro_Factura

return

end



GO
/****** Object:  StoredProcedure [dbo].[SP_Nuevo_Detalle]    Script Date: 11/9/2024 22:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_Nuevo_Detalle]

@id_articulo int,
@cantidad int,
@id_factura int
as
begin
insert into Detalles_Facturas (ID_Articulo,Cantidad,ID_Factura) values (@id_articulo,@cantidad,@id_factura)
end

GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Articulo]    Script Date: 11/9/2024 22:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[SP_Obtener_Articulo]
@ID int
as
begin
select * from Articulos where ID_Articulo = @id
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Articulos]    Script Date: 11/9/2024 22:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[SP_Obtener_Articulos]
as
begin
select * from Articulos
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Detalle]    Script Date: 11/9/2024 22:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_Obtener_Detalle]
(@ID int) 
as
begin
select * from Detalles_Facturas where ID_Detalle_Factura = @id
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Detalles]    Script Date: 11/9/2024 22:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[SP_Obtener_Detalles]
as
begin
select * from Detalles_Facturas
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Detalles_Por_Factura]    Script Date: 11/9/2024 22:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Obtener_Detalles_Por_Factura]
@ID int
as
begin
select * from Detalles_Facturas where ID_Factura = @ID
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Factura]    Script Date: 11/9/2024 22:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[SP_Obtener_Factura]
@ID int
as
begin
select * from Facturas where ID_Factura = @id
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Facturas]    Script Date: 11/9/2024 22:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Obtener_Facturas]
as
begin
select * from Facturas
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Tipo_Pago]    Script Date: 11/9/2024 22:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[SP_Obtener_Tipo_Pago]
@ID int
as
begin
select * from Tipos_Pagos where ID_Tipo_Pago = @id
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Tipos_Pagos]    Script Date: 11/9/2024 22:39:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[SP_Obtener_Tipos_Pagos]
as
begin
select * from Tipos_Pagos
end
GO
USE [master]
GO
ALTER DATABASE [1.5] SET  READ_WRITE 
GO
