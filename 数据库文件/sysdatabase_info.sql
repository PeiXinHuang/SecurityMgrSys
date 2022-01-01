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
) ENGINE=InnoDB AUTO_INCREMENT=57 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `info`
--

LOCK TABLES `info` WRITE;
/*!40000 ALTER TABLE `info` DISABLE KEYS */;
INSERT INTO `info` VALUES (37,'00001','00002','今年安检业务结果通知','今年安检业务完成效率达到98%,十分合格,大家继续努力'),(38,'00001','00003','今年安检业务结果通知','今年安检业务完成效率达到98%,十分合格,大家继续努力'),(39,'00001','00004','今年安检业务结果通知','今年安检业务完成效率达到98%,十分合格,大家继续努力'),(40,'00001','00005','今年安检业务结果通知','今年安检业务完成效率达到98%,十分合格,大家继续努力'),(41,'00001','00006','今年安检业务结果通知','今年安检业务完成效率达到98%,十分合格,大家继续努力'),(42,'00001','00007','今年安检业务结果通知','今年安检业务完成效率达到98%,十分合格,大家继续努力'),(43,'00001','00008','今年安检业务结果通知','今年安检业务完成效率达到98%,十分合格,大家继续努力'),(44,'00001','00009','今年安检业务结果通知','今年安检业务完成效率达到98%,十分合格,大家继续努力'),(45,'00001','00002','安检业务通知','你的安检报表没有注明好时间，修改好重新提交一下'),(46,'00001','00007','安检业务通知','你的安检报表没有注明好时间，修改好重新提交一下'),(47,'00001','00009','安检业务通知','你的安检报表没有注明好时间，修改好重新提交一下'),(48,'00002','00001','安检业务请假','鹤岗地铁安检因为身体不适，请假不去了'),(49,'00002','00003','账号异常','我的账号登录异常，帮我改一下密码，谢谢'),(50,'00003','00001','系统维护通知','2022年1月5日\n系统更新维护一天，照成不便请大家见谅'),(51,'00003','00002','系统维护通知','2022年1月5日\n系统更新维护一天，照成不便请大家见谅'),(52,'00003','00004','系统维护通知','2022年1月5日\n系统更新维护一天，照成不便请大家见谅'),(53,'00003','00005','系统维护通知','2022年1月5日\n系统更新维护一天，照成不便请大家见谅'),(54,'00003','00006','系统维护通知','2022年1月5日\n系统更新维护一天，照成不便请大家见谅'),(55,'00003','00007','系统维护通知','2022年1月5日\n系统更新维护一天，照成不便请大家见谅'),(56,'00003','00009','系统维护通知','2022年1月5日\n系统更新维护一天，照成不便请大家见谅');
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

-- Dump completed on 2022-01-01 14:01:45
