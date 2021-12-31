-- MySQL dump 10.13  Distrib 8.0.21, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: sysdatabase
-- ------------------------------------------------------
-- Server version	8.0.21

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tools`
--

DROP TABLE IF EXISTS `tools`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tools` (
  `tId` int NOT NULL AUTO_INCREMENT,
  `tName` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `tType` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `tStatus` int NOT NULL DEFAULT '0',
  `bDate` date DEFAULT NULL,
  `rDate` date DEFAULT NULL,
  `uName` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `uId` int DEFAULT NULL,
  PRIMARY KEY (`tId`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tools`
--

LOCK TABLES `tools` WRITE;
/*!40000 ALTER TABLE `tools` DISABLE KEYS */;
INSERT INTO `tools` VALUES (1,'安检门','大型',1,NULL,NULL,NULL,NULL),(2,'安检门','大型',0,NULL,NULL,NULL,NULL),(3,'金属探测仪','小型',2,'2021-12-31','2021-12-31','沛鑫',3),(4,'金属探测仪','小型',1,'2021-12-31',NULL,'沛鑫',3),(5,'金属探测仪','小型',0,NULL,NULL,NULL,NULL),(6,'金属探测仪','小型',1,'2021-12-30',NULL,'沛鑫',3),(7,'金属探测仪','小型',0,NULL,'2021-12-30',NULL,NULL),(8,'X光检测机','大型',0,NULL,NULL,NULL,NULL),(9,'X光检测机','大型',2,'2021-12-30','2021-12-31','沛鑫',3),(10,'X光检测机','大型',1,'2021-12-30',NULL,'沛鑫',3),(11,'X光检测机','大型',0,'2021-12-30','2021-12-30',NULL,NULL),(12,'安检门','大型',0,NULL,NULL,NULL,NULL),(13,'安检门','大型',2,NULL,'2021-12-30',NULL,NULL),(14,'安检门','大型',2,'2021-12-30','2021-12-31',NULL,NULL),(15,'安检门','大型',1,'2021-12-31',NULL,'沛鑫',3),(16,'铁铲','中型',0,NULL,NULL,NULL,NULL),(17,'铁铲','中型',1,'2021-12-31',NULL,'沛鑫',3),(18,'铁铲','中型',0,NULL,NULL,NULL,NULL),(19,'铁铲','中型',0,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `tools` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-12-31 21:00:33
