/*
Created: 15/02/2012
Modified: 15/02/2012
Model: Buncis
Database: MySQL 5.5
*/

-- Create tables section -------------------------------------------------

-- Table buncisdb.membership_modulesinroles

CREATE TABLE membership_modulesinroles
(
  Id Int NOT NULL,
  ModuleId Int NOT NULL,
  RoleId Int NOT NULL
) ENGINE = InnoDB
  ROW_FORMAT = Compact
;

ALTER TABLE membership_modulesinroles ADD PRIMARY KEY (Id)
;

CREATE UNIQUE INDEX Unique_ModulesInRoles USING BTREE ON membership_modulesinroles (RoleId,ModuleId)
;

CREATE INDEX FK_Modules_ModulesInRoles USING BTREE ON membership_modulesinroles (ModuleId)
;

CREATE INDEX FK_Roles_ModulesInRoles USING BTREE ON membership_modulesinroles (RoleId)
;

-- Table buncisdb.membership_modulesinusers

CREATE TABLE membership_modulesinusers
(
  Id Int NOT NULL,
  ModuleId Int NOT NULL,
  UserId Int NOT NULL
) ENGINE = InnoDB
  ROW_FORMAT = Compact
;

ALTER TABLE membership_modulesinusers ADD PRIMARY KEY (Id)
;

CREATE UNIQUE INDEX Unique_ModulesInUsers USING BTREE ON membership_modulesinusers (ModuleId,UserId)
;

CREATE INDEX FK_Users_ModulesInUsers USING BTREE ON membership_modulesinusers (UserId)
;

CREATE INDEX FK_Modules_ModulesInUsers USING BTREE ON membership_modulesinusers (ModuleId)
;

-- Table buncisdb.membership_permissionsinmodules

CREATE TABLE membership_permissionsinmodules
(
  ModulePermissionId Int NOT NULL,
  ModuleId Int NOT NULL,
  PermissionTypeId Int NOT NULL
) ENGINE = InnoDB
  ROW_FORMAT = Compact
;

ALTER TABLE membership_permissionsinmodules ADD PRIMARY KEY (ModulePermissionId)
;

CREATE UNIQUE INDEX Unique_PermissionsInModules USING BTREE ON membership_permissionsinmodules (PermissionTypeId,ModuleId)
;

CREATE INDEX FK_Modules_PermissionsInModule USING BTREE ON membership_permissionsinmodules (ModuleId)
;

CREATE INDEX FK_PermissionTypes_PermissionsInModule USING BTREE ON membership_permissionsinmodules (PermissionTypeId)
;

-- Table buncisdb.membership_permissiontypes

CREATE TABLE membership_permissiontypes
(
  PermissionTypeId Int NOT NULL,
  PermissionName Varchar(255) NOT NULL
) ENGINE = InnoDB
  ROW_FORMAT = Compact
;

ALTER TABLE membership_permissiontypes ADD PRIMARY KEY (PermissionTypeId)
;

-- Table buncisdb.membership_rolepermissions

CREATE TABLE membership_rolepermissions
(
  Id Int NOT NULL,
  ModulePermissionId Int NOT NULL,
  RoleId Int NOT NULL
) ENGINE = InnoDB
  ROW_FORMAT = Compact
;

ALTER TABLE membership_rolepermissions ADD PRIMARY KEY (Id)
;

CREATE UNIQUE INDEX Unique_RolePermissions USING BTREE ON membership_rolepermissions (ModulePermissionId,RoleId)
;

CREATE INDEX FK_Roles_RolePermissions USING BTREE ON membership_rolepermissions (RoleId)
;

CREATE INDEX FK_ModulePermissions_RolePermissions USING BTREE ON membership_rolepermissions (ModulePermissionId)
;

-- Table buncisdb.membership_roles

CREATE TABLE membership_roles
(
  RoleId Int NOT NULL,
  RoleName Varchar(255) NOT NULL
) ENGINE = InnoDB
  ROW_FORMAT = Compact
;

ALTER TABLE membership_roles ADD PRIMARY KEY (RoleId)
;

-- Table buncisdb.membership_userpermissions

CREATE TABLE membership_userpermissions
(
  Id Int NOT NULL,
  ModulePermissionId Int NOT NULL,
  UserId Int NOT NULL
) ENGINE = InnoDB
  ROW_FORMAT = Compact
;

ALTER TABLE membership_userpermissions ADD PRIMARY KEY (Id)
;

CREATE UNIQUE INDEX Unique_UserPermission USING BTREE ON membership_userpermissions (UserId,ModulePermissionId)
;

CREATE INDEX FK_ModulePermissions_UserPermissions USING BTREE ON membership_userpermissions (ModulePermissionId)
;

CREATE INDEX FK_Users_UserPermissions USING BTREE ON membership_userpermissions (UserId)
;

-- Table buncisdb.membership_users

CREATE TABLE membership_users
(
  UserId Int NOT NULL,
  FirstName Varchar(255) NOT NULL,
  LastName Varchar(255) NOT NULL,
  Email Varchar(255) NOT NULL,
  IsLocked Bit(1) NOT NULL DEFAULT 0,
  Password Varchar(255) NOT NULL,
  CreatedDate Datetime NOT NULL,
  IsApproved Bit(1) NOT NULL DEFAULT 1,
  LastLockedDate Datetime,
  LastLoginDate Datetime,
  LoweredEmail Varchar(255) NOT NULL
) ENGINE = InnoDB
  ROW_FORMAT = Compact
;

ALTER TABLE membership_users ADD PRIMARY KEY (UserId)
;

-- Table buncisdb.membership_usersinroles

CREATE TABLE membership_usersinroles
(
  Id Int NOT NULL,
  UserId Int NOT NULL,
  RoleId Int NOT NULL
) ENGINE = InnoDB
  ROW_FORMAT = Compact
;

ALTER TABLE membership_usersinroles ADD PRIMARY KEY (Id)
;

CREATE UNIQUE INDEX Unique_UsersInRoles USING BTREE ON membership_usersinroles (UserId,RoleId)
;

CREATE INDEX FK_User_UsersInRoles USING BTREE ON membership_usersinroles (UserId)
;

CREATE INDEX FK_Role_UsersInRoles USING BTREE ON membership_usersinroles (RoleId)
;

-- Table buncisdb.system_modules

CREATE TABLE system_modules
(
  ModuleId Int NOT NULL,
  ModuleName Varchar(255) NOT NULL,
  IsActive Bit(1) NOT NULL DEFAULT 1
) ENGINE = InnoDB
  ROW_FORMAT = Compact
;

ALTER TABLE system_modules ADD PRIMARY KEY (ModuleId)
;

-- Create relationships section ------------------------------------------------- 

ALTER TABLE membership_modulesinroles ADD CONSTRAINT FK_Modules_ModulesInRoles FOREIGN KEY (ModuleId) REFERENCES system_modules (ModuleId) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE membership_modulesinroles ADD CONSTRAINT FK_Roles_ModulesInRoles FOREIGN KEY (RoleId) REFERENCES membership_roles (RoleId) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE membership_modulesinusers ADD CONSTRAINT FK_Users_ModulesInUsers FOREIGN KEY (UserId) REFERENCES membership_users (UserId) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE membership_modulesinusers ADD CONSTRAINT FK_Modules_ModulesInUsers FOREIGN KEY (ModuleId) REFERENCES system_modules (ModuleId) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE membership_permissionsinmodules ADD CONSTRAINT FK_Modules_PermissionsInModule FOREIGN KEY (ModuleId) REFERENCES system_modules (ModuleId) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE membership_permissionsinmodules ADD CONSTRAINT FK_PermissionTypes_PermissionsInModule FOREIGN KEY (PermissionTypeId) REFERENCES membership_permissiontypes (PermissionTypeId) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE membership_rolepermissions ADD CONSTRAINT FK_Roles_RolePermissions FOREIGN KEY (RoleId) REFERENCES membership_roles (RoleId) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE membership_rolepermissions ADD CONSTRAINT FK_ModulePermissions_RolePermissions FOREIGN KEY (ModulePermissionId) REFERENCES membership_permissionsinmodules (ModulePermissionId) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE membership_userpermissions ADD CONSTRAINT FK_ModulePermissions_UserPermissions FOREIGN KEY (ModulePermissionId) REFERENCES membership_permissionsinmodules (ModulePermissionId) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE membership_userpermissions ADD CONSTRAINT FK_Users_UserPermissions FOREIGN KEY (UserId) REFERENCES membership_users (UserId) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE membership_usersinroles ADD CONSTRAINT FK_User_UsersInRoles FOREIGN KEY (UserId) REFERENCES membership_users (UserId) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE membership_usersinroles ADD CONSTRAINT FK_Role_UsersInRoles FOREIGN KEY (RoleId) REFERENCES membership_roles (RoleId) ON DELETE NO ACTION ON UPDATE NO ACTION
;


