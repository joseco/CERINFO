USE [cerinfo]
GO
/****** Object:  Table [dbo].[tbl_administrativo]    Script Date: 13/04/2019 22:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_administrativo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_administrativo] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_area]    Script Date: 13/04/2019 22:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_area](
	[id_area] [int] IDENTITY(1,1) NOT NULL,
	[significado_area] [varchar](50) NOT NULL,
	[abreviatura_area] [varchar](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_area] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_autor]    Script Date: 13/04/2019 22:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_autor](
	[id_autor] [int] IDENTITY(1,1) NOT NULL,
	[nombre_autor] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_autor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_bloqueo]    Script Date: 13/04/2019 22:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_bloqueo](
	[id_bloqueo] [int] IDENTITY(1,1) NOT NULL,
	[id_estudiante] [int] NOT NULL,
	[fecha_bloqueo] [date] NOT NULL,
	[detalle_bloqueo] [varchar](100) NULL,
	[monto_bloqueo] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_bloqueo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_estudiante]    Script Date: 13/04/2019 22:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_estudiante](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_estudiante] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_genero]    Script Date: 13/04/2019 22:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_genero](
	[id_genero] [int] IDENTITY(1,1) NOT NULL,
	[nombre_genero] [varchar](50) NOT NULL,
	[abreviatura_genero] [varchar](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_genero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_idioma]    Script Date: 13/04/2019 22:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_idioma](
	[id_idioma] [int] IDENTITY(1,1) NOT NULL,
	[significado_idioma] [varchar](50) NOT NULL,
	[abreviatura_idioma] [varchar](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_idioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_libro]    Script Date: 13/04/2019 22:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_libro](
	[id_libro] [int] IDENTITY(1,1) NOT NULL,
	[id_autor] [int] NOT NULL,
	[id_genero] [int] NOT NULL,
	[id_idioma] [int] NOT NULL,
	[id_material] [int] NOT NULL,
	[id_sigtop] [int] NOT NULL,
	[titulo_libro] [varchar](50) NOT NULL,
	[tomo_libro] [varchar](50) NOT NULL,
	[id_area] [int] NOT NULL,
	[edicion_libro] [varchar](50) NOT NULL,
	[editorial_libro] [varchar](50) NOT NULL,
	[ano_libro] [varchar](50) NOT NULL,
	[lugar_publicacion_libro] [varchar](50) NOT NULL,
	[ano_publicacion_libro] [varchar](50) NOT NULL,
	[id_targeta] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_libro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_material]    Script Date: 13/04/2019 22:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_material](
	[id_material] [int] IDENTITY(1,1) NOT NULL,
	[significado_material] [varchar](50) NOT NULL,
	[abreviatura_material] [varchar](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_material] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_multa]    Script Date: 13/04/2019 22:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_multa](
	[id_multa] [int] IDENTITY(1,1) NOT NULL,
	[estado_multa] [varchar](10) NULL,
	[detalle_multa] [text] NOT NULL,
	[monto_multa] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_multa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_prestamo]    Script Date: 13/04/2019 22:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_prestamo](
	[id_prestamo] [int] IDENTITY(1,1) NOT NULL,
	[id_estudiante] [int] NOT NULL,
	[id_multa] [int] NOT NULL,
	[id_libro] [int] NOT NULL,
	[fecha_devolucion] [date] NOT NULL,
	[fecha_prestamo] [date] NOT NULL,
	[dias_prestado] [int] NOT NULL,
	[id_administrativo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_prestamo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_sigtop]    Script Date: 13/04/2019 22:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_sigtop](
	[id_sigtop] [int] IDENTITY(1,1) NOT NULL,
	[localidad_sigtop] [varchar](7) NOT NULL,
	[dewey_sigtop] [varchar](8) NOT NULL,
	[cuter_sigtop] [varchar](8) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_sigtop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_tarjeta]    Script Date: 13/04/2019 22:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_tarjeta](
	[id_tarjeta] [int] IDENTITY(1,1) NOT NULL,
	[color_tarjeta] [varchar](50) NOT NULL,
	[dia_prestado_tarjeta] [varchar](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_usuario]    Script Date: 13/04/2019 22:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_usuario](
	[id_usuario] [varchar](50) NOT NULL,
	[contrasena] [varchar](100) NOT NULL,
	[nombre_usuario] [varchar](50) NOT NULL,
	[paterno_usuario] [varchar](50) NOT NULL,
	[materno_usuario] [varchar](50) NOT NULL,
	[tipo_usuario] [varchar](50) NOT NULL,
	[correo] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_administrativo]  WITH CHECK ADD FOREIGN KEY([id_administrativo])
REFERENCES [dbo].[tbl_usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[tbl_bloqueo]  WITH CHECK ADD FOREIGN KEY([id_estudiante])
REFERENCES [dbo].[tbl_estudiante] ([id])
GO
ALTER TABLE [dbo].[tbl_estudiante]  WITH CHECK ADD FOREIGN KEY([id_estudiante])
REFERENCES [dbo].[tbl_usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[tbl_libro]  WITH CHECK ADD FOREIGN KEY([id_area])
REFERENCES [dbo].[tbl_area] ([id_area])
GO
ALTER TABLE [dbo].[tbl_libro]  WITH CHECK ADD FOREIGN KEY([id_autor])
REFERENCES [dbo].[tbl_autor] ([id_autor])
GO
ALTER TABLE [dbo].[tbl_libro]  WITH CHECK ADD FOREIGN KEY([id_genero])
REFERENCES [dbo].[tbl_genero] ([id_genero])
GO
ALTER TABLE [dbo].[tbl_libro]  WITH CHECK ADD FOREIGN KEY([id_idioma])
REFERENCES [dbo].[tbl_idioma] ([id_idioma])
GO
ALTER TABLE [dbo].[tbl_libro]  WITH CHECK ADD FOREIGN KEY([id_material])
REFERENCES [dbo].[tbl_material] ([id_material])
GO
ALTER TABLE [dbo].[tbl_libro]  WITH CHECK ADD FOREIGN KEY([id_sigtop])
REFERENCES [dbo].[tbl_sigtop] ([id_sigtop])
GO
ALTER TABLE [dbo].[tbl_libro]  WITH CHECK ADD FOREIGN KEY([id_targeta])
REFERENCES [dbo].[tbl_tarjeta] ([id_tarjeta])
GO
ALTER TABLE [dbo].[tbl_prestamo]  WITH CHECK ADD FOREIGN KEY([id_administrativo])
REFERENCES [dbo].[tbl_administrativo] ([id])
GO
ALTER TABLE [dbo].[tbl_prestamo]  WITH CHECK ADD FOREIGN KEY([id_estudiante])
REFERENCES [dbo].[tbl_estudiante] ([id])
GO
ALTER TABLE [dbo].[tbl_prestamo]  WITH CHECK ADD FOREIGN KEY([id_libro])
REFERENCES [dbo].[tbl_libro] ([id_libro])
GO
ALTER TABLE [dbo].[tbl_prestamo]  WITH CHECK ADD FOREIGN KEY([id_multa])
REFERENCES [dbo].[tbl_multa] ([id_multa])
GO
/****** Object:  StoredProcedure [dbo].[insertarusuario]    Script Date: 13/04/2019 22:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Angel Michelle Chavez
-- Create date: 13/04/2019
-- Description:	insertar usuario
-- =============================================
CREATE PROCEDURE [dbo].[insertarusuario]
	-- Add the parameters for the stored procedure here
	@pid_usuario varchar(50), @pcontrasena varchar(100), @pnombre_usuario varchar(50)
	, @ppaterno_usuario varchar(50), @pmaterno_usuario varchar(50), @ptipo_usuario varchar(50)
	,@pcorreo varchar(100)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into tbl_usuario ([id_usuario], [contrasena], [nombre_usuario], [paterno_usuario], [materno_usuario], [tipo_usuario],[correo])
	values (@pid_usuario , @pcontrasena , @pnombre_usuario,@ppaterno_usuario , @pmaterno_usuario, @ptipo_usuario ,@pcorreo)
	
	if(@ptipo_usuario='ADMINISTRATIVO')
	insert into tbl_administrativo (id_administrativo) values  (@pid_usuario)

	if(@ptipo_usuario='ESTUDIANTE')
	insert into tbl_estudiante (id_estudiante) values  (@pid_usuario)
	
	
END
GO


create table tbl_recuperarContrasena(
	usuario_id varchar(50) PRIMARY KEY,
	sha1 varchar(100)	
);


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Alexander Torrico
-- Create date: 18/04/2019
-- Description:	Inserta un registro pendiente para modificar la contraseña atravez del enlace del correo electronico
-- =============================================
CREATE PROCEDURE sp_insert_RecuperarPassPendiente
	@user_id varchar(50),
	@sha varchar(100)
AS
BEGIN
	
	IF EXISTS(select * from tbl_recuperarContrasena where usuario_id = @user_id)
		update tbl_recuperarContrasena set sha1 = @sha where usuario_id = @user_id
	ELSE
		insert into tbl_recuperarContrasena values (@user_id,@sha);
END
GO


create function fn_getUserPass(@id_usuario varchar(50))
returns table
as 
	return (select id_usuario, contrasena from tbl_usuario where id_usuario = @id_usuario);
