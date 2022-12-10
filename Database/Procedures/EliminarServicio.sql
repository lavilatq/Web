USE [WebEducacionIT]
GO

/****** Object:  StoredProcedure [dbo].[EliminarServicio]    Script Date: 9/12/2022 9:22:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EliminarServicio]
@Id int
AS
BEGIN
	UPDATE Servicios
	SET Activo = 0
	WHERE id = @Id;
END
GO

