USE [WebEducacionIT]
GO

/****** Object:  StoredProcedure [dbo].[ObtenerServicios]    Script Date: 9/12/2022 9:22:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerServicios]
AS
BEGIN
	SELECT * FROM Servicios WHERE Activo = 1;
END
GO

