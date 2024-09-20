
CREATE DATABASE [406314]

GO
Use [406314]
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
/****** Object:  Table [dbo].[Detalles_Facturas]    Script Date: 14/9/2024 17:53:57 ******/
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
/****** Object:  Table [dbo].[Facturas]    Script Date: 14/9/2024 17:53:57 ******/
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
/****** Object:  Table [dbo].[Tipos_Pagos]    Script Date: 14/9/2024 17:53:57 ******/
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
SET IDENTITY_INSERT [dbo].[Facturas] ON 
GO
INSERT [dbo].[Facturas] ([ID_Factura], [Fecha], [ID_Forma_Pago], [Nom_Cliente]) VALUES (1, CAST(N'2024-09-07T00:00:00.000' AS DateTime), 3, N'Sergio')
GO
INSERT [dbo].[Facturas] ([ID_Factura], [Fecha], [ID_Forma_Pago], [Nom_Cliente]) VALUES (2, CAST(N'2024-08-27T00:00:00.000' AS DateTime), 2, N'Luis')
GO
INSERT [dbo].[Facturas] ([ID_Factura], [Fecha], [ID_Forma_Pago], [Nom_Cliente]) VALUES (4, CAST(N'2024-09-02T00:00:00.000' AS DateTime), 4, N'pepe')
GO
INSERT [dbo].[Facturas] ([ID_Factura], [Fecha], [ID_Forma_Pago], [Nom_Cliente]) VALUES (5, CAST(N'2024-09-02T00:00:00.000' AS DateTime), 4, N'pepe')
GO
INSERT [dbo].[Facturas] ([ID_Factura], [Fecha], [ID_Forma_Pago], [Nom_Cliente]) VALUES (6, CAST(N'2024-09-02T00:00:00.000' AS DateTime), 4, N'Salome')
GO
INSERT [dbo].[Facturas] ([ID_Factura], [Fecha], [ID_Forma_Pago], [Nom_Cliente]) VALUES (7, CAST(N'2024-09-07T00:00:00.000' AS DateTime), 2, N'Alejandro')
GO
SET IDENTITY_INSERT [dbo].[Facturas] OFF
GO
SET IDENTITY_INSERT [dbo].[Articulos] ON 
GO
INSERT [dbo].[Articulos] ([ID_Articulo], [Nombre],[Precio_Unitario]) VALUES (1, N'CocaCola250ml',1400)
Go
INSERT [dbo].[Articulos] ([ID_Articulo], [Nombre],[Precio_Unitario]) VALUES (2, N'Pepsi 250ml',1200)
GO
SET IDENTITY_INSERT [dbo].[Tipos_Pagos] ON 
GO
INSERT [dbo].[Tipos_Pagos] ([ID_Tipo_Pago], [Nombre]) VALUES (1, N'Efectivo')
GO
INSERT [dbo].[Tipos_Pagos] ([ID_Tipo_Pago], [Nombre]) VALUES (2, N'Transferencia')
GO
INSERT [dbo].[Tipos_Pagos] ([ID_Tipo_Pago], [Nombre]) VALUES (3, N'Debito')
GO
INSERT [dbo].[Tipos_Pagos] ([ID_Tipo_Pago], [Nombre]) VALUES (4, N'Fiado')
GO
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
/****** Object:  StoredProcedure [dbo].[SP_Actualizar_Detalle]    Script Date: 14/9/2024 17:53:57 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Actualizar_Factura]    Script Date: 14/9/2024 17:53:58 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Eliminar_Articulo]    Script Date: 14/9/2024 17:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_Eliminar_Articulo]
@ID int
as
begin
begin
delete Articulos where ID_Articulo = @ID
end
begin
declare @max int
set @max=(select max([Id_Articulo]) from [Articulos])
if @max IS NULL   
  SET @max = 0
DBCC CHECKIDENT ([Articulos], RESEED, @max)
end
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Eliminar_Detalle]    Script Date: 14/9/2024 17:53:58 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Eliminar_Factura]    Script Date: 14/9/2024 17:53:58 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Eliminar_Tipo_Pago]    Script Date: 14/9/2024 17:53:58 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Guardar_Articulo]    Script Date: 14/9/2024 17:53:58 ******/
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
begin
declare @max int
select @max=max(ID_Articulo) from Articulos
if @max IS NULL   
  SET @max = 0
DBCC CHECKIDENT (Articulos, RESEED, @max)
end
if @id>0 and exists (select ID_Articulo from Articulos where ID_Articulo = @id) update Articulos set Nombre=@nombre,Precio_Unitario=@precio_unit where ID_Articulo=@id
else Insert into Articulos (Nombre,Precio_Unitario) values (@nombre,@precio_unit)
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Guardar_Detalle]    Script Date: 14/9/2024 17:53:58 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Guardar_Forma_Pago]    Script Date: 14/9/2024 17:53:58 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Nueva_Factura]    Script Date: 14/9/2024 17:53:58 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Nuevo_Detalle]    Script Date: 14/9/2024 17:53:58 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Articulo]    Script Date: 14/9/2024 17:53:58 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Articulos]    Script Date: 14/9/2024 17:53:58 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Detalle]    Script Date: 14/9/2024 17:53:58 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Detalles]    Script Date: 14/9/2024 17:53:58 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Detalles_Por_Factura]    Script Date: 14/9/2024 17:53:58 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Factura]    Script Date: 14/9/2024 17:53:58 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Facturas]    Script Date: 14/9/2024 17:53:58 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Tipo_Pago]    Script Date: 14/9/2024 17:53:58 ******/
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
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Tipos_Pagos]    Script Date: 14/9/2024 17:53:58 ******/
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
