-- ----------------------------------------------------------------------
-- MySQL Migration Toolkit
-- SQL Create Script
-- ----------------------------------------------------------------------

SET FOREIGN_KEY_CHECKS = 0;

CREATE DATABASE IF NOT EXISTS `SimplySmile_dbo`
  CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `SimplySmile_dbo`;
-- -------------------------------------
-- Tables

DROP TABLE IF EXISTS `SimplySmile_dbo`.`Region`;
CREATE TABLE `SimplySmile_dbo`.`Region` (
  `RegionId` BIGINT(19) NOT NULL AUTO_INCREMENT,
  `RegionDescription` VARCHAR(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`RegionId`)
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `SimplySmile_dbo`.`Suppliers`;
CREATE TABLE `SimplySmile_dbo`.`Suppliers` (
  `SupplierId` INT(10) NOT NULL,
  `CompanyName` VARCHAR(40) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ContactName` VARCHAR(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `ContactTitle` VARCHAR(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `HomePage` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `Address` VARCHAR(60) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `City` VARCHAR(15) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `Region` VARCHAR(15) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `PostalCode` VARCHAR(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `Country` VARCHAR(15) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `Phone` VARCHAR(24) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `Fax` VARCHAR(24) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  PRIMARY KEY (`SupplierId`)
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `SimplySmile_dbo`.`States`;
CREATE TABLE `SimplySmile_dbo`.`States` (
  `StateId` BIGINT(19) NOT NULL AUTO_INCREMENT,
  `Abbreviation` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `FullName` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`StateId`)
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `SimplySmile_dbo`.`Shippers`;
CREATE TABLE `SimplySmile_dbo`.`Shippers` (
  `ShipperId` INT(10) NOT NULL,
  `CompanyName` VARCHAR(40) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Phone` VARCHAR(24) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `Reference` VARCHAR(64) NULL,
  PRIMARY KEY (`ShipperId`)
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `SimplySmile_dbo`.`AnotherEntity`;
CREATE TABLE `SimplySmile_dbo`.`AnotherEntity` (
  `Id` INT(10) NOT NULL AUTO_INCREMENT,
  `Output` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `Input` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  PRIMARY KEY (`Id`)
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `SimplySmile_dbo`.`Animal`;
CREATE TABLE `SimplySmile_dbo`.`Animal` (
  `Id` INT(10) NOT NULL AUTO_INCREMENT,
  `Description` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `body_weight` FLOAT(53) NULL,
  `mother_id` INT(10) NULL,
  `father_id` INT(10) NULL,
  `SerialNumber` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `ParentId` INT(10) NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `FK8DED0743B77C69F9` FOREIGN KEY `FK8DED0743B77C69F9` (`ParentId`)
    REFERENCES `SimplySmile_dbo`.`Animal` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK8DED0743CE2F4A5D` FOREIGN KEY `FK8DED0743CE2F4A5D` (`father_id`)
    REFERENCES `SimplySmile_dbo`.`Animal` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK8DED0743F6A91370` FOREIGN KEY `FK8DED0743F6A91370` (`mother_id`)
    REFERENCES `SimplySmile_dbo`.`Animal` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `SimplySmile_dbo`.`Customers`;
CREATE TABLE `SimplySmile_dbo`.`Customers` (
  `CustomerId` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CompanyName` VARCHAR(40) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ContactName` VARCHAR(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `ContactTitle` VARCHAR(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `Address` VARCHAR(60) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `City` VARCHAR(15) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `Region` VARCHAR(15) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `PostalCode` VARCHAR(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `Country` VARCHAR(15) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `Phone` VARCHAR(24) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `Fax` VARCHAR(24) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  PRIMARY KEY (`CustomerId`)
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `SimplySmile_dbo`.`Categories`;
CREATE TABLE `SimplySmile_dbo`.`Categories` (
  `CategoryId` INT(10) NOT NULL,
  `CategoryName` VARCHAR(15) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Description` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  PRIMARY KEY (`CategoryId`)
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `SimplySmile_dbo`.`Employees`;
CREATE TABLE `SimplySmile_dbo`.`Employees` (
  `EmployeeId` INT(10) NOT NULL,
  `LastName` VARCHAR(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `FirstName` VARCHAR(10) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Title` VARCHAR(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `TitleOfCourtesy` VARCHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `BirthDate` DATETIME NULL,
  `HireDate` DATETIME NULL,
  `Address` VARCHAR(60) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `City` VARCHAR(15) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `Region` VARCHAR(15) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `PostalCode` VARCHAR(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `Country` VARCHAR(15) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `HomePhone` VARCHAR(24) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `Extension` VARCHAR(4) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `Notes` VARCHAR(4000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `ReportsTo` INT(10) NULL,
  PRIMARY KEY (`EmployeeId`),
  CONSTRAINT `FKBF2D7FFDE7B80F7` FOREIGN KEY `FKBF2D7FFDE7B80F7` (`ReportsTo`)
    REFERENCES `SimplySmile_dbo`.`Employees` (`EmployeeId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `SimplySmile_dbo`.`Timesheets`;
CREATE TABLE `SimplySmile_dbo`.`Timesheets` (
  `TimesheetId` INT(10) NOT NULL AUTO_INCREMENT,
  `SubmittedDate` DATETIME NULL,
  `Submitted` TINYINT NULL,
  PRIMARY KEY (`TimesheetId`)
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `SimplySmile_dbo`.`TimesheetEntries`;
CREATE TABLE `SimplySmile_dbo`.`TimesheetEntries` (
  `TimesheetEntryId` INT(10) NOT NULL AUTO_INCREMENT,
  `EntryDate` DATETIME NULL,
  `NumberOfHours` INT(10) NULL,
  `Comments` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `TimesheetID` INT(10) NULL,
  PRIMARY KEY (`TimesheetEntryId`),
  CONSTRAINT `FK7E222050C7D0B317` FOREIGN KEY `FK7E222050C7D0B317` (`TimesheetID`)
    REFERENCES `SimplySmile_dbo`.`Timesheets` (`TimesheetId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `SimplySmile_dbo`.`Territories`;
CREATE TABLE `SimplySmile_dbo`.`Territories` (
  `TerritoryId` BIGINT(19) NOT NULL AUTO_INCREMENT,
  `TerritoryDescription` VARCHAR(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `RegionId` BIGINT(19) NOT NULL,
  PRIMARY KEY (`TerritoryId`),
  CONSTRAINT `FKE8C9AC0917D79B7C` FOREIGN KEY `FKE8C9AC0917D79B7C` (`RegionId`)
    REFERENCES `SimplySmile_dbo`.`Region` (`RegionId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `SimplySmile_dbo`.`Orders`;
CREATE TABLE `SimplySmile_dbo`.`Orders` (
  `OrderId` INT(10) NOT NULL,
  `CustomerId` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `EmployeeId` INT(10) NULL,
  `OrderDate` DATETIME NULL,
  `RequiredDate` DATETIME NULL,
  `ShippedDate` DATETIME NULL,
  `ShipVia` INT(10) NULL,
  `Freight` DECIMAL(19, 5) NULL,
  `ShipName` VARCHAR(40) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `ShipAddress` VARCHAR(60) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `ShipCity` VARCHAR(15) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `ShipRegion` VARCHAR(15) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `ShipPostalCode` VARCHAR(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `ShipCountry` VARCHAR(15) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  PRIMARY KEY (`OrderId`),
  CONSTRAINT `FK318A099B476D239C` FOREIGN KEY `FK318A099B476D239C` (`ShipVia`)
    REFERENCES `SimplySmile_dbo`.`Shippers` (`ShipperId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK318A099B5D4A9938` FOREIGN KEY `FK318A099B5D4A9938` (`CustomerId`)
    REFERENCES `SimplySmile_dbo`.`Customers` (`CustomerId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK318A099BBBA2339D` FOREIGN KEY `FK318A099BBBA2339D` (`EmployeeId`)
    REFERENCES `SimplySmile_dbo`.`Employees` (`EmployeeId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `SimplySmile_dbo`.`Mammal`;
CREATE TABLE `SimplySmile_dbo`.`Mammal` (
  `Animal` INT(10) NOT NULL,
  `Pregnant` TINYINT NULL,
  `BirthDate` DATETIME NULL,
  PRIMARY KEY (`Animal`),
  CONSTRAINT `FK180FD9F36676DC17` FOREIGN KEY `FK180FD9F36676DC17` (`Animal`)
    REFERENCES `SimplySmile_dbo`.`Animal` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `SimplySmile_dbo`.`Roles`;
CREATE TABLE `SimplySmile_dbo`.`Roles` (
  `Id` INT(10) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `IsActive` TINYINT NULL,
  `EntityId` INT(10) NULL,
  `ParentId` INT(10) NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `FK1A2E670F36A436` FOREIGN KEY `FK1A2E670F36A436` (`EntityId`)
    REFERENCES `SimplySmile_dbo`.`AnotherEntity` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK1A2E670F9E248253` FOREIGN KEY `FK1A2E670F9E248253` (`ParentId`)
    REFERENCES `SimplySmile_dbo`.`Roles` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `SimplySmile_dbo`.`Reptile`;
CREATE TABLE `SimplySmile_dbo`.`Reptile` (
  `Animal` INT(10) NOT NULL,
  `BodyTemperature` FLOAT(53) NULL,
  PRIMARY KEY (`Animal`),
  CONSTRAINT `FK93D08BCA6676DC17` FOREIGN KEY `FK93D08BCA6676DC17` (`Animal`)
    REFERENCES `SimplySmile_dbo`.`Animal` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `SimplySmile_dbo`.`Patients`;
CREATE TABLE `SimplySmile_dbo`.`Patients` (
  `PatientId` BIGINT(19) NOT NULL AUTO_INCREMENT,
  `Active` TINYINT NOT NULL,
  `PhysicianId` BIGINT(19) NOT NULL,
  PRIMARY KEY (`PatientId`),
  CONSTRAINT `FK668848599D524470` FOREIGN KEY `FK668848599D524470` (`PhysicianId`)
    REFERENCES `SimplySmile_dbo`.`Physicians` (`PhysicianId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `SimplySmile_dbo`.`PatientRecords`;
CREATE TABLE `SimplySmile_dbo`.`PatientRecords` (
  `PatientRecordId` BIGINT(19) NOT NULL AUTO_INCREMENT,
  `Gender` INT(10) NOT NULL,
  `BirthDate` DATETIME NOT NULL,
  `FirstName` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `LastName` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `AddressLine1` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `AddressLine2` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `City` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `StateId` BIGINT(19) NULL,
  `ZipCode` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `PatientId` BIGINT(19) NOT NULL,
  PRIMARY KEY (`PatientRecordId`),
  CONSTRAINT `FK43582E961AB7AECE` FOREIGN KEY `FK43582E961AB7AECE` (`PatientId`)
    REFERENCES `SimplySmile_dbo`.`Patients` (`PatientId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK43582E96A06D1DCD` FOREIGN KEY `FK43582E96A06D1DCD` (`StateId`)
    REFERENCES `SimplySmile_dbo`.`States` (`StateId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `SimplySmile_dbo`.`Lizard`;
CREATE TABLE `SimplySmile_dbo`.`Lizard` (
  `Reptile` INT(10) NOT NULL,
  PRIMARY KEY (`Reptile`),
  CONSTRAINT `FKD8DE3264EBBAEE33` FOREIGN KEY `FKD8DE3264EBBAEE33` (`Reptile`)
    REFERENCES `SimplySmile_dbo`.`Reptile` (`Animal`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `SimplySmile_dbo`.`EmployeeTerritories`;
CREATE TABLE `SimplySmile_dbo`.`EmployeeTerritories` (
  `EmployeeId` INT(10) NOT NULL,
  `TerritoryId` BIGINT(19) NOT NULL,
  PRIMARY KEY (`TerritoryId`, `EmployeeId`),
  CONSTRAINT `FKF4419A39B229473A` FOREIGN KEY `FKF4419A39B229473A` (`TerritoryId`)
    REFERENCES `SimplySmile_dbo`.`Territories` (`TerritoryId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FKF4419A39BBA2339D` FOREIGN KEY `FKF4419A39BBA2339D` (`EmployeeId`)
    REFERENCES `SimplySmile_dbo`.`Employees` (`EmployeeId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `SimplySmile_dbo`.`Dog`;
CREATE TABLE `SimplySmile_dbo`.`Dog` (
  `Mammal` INT(10) NOT NULL,
  PRIMARY KEY (`Mammal`),
  CONSTRAINT `FKAAA2AAA32BA76857` FOREIGN KEY `FKAAA2AAA32BA76857` (`Mammal`)
    REFERENCES `SimplySmile_dbo`.`Mammal` (`Animal`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `SimplySmile_dbo`.`Cat`;
CREATE TABLE `SimplySmile_dbo`.`Cat` (
  `Mammal` INT(10) NOT NULL,
  PRIMARY KEY (`Mammal`),
  CONSTRAINT `FK983303232BA76857` FOREIGN KEY `FK983303232BA76857` (`Mammal`)
    REFERENCES `SimplySmile_dbo`.`Mammal` (`Animal`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `SimplySmile_dbo`.`OrderLines`;
CREATE TABLE `SimplySmile_dbo`.`OrderLines` (
  `OrderLineId` BIGINT(19) NOT NULL AUTO_INCREMENT,
  `OrderId` INT(10) NOT NULL,
  `ProductId` INT(10) NOT NULL,
  `UnitPrice` DECIMAL(19, 5) NOT NULL,
  `Quantity` INT(10) NOT NULL,
  `Discount` DECIMAL(19, 5) NOT NULL,
  PRIMARY KEY (`OrderLineId`),
  CONSTRAINT `FK9D532A8F25C466D` FOREIGN KEY `FK9D532A8F25C466D` (`ProductId`)
    REFERENCES `SimplySmile_dbo`.`Products` (`ProductId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK9D532A8FD0FB5F15` FOREIGN KEY `FK9D532A8FD0FB5F15` (`OrderId`)
    REFERENCES `SimplySmile_dbo`.`Orders` (`OrderId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `SimplySmile_dbo`.`Users`;
CREATE TABLE `SimplySmile_dbo`.`Users` (
  `UserId` INT(10) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(255) NULL,
  `InvalidLoginAttempts` INT(10) NULL,
  `RegisteredAt` DATETIME NULL,
  `LastLoginDate` DATETIME NULL,
  `Enum1` VARCHAR(12) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `Enum2` INT(10) NOT NULL,
  `Features` INT(10) NOT NULL DEFAULT 0,
  `RoleId` INT(10) NULL,
  `Property1` VARCHAR(255) NULL,
  `Property2` VARCHAR(255) NULL,
  `OtherProperty1` VARCHAR(255) NULL,
  PRIMARY KEY (`UserId`),
  CONSTRAINT `FK2C1C7FE5D8C957C7` FOREIGN KEY `FK2C1C7FE5D8C957C7` (`RoleId`)
    REFERENCES `SimplySmile_dbo`.`Roles` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `SimplySmile_dbo`.`TimeSheetUsers`;
CREATE TABLE `SimplySmile_dbo`.`TimeSheetUsers` (
  `TimesheetID` INT(10) NOT NULL,
  `UserId` INT(10) NOT NULL,
  CONSTRAINT `FKA6EEF73795E61DFF` FOREIGN KEY `FKA6EEF73795E61DFF` (`UserId`)
    REFERENCES `SimplySmile_dbo`.`Users` (`UserId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FKA6EEF737C7D0B317` FOREIGN KEY `FKA6EEF737C7D0B317` (`TimesheetID`)
    REFERENCES `SimplySmile_dbo`.`Timesheets` (`TimesheetId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `SimplySmile_dbo`.`Products`;
CREATE TABLE `SimplySmile_dbo`.`Products` (
  `ProductId` INT(10) NOT NULL AUTO_INCREMENT,
  `ProductName` VARCHAR(40) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `SupplierId` INT(10) NULL,
  `CategoryId` INT(10) NULL,
  `QuantityPerUnit` VARCHAR(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `UnitPrice` DECIMAL(19, 5) NULL,
  `UnitsInStock` INT(10) NULL,
  `UnitsOnOrder` INT(10) NULL,
  `ReorderLevel` INT(10) NULL,
  `Discontinued` TINYINT NOT NULL,
  PRIMARY KEY (`ProductId`),
  CONSTRAINT `FK4A7FD86A7E57CC2E` FOREIGN KEY `FK4A7FD86A7E57CC2E` (`SupplierId`)
    REFERENCES `SimplySmile_dbo`.`Suppliers` (`SupplierId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK4A7FD86A4A4379C2` FOREIGN KEY `FK4A7FD86A4A4379C2` (`CategoryId`)
    REFERENCES `SimplySmile_dbo`.`Categories` (`CategoryId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `SimplySmile_dbo`.`Physicians`;
CREATE TABLE `SimplySmile_dbo`.`Physicians` (
  `PhysicianId` BIGINT(19) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`PhysicianId`)
)
ENGINE = INNODB;



SET FOREIGN_KEY_CHECKS = 1;

-- ----------------------------------------------------------------------
-- EOF

