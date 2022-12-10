USE [WebEducacionIT]
GO

/****** Object:  StoredProcedure [dbo].[GuardarServicio]    Script Date: 9/12/2022 9:22:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GuardarServicio] 
@Id int,
@Nombre nvarchar(50),
@Activo bit
AS
BEGIN
	DECLARE @vcount int;

	SELECT @vcount = count(*)
	FROM Servicios
	WHERE ID = @Id;

	IF @vcount = 1
	BEGIN
		UPDATE Servicios
		SET Nombre=@Nombre,
			Activo=@Activo
		WHERE ID = @Id;
	END
	ELSE
	BEGIN
		INSERT INTO Servicios (Nombre, Activo) VALUES (@Nombre, @Activo);
	END
END
GO

