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
-- Table structure for table `business`
--

DROP TABLE IF EXISTS `business`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `business` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(45) COLLATE utf8_bin NOT NULL,
  `content` varchar(1000) COLLATE utf8_bin NOT NULL,
  `adminUserId` varchar(45) COLLATE utf8_bin NOT NULL,
  `memberUserId` varchar(250) COLLATE utf8_bin NOT NULL,
  `tools` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `pdfName` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `state` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `business`
--

LOCK TABLES `business` WRITE;
/*!40000 ALTER TABLE `business` DISABLE KEYS */;
INSERT INTO `business` VALUES (11,'鹤岗地铁安检','2022年1月15日\n鹤岗参与地铁安检，维护现场秩序，测量乘客体温\n需要工具 测温计：5个 金属探测仪：4个','00001','00002',NULL,'11.pdf',2),(12,'鹤岗地铁安检','2022年1月15日\n鹤岗参与地铁安检，维护现场秩序，测量乘客体温\n需要工具 测温计：5个 金属探测仪：4个','00001','00004',NULL,NULL,0),(13,'鹤岗地铁安检','2022年1月15日\n鹤岗参与地铁安检，维护现场秩序，测量乘客体温\n需要工具 测温计：5个 金属探测仪：4个','00001','00005',NULL,NULL,0),(14,'鹤岗地铁安检','2022年1月15日\n鹤岗参与地铁安检，维护现场秩序，测量乘客体温\n需要工具 测温计：5个 金属探测仪：4个','00001','00006',NULL,NULL,0),(15,'鹤岗地铁安检','2022年1月15日\n鹤岗参与地铁安检，维护现场秩序，测量乘客体温\n需要工具 测温计：5个 金属探测仪：4个','00001','00007',NULL,NULL,0),(16,'鹤岗地铁安检','2022年1月15日\n鹤岗参与地铁安检，维护现场秩序，测量乘客体温\n需要工具 测温计：5个 金属探测仪：4个','00001','00009',NULL,NULL,0),(17,'广州南高铁安检','2022年1月12日\n广州南参与高铁安检，维护现场秩序\n需要工具 X光检测机(大型): 5个  安检门：10个 金属探测仪：10个','00001','00004',NULL,NULL,0),(18,'广州南高铁安检','2022年1月12日\n广州南参与高铁安检，维护现场秩序\n需要工具 X光检测机(大型): 5个  安检门：10个 金属探测仪：10个','00001','00002',NULL,'18.pdf',1),(19,'广州南高铁安检','2022年1月12日\n广州南参与高铁安检，维护现场秩序\n需要工具 X光检测机(大型): 5个  安检门：10个 金属探测仪：10个','00001','00005',NULL,NULL,0),(20,'广州南高铁安检','2022年1月12日\n广州南参与高铁安检，维护现场秩序\n需要工具 X光检测机(大型): 5个  安检门：10个 金属探测仪：10个','00001','00006',NULL,NULL,0),(21,'区庄地铁安检','2022年2月19日\n参与地铁安检，维护现场秩序\n需要工具 测温计：5个 金属探测仪：10个','00001','00002',NULL,'21.pdf',1),(22,'区庄地铁安检','2022年2月19日\n参与地铁安检，维护现场秩序\n需要工具 测温计：5个 金属探测仪：10个','00001','00004',NULL,NULL,0),(23,'区庄地铁安检','2022年2月19日\n参与地铁安检，维护现场秩序\n需要工具 测温计：5个 金属探测仪：10个','00001','00005',NULL,NULL,0),(24,'区庄地铁安检','2022年2月19日\n参与地铁安检，维护现场秩序\n需要工具 测温计：5个 金属探测仪：10个','00001','00006',NULL,NULL,0),(25,'区庄地铁安检','2022年2月19日\n参与地铁安检，维护现场秩序\n需要工具 测温计：5个 金属探测仪：10个','00001','00007',NULL,NULL,0),(26,'区庄地铁安检','2022年2月19日\n参与地铁安检，维护现场秩序\n需要工具 测温计：5个 金属探测仪：10个','00001','00009',NULL,NULL,0),(27,'车陂地铁安检','2022年3月1日\n参与车陂地铁安检，维护现场秩序\n需要工具：测温计：10个','00001','00002',NULL,'27.pdf',3),(28,'车陂地铁安检','2022年3月1日\n参与车陂地铁安检，维护现场秩序\n需要工具：测温计：10个','00001','00004',NULL,NULL,0),(29,'车陂地铁安检','2022年3月1日\n参与车陂地铁安检，维护现场秩序\n需要工具：测温计：10个','00001','00005',NULL,NULL,0),(30,'车陂地铁安检','2022年3月1日\n参与车陂地铁安检，维护现场秩序\n需要工具：测温计：10个','00001','00006',NULL,NULL,0),(31,'车陂地铁安检','2022年3月1日\n参与车陂地铁安检，维护现场秩序\n需要工具：测温计：10个','00001','00007',NULL,NULL,0),(32,'车陂地铁安检','2022年3月1日\n参与车陂地铁安检，维护现场秩序\n需要工具：测温计：10个','00001','00009',NULL,NULL,0);
/*!40000 ALTER TABLE `business` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-01-01 14:01:45
