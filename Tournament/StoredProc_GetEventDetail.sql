USE [HollywoodTest]
GO
/****** Object:  StoredProcedure [dbo].[GetEventDetail]    Script Date: 2020/10/14 4:53:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kielaen
-- Create date: 2020/10/13
-- Description:	GetEvents
-- =============================================
ALTER PROCEDURE [dbo].[GetEventDetail] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [EventDetailID]
      ,[FK_EventID]
	  ,E.EventName
      ,[FK_EventDetailStatusID]
	  ,ES.EventDetailStatusName
      ,[EventDetailName]
      ,[EventDetailNumber]
      ,[EventDetailOdd]
      ,[FinishingPosition]
      ,[FirstTimer]
  FROM [HollywoodTest].[dbo].[EventDetails] ED
  LEFT JOIN [HollywoodTest].[dbo].[Events] E with (nolock) On ED.FK_EventID = E.EventID
  LEFT JOIN EventDetailStatuses ES with (nolock) On ED.FK_EventDetailStatusID = ES.EventDetailStatusID
 
END
