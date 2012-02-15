SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

DROP SCHEMA IF EXISTS `BuncisDb` ;
CREATE SCHEMA IF NOT EXISTS `BuncisDb` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci ;
DROP SCHEMA IF EXISTS `simplysmile_dbo` ;
CREATE SCHEMA IF NOT EXISTS `simplysmile_dbo` DEFAULT CHARACTER SET latin1 ;
USE `BuncisDb` ;

-- -----------------------------------------------------
-- Table `BuncisDb`.`Membership_Users`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BuncisDb`.`Membership_Users` ;

CREATE  TABLE IF NOT EXISTS `BuncisDb`.`Membership_Users` (
  `UserId` INT NOT NULL ,
  `FirstName` VARCHAR(255) NOT NULL ,
  `LastName` VARCHAR(255) NOT NULL ,
  `Email` VARCHAR(255) NOT NULL ,
  `IsLocked` BIT NOT NULL DEFAULT 0 ,
  `Password` VARCHAR(255) NOT NULL ,
  `CreatedDate` DATETIME NOT NULL ,
  `IsApproved` BIT NOT NULL DEFAULT 1 ,
  `LastLockedDate` DATETIME NULL ,
  `LastLoginDate` DATETIME NULL ,
  `LoweredEmail` VARCHAR(255) NOT NULL ,
  PRIMARY KEY (`UserId`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `BuncisDb`.`Membership_Roles`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BuncisDb`.`Membership_Roles` ;

CREATE  TABLE IF NOT EXISTS `BuncisDb`.`Membership_Roles` (
  `RoleId` INT NOT NULL ,
  `RoleName` VARCHAR(255) NOT NULL ,
  PRIMARY KEY (`RoleId`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `BuncisDb`.`Membership_UsersInRoles`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BuncisDb`.`Membership_UsersInRoles` ;

CREATE  TABLE IF NOT EXISTS `BuncisDb`.`Membership_UsersInRoles` (
  `Id` INT NOT NULL ,
  `UserId` INT NOT NULL ,
  `RoleId` INT NOT NULL ,
  PRIMARY KEY (`Id`) ,
  INDEX `FK_User_UsersInRoles` (`UserId` ASC) ,
  INDEX `FK_Role_UsersInRoles` (`RoleId` ASC) ,
  UNIQUE INDEX `Unique_UsersInRoles` (`UserId` ASC, `RoleId` ASC) ,
  CONSTRAINT `FK_User_UsersInRoles`
    FOREIGN KEY (`UserId` )
    REFERENCES `BuncisDb`.`Membership_Users` (`UserId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Role_UsersInRoles`
    FOREIGN KEY (`RoleId` )
    REFERENCES `BuncisDb`.`Membership_Roles` (`RoleId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `BuncisDb`.`System_Modules`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BuncisDb`.`System_Modules` ;

CREATE  TABLE IF NOT EXISTS `BuncisDb`.`System_Modules` (
  `ModuleId` INT NOT NULL ,
  `ModuleName` VARCHAR(255) NOT NULL ,
  `IsActive` BIT NOT NULL DEFAULT 1 ,
  PRIMARY KEY (`ModuleId`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `BuncisDb`.`Membership_PermissionTypes`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BuncisDb`.`Membership_PermissionTypes` ;

CREATE  TABLE IF NOT EXISTS `BuncisDb`.`Membership_PermissionTypes` (
  `PermissionTypeId` INT NOT NULL ,
  `PermissionName` VARCHAR(255) NOT NULL ,
  PRIMARY KEY (`PermissionTypeId`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `BuncisDb`.`Membership_ModulesInRoles`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BuncisDb`.`Membership_ModulesInRoles` ;

CREATE  TABLE IF NOT EXISTS `BuncisDb`.`Membership_ModulesInRoles` (
  `Id` INT NOT NULL ,
  `ModuleId` INT NOT NULL ,
  `RoleId` INT NOT NULL ,
  PRIMARY KEY (`Id`) ,
  INDEX `FK_Modules_ModulesInRoles` (`ModuleId` ASC) ,
  INDEX `FK_Roles_ModulesInRoles` (`RoleId` ASC) ,
  UNIQUE INDEX `Unique_ModulesInRoles` (`RoleId` ASC, `ModuleId` ASC) ,
  CONSTRAINT `FK_Modules_ModulesInRoles`
    FOREIGN KEY (`ModuleId` )
    REFERENCES `BuncisDb`.`System_Modules` (`ModuleId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Roles_ModulesInRoles`
    FOREIGN KEY (`RoleId` )
    REFERENCES `BuncisDb`.`Membership_Roles` (`RoleId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `BuncisDb`.`Membership_ModulesInUsers`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BuncisDb`.`Membership_ModulesInUsers` ;

CREATE  TABLE IF NOT EXISTS `BuncisDb`.`Membership_ModulesInUsers` (
  `Id` INT NOT NULL ,
  `ModuleId` INT NOT NULL ,
  `UserId` INT NOT NULL ,
  PRIMARY KEY (`Id`) ,
  INDEX `FK_Users_ModulesInUsers` (`UserId` ASC) ,
  INDEX `FK_Modules_ModulesInUsers` (`ModuleId` ASC) ,
  UNIQUE INDEX `Unique_ModulesInUsers` (`ModuleId` ASC, `UserId` ASC) ,
  CONSTRAINT `FK_Users_ModulesInUsers`
    FOREIGN KEY (`UserId` )
    REFERENCES `BuncisDb`.`Membership_Users` (`UserId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Modules_ModulesInUsers`
    FOREIGN KEY (`ModuleId` )
    REFERENCES `BuncisDb`.`System_Modules` (`ModuleId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `BuncisDb`.`Membership_PermissionsInModules`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BuncisDb`.`Membership_PermissionsInModules` ;

CREATE  TABLE IF NOT EXISTS `BuncisDb`.`Membership_PermissionsInModules` (
  `ModulePermissionId` INT NOT NULL ,
  `ModuleId` INT NOT NULL ,
  `PermissionTypeId` INT NOT NULL ,
  PRIMARY KEY (`ModulePermissionId`) ,
  INDEX `FK_Modules_PermissionsInModule` (`ModuleId` ASC) ,
  INDEX `FK_PermissionTypes_PermissionsInModule` (`PermissionTypeId` ASC) ,
  UNIQUE INDEX `Unique_PermissionsInModules` (`PermissionTypeId` ASC, `ModuleId` ASC) ,
  CONSTRAINT `FK_Modules_PermissionsInModule`
    FOREIGN KEY (`ModuleId` )
    REFERENCES `BuncisDb`.`System_Modules` (`ModuleId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_PermissionTypes_PermissionsInModule`
    FOREIGN KEY (`PermissionTypeId` )
    REFERENCES `BuncisDb`.`Membership_PermissionTypes` (`PermissionTypeId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `BuncisDb`.`Membership_UserPermissions`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BuncisDb`.`Membership_UserPermissions` ;

CREATE  TABLE IF NOT EXISTS `BuncisDb`.`Membership_UserPermissions` (
  `Id` INT NOT NULL ,
  `ModulePermissionId` INT NOT NULL ,
  `UserId` INT NOT NULL ,
  PRIMARY KEY (`Id`) ,
  INDEX `FK_ModulePermissions_UserPermissions` (`ModulePermissionId` ASC) ,
  INDEX `FK_Users_UserPermissions` (`UserId` ASC) ,
  UNIQUE INDEX `Unique_UserPermission` (`UserId` ASC, `ModulePermissionId` ASC) ,
  CONSTRAINT `FK_ModulePermissions_UserPermissions`
    FOREIGN KEY (`ModulePermissionId` )
    REFERENCES `BuncisDb`.`Membership_PermissionsInModules` (`ModulePermissionId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Users_UserPermissions`
    FOREIGN KEY (`UserId` )
    REFERENCES `BuncisDb`.`Membership_Users` (`UserId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `BuncisDb`.`Membership_RolePermissions`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BuncisDb`.`Membership_RolePermissions` ;

CREATE  TABLE IF NOT EXISTS `BuncisDb`.`Membership_RolePermissions` (
  `Id` INT NOT NULL ,
  `ModulePermissionId` INT NOT NULL ,
  `RoleId` INT NOT NULL ,
  PRIMARY KEY (`Id`) ,
  INDEX `FK_Roles_RolePermissions` (`RoleId` ASC) ,
  INDEX `FK_ModulePermissions_RolePermissions` (`ModulePermissionId` ASC) ,
  UNIQUE INDEX `Unique_RolePermissions` (`ModulePermissionId` ASC, `RoleId` ASC) ,
  CONSTRAINT `FK_Roles_RolePermissions`
    FOREIGN KEY (`RoleId` )
    REFERENCES `BuncisDb`.`Membership_Roles` (`RoleId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_ModulePermissions_RolePermissions`
    FOREIGN KEY (`ModulePermissionId` )
    REFERENCES `BuncisDb`.`Membership_PermissionsInModules` (`ModulePermissionId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

USE `simplysmile_dbo` ;

-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`animal`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`animal` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`animal` (
  `Id` INT(10) NOT NULL AUTO_INCREMENT ,
  `Description` VARCHAR(255) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `body_weight` DOUBLE NULL DEFAULT NULL ,
  `mother_id` INT(10) NULL DEFAULT NULL ,
  `father_id` INT(10) NULL DEFAULT NULL ,
  `SerialNumber` VARCHAR(255) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `ParentId` INT(10) NULL DEFAULT NULL ,
  PRIMARY KEY (`Id`) ,
  INDEX `FK8DED0743B77C69F9` (`ParentId` ASC) ,
  INDEX `FK8DED0743CE2F4A5D` (`father_id` ASC) ,
  INDEX `FK8DED0743F6A91370` (`mother_id` ASC) ,
  CONSTRAINT `FK8DED0743B77C69F9`
    FOREIGN KEY (`ParentId` )
    REFERENCES `simplysmile_dbo`.`animal` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK8DED0743CE2F4A5D`
    FOREIGN KEY (`father_id` )
    REFERENCES `simplysmile_dbo`.`animal` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK8DED0743F6A91370`
    FOREIGN KEY (`mother_id` )
    REFERENCES `simplysmile_dbo`.`animal` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`anotherentity`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`anotherentity` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`anotherentity` (
  `Id` INT(10) NOT NULL AUTO_INCREMENT ,
  `Output` VARCHAR(255) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `Input` VARCHAR(255) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  PRIMARY KEY (`Id`) )
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`mammal`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`mammal` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`mammal` (
  `Animal` INT(10) NOT NULL ,
  `Pregnant` TINYINT(4) NULL DEFAULT NULL ,
  `BirthDate` DATETIME NULL DEFAULT NULL ,
  PRIMARY KEY (`Animal`) ,
  CONSTRAINT `FK180FD9F36676DC17`
    FOREIGN KEY (`Animal` )
    REFERENCES `simplysmile_dbo`.`animal` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`cat`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`cat` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`cat` (
  `Mammal` INT(10) NOT NULL ,
  PRIMARY KEY (`Mammal`) ,
  CONSTRAINT `FK983303232BA76857`
    FOREIGN KEY (`Mammal` )
    REFERENCES `simplysmile_dbo`.`mammal` (`Animal` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`categories`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`categories` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`categories` (
  `CategoryId` INT(10) NOT NULL ,
  `CategoryName` VARCHAR(15) CHARACTER SET 'utf8' NOT NULL ,
  `Description` VARCHAR(255) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  PRIMARY KEY (`CategoryId`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`customers`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`customers` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`customers` (
  `CustomerId` VARCHAR(255) CHARACTER SET 'utf8' NOT NULL ,
  `CompanyName` VARCHAR(40) CHARACTER SET 'utf8' NOT NULL ,
  `ContactName` VARCHAR(30) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `ContactTitle` VARCHAR(30) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `Address` VARCHAR(60) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `City` VARCHAR(15) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `Region` VARCHAR(15) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `PostalCode` VARCHAR(10) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `Country` VARCHAR(15) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `Phone` VARCHAR(24) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `Fax` VARCHAR(24) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  PRIMARY KEY (`CustomerId`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`dog`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`dog` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`dog` (
  `Mammal` INT(10) NOT NULL ,
  PRIMARY KEY (`Mammal`) ,
  CONSTRAINT `FKAAA2AAA32BA76857`
    FOREIGN KEY (`Mammal` )
    REFERENCES `simplysmile_dbo`.`mammal` (`Animal` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`employees`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`employees` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`employees` (
  `EmployeeId` INT(10) NOT NULL ,
  `LastName` VARCHAR(20) CHARACTER SET 'utf8' NOT NULL ,
  `FirstName` VARCHAR(10) CHARACTER SET 'utf8' NOT NULL ,
  `Title` VARCHAR(30) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `TitleOfCourtesy` VARCHAR(25) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `BirthDate` DATETIME NULL DEFAULT NULL ,
  `HireDate` DATETIME NULL DEFAULT NULL ,
  `Address` VARCHAR(60) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `City` VARCHAR(15) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `Region` VARCHAR(15) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `PostalCode` VARCHAR(10) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `Country` VARCHAR(15) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `HomePhone` VARCHAR(24) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `Extension` VARCHAR(4) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `Notes` VARCHAR(4000) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `ReportsTo` INT(10) NULL DEFAULT NULL ,
  PRIMARY KEY (`EmployeeId`) ,
  INDEX `FKBF2D7FFDE7B80F7` (`ReportsTo` ASC) ,
  CONSTRAINT `FKBF2D7FFDE7B80F7`
    FOREIGN KEY (`ReportsTo` )
    REFERENCES `simplysmile_dbo`.`employees` (`EmployeeId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`region`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`region` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`region` (
  `RegionId` BIGINT(19) NOT NULL AUTO_INCREMENT ,
  `RegionDescription` VARCHAR(50) CHARACTER SET 'utf8' NOT NULL ,
  PRIMARY KEY (`RegionId`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`territories`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`territories` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`territories` (
  `TerritoryId` BIGINT(19) NOT NULL AUTO_INCREMENT ,
  `TerritoryDescription` VARCHAR(50) CHARACTER SET 'utf8' NOT NULL ,
  `RegionId` BIGINT(19) NOT NULL ,
  PRIMARY KEY (`TerritoryId`) ,
  INDEX `FKE8C9AC0917D79B7C` (`RegionId` ASC) ,
  CONSTRAINT `FKE8C9AC0917D79B7C`
    FOREIGN KEY (`RegionId` )
    REFERENCES `simplysmile_dbo`.`region` (`RegionId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`employeeterritories`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`employeeterritories` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`employeeterritories` (
  `EmployeeId` INT(10) NOT NULL ,
  `TerritoryId` BIGINT(19) NOT NULL ,
  PRIMARY KEY (`TerritoryId`, `EmployeeId`) ,
  INDEX `FKF4419A39BBA2339D` (`EmployeeId` ASC) ,
  CONSTRAINT `FKF4419A39B229473A`
    FOREIGN KEY (`TerritoryId` )
    REFERENCES `simplysmile_dbo`.`territories` (`TerritoryId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FKF4419A39BBA2339D`
    FOREIGN KEY (`EmployeeId` )
    REFERENCES `simplysmile_dbo`.`employees` (`EmployeeId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`reptile`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`reptile` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`reptile` (
  `Animal` INT(10) NOT NULL ,
  `BodyTemperature` DOUBLE NULL DEFAULT NULL ,
  PRIMARY KEY (`Animal`) ,
  CONSTRAINT `FK93D08BCA6676DC17`
    FOREIGN KEY (`Animal` )
    REFERENCES `simplysmile_dbo`.`animal` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`lizard`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`lizard` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`lizard` (
  `Reptile` INT(10) NOT NULL ,
  PRIMARY KEY (`Reptile`) ,
  CONSTRAINT `FKD8DE3264EBBAEE33`
    FOREIGN KEY (`Reptile` )
    REFERENCES `simplysmile_dbo`.`reptile` (`Animal` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`suppliers`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`suppliers` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`suppliers` (
  `SupplierId` INT(10) NOT NULL ,
  `CompanyName` VARCHAR(40) CHARACTER SET 'utf8' NOT NULL ,
  `ContactName` VARCHAR(30) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `ContactTitle` VARCHAR(30) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `HomePage` VARCHAR(255) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `Address` VARCHAR(60) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `City` VARCHAR(15) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `Region` VARCHAR(15) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `PostalCode` VARCHAR(10) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `Country` VARCHAR(15) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `Phone` VARCHAR(24) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `Fax` VARCHAR(24) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  PRIMARY KEY (`SupplierId`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`products`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`products` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`products` (
  `ProductId` INT(10) NOT NULL AUTO_INCREMENT ,
  `ProductName` VARCHAR(40) CHARACTER SET 'utf8' NOT NULL ,
  `SupplierId` INT(10) NULL DEFAULT NULL ,
  `CategoryId` INT(10) NULL DEFAULT NULL ,
  `QuantityPerUnit` VARCHAR(20) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `UnitPrice` DECIMAL(19,5) NULL DEFAULT NULL ,
  `UnitsInStock` INT(10) NULL DEFAULT NULL ,
  `UnitsOnOrder` INT(10) NULL DEFAULT NULL ,
  `ReorderLevel` INT(10) NULL DEFAULT NULL ,
  `Discontinued` TINYINT(4) NOT NULL ,
  `ProductImage` VARCHAR(250) NULL DEFAULT NULL ,
  PRIMARY KEY (`ProductId`) ,
  INDEX `FK4A7FD86A7E57CC2E` (`SupplierId` ASC) ,
  INDEX `FK4A7FD86A4A4379C2` (`CategoryId` ASC) ,
  CONSTRAINT `FK4A7FD86A4A4379C2`
    FOREIGN KEY (`CategoryId` )
    REFERENCES `simplysmile_dbo`.`categories` (`CategoryId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK4A7FD86A7E57CC2E`
    FOREIGN KEY (`SupplierId` )
    REFERENCES `simplysmile_dbo`.`suppliers` (`SupplierId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 80
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`shippers`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`shippers` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`shippers` (
  `ShipperId` INT(10) NOT NULL ,
  `CompanyName` VARCHAR(40) CHARACTER SET 'utf8' NOT NULL ,
  `Phone` VARCHAR(24) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `Reference` VARCHAR(64) NULL DEFAULT NULL ,
  PRIMARY KEY (`ShipperId`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`orders`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`orders` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`orders` (
  `OrderId` INT(10) NOT NULL ,
  `CustomerId` VARCHAR(255) CHARACTER SET 'utf8' NOT NULL ,
  `EmployeeId` INT(10) NULL DEFAULT NULL ,
  `OrderDate` DATETIME NULL DEFAULT NULL ,
  `RequiredDate` DATETIME NULL DEFAULT NULL ,
  `ShippedDate` DATETIME NULL DEFAULT NULL ,
  `ShipVia` INT(10) NULL DEFAULT NULL ,
  `Freight` DECIMAL(19,5) NULL DEFAULT NULL ,
  `ShipName` VARCHAR(40) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `ShipAddress` VARCHAR(60) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `ShipCity` VARCHAR(15) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `ShipRegion` VARCHAR(15) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `ShipPostalCode` VARCHAR(10) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `ShipCountry` VARCHAR(15) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  PRIMARY KEY (`OrderId`) ,
  INDEX `FK318A099B476D239C` (`ShipVia` ASC) ,
  INDEX `FK318A099B5D4A9938` (`CustomerId` ASC) ,
  INDEX `FK318A099BBBA2339D` (`EmployeeId` ASC) ,
  CONSTRAINT `FK318A099B476D239C`
    FOREIGN KEY (`ShipVia` )
    REFERENCES `simplysmile_dbo`.`shippers` (`ShipperId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK318A099B5D4A9938`
    FOREIGN KEY (`CustomerId` )
    REFERENCES `simplysmile_dbo`.`customers` (`CustomerId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK318A099BBBA2339D`
    FOREIGN KEY (`EmployeeId` )
    REFERENCES `simplysmile_dbo`.`employees` (`EmployeeId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`orderlines`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`orderlines` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`orderlines` (
  `OrderLineId` BIGINT(19) NOT NULL AUTO_INCREMENT ,
  `OrderId` INT(10) NOT NULL ,
  `ProductId` INT(10) NOT NULL ,
  `UnitPrice` DECIMAL(19,5) NOT NULL ,
  `Quantity` INT(10) NOT NULL ,
  `Discount` DECIMAL(19,5) NOT NULL ,
  PRIMARY KEY (`OrderLineId`) ,
  INDEX `FK9D532A8F25C466D` (`ProductId` ASC) ,
  INDEX `FK9D532A8FD0FB5F15` (`OrderId` ASC) ,
  CONSTRAINT `FK9D532A8F25C466D`
    FOREIGN KEY (`ProductId` )
    REFERENCES `simplysmile_dbo`.`products` (`ProductId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK9D532A8FD0FB5F15`
    FOREIGN KEY (`OrderId` )
    REFERENCES `simplysmile_dbo`.`orders` (`OrderId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 2156
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`physicians`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`physicians` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`physicians` (
  `PhysicianId` BIGINT(19) NOT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(255) CHARACTER SET 'utf8' NOT NULL ,
  PRIMARY KEY (`PhysicianId`) )
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`patients`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`patients` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`patients` (
  `PatientId` BIGINT(19) NOT NULL AUTO_INCREMENT ,
  `Active` TINYINT(4) NOT NULL ,
  `PhysicianId` BIGINT(19) NOT NULL ,
  PRIMARY KEY (`PatientId`) ,
  INDEX `FK668848599D524470` (`PhysicianId` ASC) ,
  CONSTRAINT `FK668848599D524470`
    FOREIGN KEY (`PhysicianId` )
    REFERENCES `simplysmile_dbo`.`physicians` (`PhysicianId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`states`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`states` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`states` (
  `StateId` BIGINT(19) NOT NULL AUTO_INCREMENT ,
  `Abbreviation` VARCHAR(255) CHARACTER SET 'utf8' NOT NULL ,
  `FullName` VARCHAR(255) CHARACTER SET 'utf8' NOT NULL ,
  PRIMARY KEY (`StateId`) )
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`patientrecords`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`patientrecords` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`patientrecords` (
  `PatientRecordId` BIGINT(19) NOT NULL AUTO_INCREMENT ,
  `Gender` INT(10) NOT NULL ,
  `BirthDate` DATETIME NOT NULL ,
  `FirstName` VARCHAR(255) CHARACTER SET 'utf8' NOT NULL ,
  `LastName` VARCHAR(255) CHARACTER SET 'utf8' NOT NULL ,
  `AddressLine1` VARCHAR(255) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `AddressLine2` VARCHAR(255) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `City` VARCHAR(255) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `StateId` BIGINT(19) NULL DEFAULT NULL ,
  `ZipCode` VARCHAR(255) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `PatientId` BIGINT(19) NOT NULL ,
  PRIMARY KEY (`PatientRecordId`) ,
  INDEX `FK43582E961AB7AECE` (`PatientId` ASC) ,
  INDEX `FK43582E96A06D1DCD` (`StateId` ASC) ,
  CONSTRAINT `FK43582E961AB7AECE`
    FOREIGN KEY (`PatientId` )
    REFERENCES `simplysmile_dbo`.`patients` (`PatientId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK43582E96A06D1DCD`
    FOREIGN KEY (`StateId` )
    REFERENCES `simplysmile_dbo`.`states` (`StateId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`roles`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`roles` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`roles` (
  `Id` INT(10) NOT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(255) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `IsActive` TINYINT(4) NULL DEFAULT NULL ,
  `EntityId` INT(10) NULL DEFAULT NULL ,
  `ParentId` INT(10) NULL DEFAULT NULL ,
  PRIMARY KEY (`Id`) ,
  INDEX `FK1A2E670F36A436` (`EntityId` ASC) ,
  INDEX `FK1A2E670F9E248253` (`ParentId` ASC) ,
  CONSTRAINT `FK1A2E670F36A436`
    FOREIGN KEY (`EntityId` )
    REFERENCES `simplysmile_dbo`.`anotherentity` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK1A2E670F9E248253`
    FOREIGN KEY (`ParentId` )
    REFERENCES `simplysmile_dbo`.`roles` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`timesheets`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`timesheets` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`timesheets` (
  `TimesheetId` INT(10) NOT NULL AUTO_INCREMENT ,
  `SubmittedDate` DATETIME NULL DEFAULT NULL ,
  `Submitted` TINYINT(4) NULL DEFAULT NULL ,
  PRIMARY KEY (`TimesheetId`) )
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`timesheetentries`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`timesheetentries` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`timesheetentries` (
  `TimesheetEntryId` INT(10) NOT NULL AUTO_INCREMENT ,
  `EntryDate` DATETIME NULL DEFAULT NULL ,
  `NumberOfHours` INT(10) NULL DEFAULT NULL ,
  `Comments` VARCHAR(255) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `TimesheetID` INT(10) NULL DEFAULT NULL ,
  PRIMARY KEY (`TimesheetEntryId`) ,
  INDEX `FK7E222050C7D0B317` (`TimesheetID` ASC) ,
  CONSTRAINT `FK7E222050C7D0B317`
    FOREIGN KEY (`TimesheetID` )
    REFERENCES `simplysmile_dbo`.`timesheets` (`TimesheetId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`users`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`users` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`users` (
  `UserId` INT(10) NOT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(255) NULL DEFAULT NULL ,
  `InvalidLoginAttempts` INT(10) NULL DEFAULT NULL ,
  `RegisteredAt` DATETIME NULL DEFAULT NULL ,
  `LastLoginDate` DATETIME NULL DEFAULT NULL ,
  `Enum1` VARCHAR(12) CHARACTER SET 'utf8' NULL DEFAULT NULL ,
  `Enum2` INT(10) NOT NULL ,
  `Features` INT(10) NOT NULL DEFAULT '0' ,
  `RoleId` INT(10) NULL DEFAULT NULL ,
  `Property1` VARCHAR(255) NULL DEFAULT NULL ,
  `Property2` VARCHAR(255) NULL DEFAULT NULL ,
  `OtherProperty1` VARCHAR(255) NULL DEFAULT NULL ,
  PRIMARY KEY (`UserId`) ,
  INDEX `FK2C1C7FE5D8C957C7` (`RoleId` ASC) ,
  CONSTRAINT `FK2C1C7FE5D8C957C7`
    FOREIGN KEY (`RoleId` )
    REFERENCES `simplysmile_dbo`.`roles` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `simplysmile_dbo`.`timesheetusers`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `simplysmile_dbo`.`timesheetusers` ;

CREATE  TABLE IF NOT EXISTS `simplysmile_dbo`.`timesheetusers` (
  `TimesheetID` INT(10) NOT NULL ,
  `UserId` INT(10) NOT NULL ,
  INDEX `FKA6EEF73795E61DFF` (`UserId` ASC) ,
  INDEX `FKA6EEF737C7D0B317` (`TimesheetID` ASC) ,
  CONSTRAINT `FKA6EEF73795E61DFF`
    FOREIGN KEY (`UserId` )
    REFERENCES `simplysmile_dbo`.`users` (`UserId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FKA6EEF737C7D0B317`
    FOREIGN KEY (`TimesheetID` )
    REFERENCES `simplysmile_dbo`.`timesheets` (`TimesheetId` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;



SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
