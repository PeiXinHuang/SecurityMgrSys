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
-- Table structure for table `info`
--

DROP TABLE IF EXISTS `info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `info` (
  `idInfo` int NOT NULL AUTO_INCREMENT,
  `sendId` varchar(45) COLLATE utf8_bin NOT NULL,
  `receiveId` varchar(45) COLLATE utf8_bin NOT NULL,
  `infoTitle` varchar(45) COLLATE utf8_bin NOT NULL,
  `infoContent` varchar(200) COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`idInfo`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `info`
--

LOCK TABLES `info` WRITE;
/*!40000 ALTER TABLE `info` DISABLE KEYS */;
INSERT INTO `info` VALUES (7,'00003','00003','消息标题','HELLO'),(8,'00003','00004','消息标题','HELLO'),(9,'00003','00007','消息标题','HELLO'),(10,'00003','00008','消息标题','HELLO'),(11,'00003','00012','消息标题','HELLO'),(12,'00003','00013','消息标题','HELLO'),(13,'00003','00003','劳动通知','你们都被开除了'),(14,'00003','00004','劳动通知','你们都被开除了'),(15,'00003','00007','劳动通知','你们都被开除了'),(16,'00003','00008','劳动通知','你们都被开除了'),(17,'00003','00012','劳动通知','你们都被开除了'),(18,'00003','00013','劳动通知','你们都被开除了'),(19,'00003','00003','你好','HELLO'),(20,'00003','00004','你好','HELLO'),(21,'00003','00004','这是标题','我了个去'),(22,'00003','00007','这是标题','我了个去'),(23,'00003','00008','这是标题','我了个去'),(24,'00003','00012','这是标题','我了个去'),(25,'00003','00013','这是标题','我了个去'),(26,'00003','00012','标题','内容是'),(27,'00003','00004','这是新标题','你做得很好'),(28,'00003','00007','这是新标题','你做得很好'),(29,'00014','00003','系统更新通知','明天上午系统更新，不用来上班了'),(30,'00014','00004','系统更新通知','明天上午系统更新，不用来上班了'),(31,'00014','00007','系统更新通知','明天上午系统更新，不用来上班了'),(32,'00014','00008','系统更新通知','明天上午系统更新，不用来上班了'),(33,'00014','00012','系统更新通知','明天上午系统更新，不用来上班了'),(34,'00014','00013','系统更新通知','明天上午系统更新，不用来上班了'),(35,'00014','00004','系统维护通知','今天系统维护，记得下午测试一下'),(36,'00014','00013','系统维护通知','今天系统维护，记得下午测试一下');
/*!40000 ALTER TABLE `info` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-12-12 19:10:10
