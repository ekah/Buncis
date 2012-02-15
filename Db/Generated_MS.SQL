/*
Created: 15/02/2012
Modified: 15/02/2012
Model: Buncis_MS
Database: MS SQL Server 2008
*/

-- Create tables section -------------------------------------------------

-- Table membership_modulesinroles

CREATE TABLE [membership_modulesinroles]
(
 [Id] Int NOT NULL,
 [ModuleId] Int NOT NULL,
 [RoleId] Int NOT NULL
)
go

-- Create indexes for table membership_modulesinroles

CREATE UNIQUE INDEX [Unique_ModulesInRoles] ON [membership_modulesinroles] ([RoleId],[ModuleId])
go

CREATE INDEX [FK_Modules_ModulesInRoles] ON [membership_modulesinroles] ([ModuleId])
go

CREATE INDEX [FK_Roles_ModulesInRoles] ON [membership_modulesinroles] ([RoleId])
go

-- Add keys for table membership_modulesinroles

ALTER TABLE [membership_modulesinroles] ADD CONSTRAINT [PK_membership_modulesinroles] PRIMARY KEY ([Id])
go

-- Table membership_modulesinusers

CREATE TABLE [membership_modulesinusers]
(
 [Id] Int NOT NULL,
 [ModuleId] Int NOT NULL,
 [UserId] Int NOT NULL
)
go

-- Create indexes for table membership_modulesinusers

CREATE UNIQUE INDEX [Unique_ModulesInUsers] ON [membership_modulesinusers] ([ModuleId],[UserId])
go

CREATE INDEX [FK_Users_ModulesInUsers] ON [membership_modulesinusers] ([UserId])
go

CREATE INDEX [FK_Modules_ModulesInUsers] ON [membership_modulesinusers] ([ModuleId])
go

-- Add keys for table membership_modulesinusers

ALTER TABLE [membership_modulesinusers] ADD CONSTRAINT [PK_membership_modulesinusers] PRIMARY KEY ([Id])
go

-- Table membership_permissionsinmodules

CREATE TABLE [membership_permissionsinmodules]
(
 [ModulePermissionId] Int NOT NULL,
 [ModuleId] Int NOT NULL,
 [PermissionTypeId] Int NOT NULL
)
go

-- Create indexes for table membership_permissionsinmodules

CREATE UNIQUE INDEX [Unique_PermissionsInModules] ON [membership_permissionsinmodules] ([PermissionTypeId],[ModuleId])
go

CREATE INDEX [FK_Modules_PermissionsInModule] ON [membership_permissionsinmodules] ([ModuleId])
go

CREATE INDEX [FK_PermissionTypes_PermissionsInModule] ON [membership_permissionsinmodules] ([PermissionTypeId])
go

-- Add keys for table membership_permissionsinmodules

ALTER TABLE [membership_permissionsinmodules] ADD CONSTRAINT [PK_membership_permissionsinmodules] PRIMARY KEY ([ModulePermissionId])
go

-- Table membership_permissiontypes

CREATE TABLE [membership_permissiontypes]
(
 [PermissionTypeId] Int NOT NULL,
 [PermissionName] Varchar(255) NOT NULL
)
go

-- Add keys for table membership_permissiontypes

ALTER TABLE [membership_permissiontypes] ADD CONSTRAINT [PK_membership_permissiontypes] PRIMARY KEY ([PermissionTypeId])
go

-- Table membership_rolepermissions

CREATE TABLE [membership_rolepermissions]
(
 [Id] Int NOT NULL,
 [ModulePermissionId] Int NOT NULL,
 [RoleId] Int NOT NULL
)
go

-- Create indexes for table membership_rolepermissions

CREATE UNIQUE INDEX [Unique_RolePermissions] ON [membership_rolepermissions] ([ModulePermissionId],[RoleId])
go

CREATE INDEX [FK_Roles_RolePermissions] ON [membership_rolepermissions] ([RoleId])
go

CREATE INDEX [FK_ModulePermissions_RolePermissions] ON [membership_rolepermissions] ([ModulePermissionId])
go

-- Add keys for table membership_rolepermissions

ALTER TABLE [membership_rolepermissions] ADD CONSTRAINT [PK_membership_rolepermissions] PRIMARY KEY ([Id])
go

-- Table membership_roles

CREATE TABLE [membership_roles]
(
 [RoleId] Int NOT NULL,
 [RoleName] Varchar(255) NOT NULL
)
go

-- Add keys for table membership_roles

ALTER TABLE [membership_roles] ADD CONSTRAINT [PK_membership_roles] PRIMARY KEY ([RoleId])
go

-- Table membership_userpermissions

CREATE TABLE [membership_userpermissions]
(
 [Id] Int NOT NULL,
 [ModulePermissionId] Int NOT NULL,
 [UserId] Int NOT NULL
)
go

-- Create indexes for table membership_userpermissions

CREATE UNIQUE INDEX [Unique_UserPermission] ON [membership_userpermissions] ([UserId],[ModulePermissionId])
go

CREATE INDEX [FK_ModulePermissions_UserPermissions] ON [membership_userpermissions] ([ModulePermissionId])
go

CREATE INDEX [FK_Users_UserPermissions] ON [membership_userpermissions] ([UserId])
go

-- Add keys for table membership_userpermissions

ALTER TABLE [membership_userpermissions] ADD CONSTRAINT [PK_membership_userpermissions] PRIMARY KEY ([Id])
go

-- Table membership_users

CREATE TABLE [membership_users]
(
 [UserId] Int NOT NULL,
 [FirstName] Varchar(255) NOT NULL,
 [LastName] Varchar(255) NOT NULL,
 [Email] Varchar(255) NOT NULL,
 [IsLocked] Int DEFAULT 0 NOT NULL,
 [Password] Varchar(255) NOT NULL,
 [CreatedDate] Datetime2 NOT NULL,
 [IsApproved] Int DEFAULT 1 NOT NULL,
 [LastLockedDate] Datetime2 NULL,
 [LastLoginDate] Datetime2 NULL,
 [LoweredEmail] Varchar(255) NOT NULL
)
go

-- Add keys for table membership_users

ALTER TABLE [membership_users] ADD CONSTRAINT [PK_membership_users] PRIMARY KEY ([UserId])
go

-- Table membership_usersinroles

CREATE TABLE [membership_usersinroles]
(
 [Id] Int NOT NULL,
 [UserId] Int NOT NULL,
 [RoleId] Int NOT NULL
)
go

-- Create indexes for table membership_usersinroles

CREATE UNIQUE INDEX [Unique_UsersInRoles] ON [membership_usersinroles] ([UserId],[RoleId])
go

CREATE INDEX [FK_User_UsersInRoles] ON [membership_usersinroles] ([UserId])
go

CREATE INDEX [FK_Role_UsersInRoles] ON [membership_usersinroles] ([RoleId])
go

-- Add keys for table membership_usersinroles

ALTER TABLE [membership_usersinroles] ADD CONSTRAINT [PK_membership_usersinroles] PRIMARY KEY ([Id])
go

-- Table system_modules

CREATE TABLE [system_modules]
(
 [ModuleId] Int NOT NULL,
 [ModuleName] Varchar(255) NOT NULL,
 [IsActive] Int DEFAULT 1 NOT NULL
)
go

-- Add keys for table system_modules

ALTER TABLE [system_modules] ADD CONSTRAINT [PK_system_modules] PRIMARY KEY ([ModuleId])
go

-- Create relationships section ------------------------------------------------- 

ALTER TABLE [membership_modulesinroles] ADD CONSTRAINT [FK_Modules_ModulesInRoles] FOREIGN KEY ([ModuleId]) REFERENCES [system_modules] ([ModuleId])
go

ALTER TABLE [membership_modulesinroles] ADD CONSTRAINT [FK_Roles_ModulesInRoles] FOREIGN KEY ([RoleId]) REFERENCES [membership_roles] ([RoleId])
go

ALTER TABLE [membership_modulesinusers] ADD CONSTRAINT [FK_Users_ModulesInUsers] FOREIGN KEY ([UserId]) REFERENCES [membership_users] ([UserId])
go

ALTER TABLE [membership_modulesinusers] ADD CONSTRAINT [FK_Modules_ModulesInUsers] FOREIGN KEY ([ModuleId]) REFERENCES [system_modules] ([ModuleId])
go

ALTER TABLE [membership_permissionsinmodules] ADD CONSTRAINT [FK_Modules_PermissionsInModule] FOREIGN KEY ([ModuleId]) REFERENCES [system_modules] ([ModuleId])
go

ALTER TABLE [membership_permissionsinmodules] ADD CONSTRAINT [FK_PermissionTypes_PermissionsInModule] FOREIGN KEY ([PermissionTypeId]) REFERENCES [membership_permissiontypes] ([PermissionTypeId])
go

ALTER TABLE [membership_rolepermissions] ADD CONSTRAINT [FK_Roles_RolePermissions] FOREIGN KEY ([RoleId]) REFERENCES [membership_roles] ([RoleId])
go

ALTER TABLE [membership_rolepermissions] ADD CONSTRAINT [FK_ModulePermissions_RolePermissions] FOREIGN KEY ([ModulePermissionId]) REFERENCES [membership_permissionsinmodules] ([ModulePermissionId])
go

ALTER TABLE [membership_userpermissions] ADD CONSTRAINT [FK_ModulePermissions_UserPermissions] FOREIGN KEY ([ModulePermissionId]) REFERENCES [membership_permissionsinmodules] ([ModulePermissionId])
go

ALTER TABLE [membership_userpermissions] ADD CONSTRAINT [FK_Users_UserPermissions] FOREIGN KEY ([UserId]) REFERENCES [membership_users] ([UserId])
go

ALTER TABLE [membership_usersinroles] ADD CONSTRAINT [FK_User_UsersInRoles] FOREIGN KEY ([UserId]) REFERENCES [membership_users] ([UserId])
go

ALTER TABLE [membership_usersinroles] ADD CONSTRAINT [FK_Role_UsersInRoles] FOREIGN KEY ([RoleId]) REFERENCES [membership_roles] ([RoleId])
go



-- Grant permissions section -------------------------------------------------


