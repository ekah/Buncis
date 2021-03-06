/*
Run this script on:

        (local).Buncis_empty    -  This database will be modified

to synchronize it with:

        (local).Buncis

You are recommended to back up your database before running this script

Script created by SQL Compare version 10.1.0 from Red Gate Software Ltd at 8/9/2012 9:07:41 PM

*/
SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
IF EXISTS (SELECT * FROM tempdb..sysobjects WHERE id=OBJECT_ID('tempdb..#tmpErrors')) DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
GO
BEGIN TRANSACTION
GO
PRINT N'Creating role aspnet_Membership_FullAccess'
GO
CREATE ROLE [aspnet_Membership_FullAccess]
AUTHORIZATION [dbo]
GO
PRINT N'Creating role aspnet_Membership_BasicAccess'
GO
CREATE ROLE [aspnet_Membership_BasicAccess]
AUTHORIZATION [dbo]
GO
PRINT N'Creating role aspnet_Membership_ReportingAccess'
GO
CREATE ROLE [aspnet_Membership_ReportingAccess]
AUTHORIZATION [dbo]
GO
PRINT N'Creating role aspnet_Profile_FullAccess'
GO
CREATE ROLE [aspnet_Profile_FullAccess]
AUTHORIZATION [dbo]
GO
PRINT N'Creating role aspnet_Profile_BasicAccess'
GO
CREATE ROLE [aspnet_Profile_BasicAccess]
AUTHORIZATION [dbo]
GO
PRINT N'Creating role aspnet_Profile_ReportingAccess'
GO
CREATE ROLE [aspnet_Profile_ReportingAccess]
AUTHORIZATION [dbo]
GO
PRINT N'Creating role aspnet_Roles_FullAccess'
GO
CREATE ROLE [aspnet_Roles_FullAccess]
AUTHORIZATION [dbo]
GO
PRINT N'Creating role aspnet_Roles_BasicAccess'
GO
CREATE ROLE [aspnet_Roles_BasicAccess]
AUTHORIZATION [dbo]
GO
PRINT N'Creating role aspnet_Roles_ReportingAccess'
GO
CREATE ROLE [aspnet_Roles_ReportingAccess]
AUTHORIZATION [dbo]
GO
PRINT N'Creating role aspnet_Personalization_FullAccess'
GO
CREATE ROLE [aspnet_Personalization_FullAccess]
AUTHORIZATION [dbo]
GO
PRINT N'Creating role aspnet_Personalization_BasicAccess'
GO
CREATE ROLE [aspnet_Personalization_BasicAccess]
AUTHORIZATION [dbo]
GO
PRINT N'Creating role aspnet_Personalization_ReportingAccess'
GO
CREATE ROLE [aspnet_Personalization_ReportingAccess]
AUTHORIZATION [dbo]
GO
PRINT N'Creating role aspnet_WebEvent_FullAccess'
GO
CREATE ROLE [aspnet_WebEvent_FullAccess]
AUTHORIZATION [dbo]
GO
IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
PRINT 'The database update succeeded'
COMMIT TRANSACTION
END
ELSE PRINT 'The database update failed'
GO
DROP TABLE #tmpErrors
GO
