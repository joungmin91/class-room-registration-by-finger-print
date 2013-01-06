CREATE DATABASE  IF NOT EXISTS `kudb` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `kudb`;
-- MySQL dump 10.13  Distrib 5.5.16, for Win32 (x86)
--
-- Host: localhost    Database: kudb
-- ------------------------------------------------------
-- Server version	5.5.20-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `score_rate_type`
--

DROP TABLE IF EXISTS `score_rate_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `score_rate_type` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tech_id` int(11) NOT NULL,
  `type` varchar(10) NOT NULL,
  `A` varchar(10) DEFAULT NULL,
  `BP` varchar(10) DEFAULT NULL,
  `B` varchar(10) DEFAULT NULL,
  `CP` varchar(10) DEFAULT NULL,
  `C` varchar(10) DEFAULT NULL,
  `DP` varchar(10) DEFAULT NULL,
  `D` varchar(10) DEFAULT NULL,
  `F` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `score_rate_type`
--

LOCK TABLES `score_rate_type` WRITE;
/*!40000 ALTER TABLE `score_rate_type` DISABLE KEYS */;
INSERT INTO `score_rate_type` VALUES (1,1,'grade','77','66','55','44','33','22','11','0'),(5,2,'grade','80','75','70','65','60','55','50','0');
/*!40000 ALTER TABLE `score_rate_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `checkin`
--

DROP TABLE IF EXISTS `checkin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `checkin` (
  `sub_id` int(11) NOT NULL,
  `std_id` varchar(25) NOT NULL,
  `chkin_year` varchar(10) NOT NULL,
  `chkin_date` varchar(45) NOT NULL,
  `chkin_status` varchar(10) NOT NULL DEFAULT 'normal',
  PRIMARY KEY (`sub_id`,`std_id`,`chkin_year`,`chkin_date`),
  KEY `sub_id` (`sub_id`),
  KEY `std_id` (`std_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `checkin`
--

LOCK TABLES `checkin` WRITE;
/*!40000 ALTER TABLE `checkin` DISABLE KEYS */;
INSERT INTO `checkin` VALUES (4,'51370039','2555','12/31/2012','normal'),(4,'51370211','2555','12/31/2012','late'),(4,'5330200041','2555','12/31/2012','late'),(4,'5330200105','2555','12/31/2012','normal'),(4,'5330200121','2555','12/31/2012','late');
/*!40000 ALTER TABLE `checkin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `registration`
--

DROP TABLE IF EXISTS `registration`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `registration` (
  `reg_id` int(11) NOT NULL AUTO_INCREMENT,
  `sub_id` int(11) NOT NULL,
  `std_id` varchar(25) NOT NULL,
  `year` varchar(10) NOT NULL,
  PRIMARY KEY (`reg_id`,`sub_id`,`std_id`,`year`),
  KEY `sub_id` (`sub_id`),
  KEY `std_id` (`std_id`),
  CONSTRAINT `std_id` FOREIGN KEY (`std_id`) REFERENCES `student` (`std_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=277 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `registration`
--

LOCK TABLES `registration` WRITE;
/*!40000 ALTER TABLE `registration` DISABLE KEYS */;
INSERT INTO `registration` VALUES (193,4,'51370211','2555'),(194,4,'5330200041','2555'),(195,4,'5330200105','2555'),(196,4,'5330200121','2555'),(197,4,'5330200164','2555'),(198,4,'5330200245','2555'),(199,4,'5330200288','2555'),(200,4,'5330200300','2555'),(201,4,'5330200393','2555'),(202,4,'5330200652','2555'),(203,4,'5330200709','2555'),(204,4,'5330200903','2555'),(205,4,'5330201004','2555'),(206,4,'5330250013','2555'),(207,4,'5330250021','2555'),(208,4,'5330250030','2555'),(209,4,'5330250048','2555'),(210,4,'5330250056','2555'),(211,4,'5330250064','2555'),(212,4,'5330250072','2555'),(213,4,'5330250102','2555'),(214,4,'5330250111','2555'),(215,4,'5330250137','2555'),(216,4,'5330250145','2555'),(217,4,'5330250153','2555'),(218,4,'5330250161','2555'),(219,4,'5330250196','2555'),(220,4,'5330250200','2555'),(221,4,'5330250218','2555'),(222,4,'5330250226','2555'),(223,4,'5330250234','2555'),(224,4,'5330250242','2555'),(225,4,'5330250251','2555'),(226,4,'5330250277','2555'),(227,4,'5330250285','2555'),(228,4,'5330250315','2555'),(229,4,'5330250331','2555'),(230,4,'5330250358','2555'),(231,4,'5330250374','2555'),(232,4,'5330250412','2555'),(233,4,'5330250439','2555'),(234,4,'5330250455','2555'),(235,4,'5330250463','2555'),(236,4,'5330250471','2555'),(237,4,'5330250480','2555'),(238,4,'5330250498','2555'),(239,4,'5330250587','2555'),(240,4,'5330250650','2555'),(241,4,'5330250731','2555'),(242,4,'5330250790','2555'),(243,4,'5330250811','2555'),(244,4,'5330250889','2555'),(245,5,'5230250127','2555'),(246,5,'5230250135','2555'),(247,5,'5230250143','2555'),(248,5,'5230250178','2555'),(249,5,'5230250186','2555'),(250,5,'5230250224','2555'),(251,5,'5230250259','2555'),(252,5,'5230250291','2555'),(253,5,'5230250313','2555'),(254,5,'5230250348','2555'),(255,5,'5230250372','2555'),(256,5,'5230250381','2555'),(257,5,'5230250399','2555'),(258,5,'5230250437','2555'),(259,5,'5230250445','2555'),(260,5,'5230250496','2555'),(261,5,'5230250500','2555'),(262,5,'5230250518','2555'),(263,5,'5230250542','2555'),(264,5,'5230250551','2555'),(265,5,'5230250607','2555'),(266,5,'5230250615','2555'),(267,5,'5230250623','2555'),(268,5,'5230250631','2555'),(269,5,'5230250798','2555'),(270,5,'5230250810','2555'),(271,5,'5230250844','2555'),(272,5,'5230250861','2555'),(273,5,'5230250879','2555'),(274,5,'5230250925','2555'),(275,5,'5230251174','2555'),(276,5,'5230251212','2555');
/*!40000 ALTER TABLE `registration` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `score_type`
--

DROP TABLE IF EXISTS `score_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `score_type` (
  `score_type_id` int(11) NOT NULL AUTO_INCREMENT,
  `score_type` varchar(100) NOT NULL,
  PRIMARY KEY (`score_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `score_type`
--

LOCK TABLES `score_type` WRITE;
/*!40000 ALTER TABLE `score_type` DISABLE KEYS */;
INSERT INTO `score_type` VALUES (1,'กลางภาค'),(2,'ปลายภาค'),(3,'จิตพิสัย'),(4,'คะแนนเก็บ 1'),(5,'คะแนนเก็บ 2'),(6,'คะแนนเก็บ 3'),(7,'คะแนนเก็บ 4'),(8,'คะแนนเก็บ 5');
/*!40000 ALTER TABLE `score_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `score`
--

DROP TABLE IF EXISTS `score`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `score` (
  `score_id` int(11) NOT NULL AUTO_INCREMENT,
  `score_point` int(11) NOT NULL DEFAULT '0',
  `score_type` int(11) NOT NULL,
  `score_description` varchar(100) DEFAULT NULL,
  `reg_id` int(11) NOT NULL,
  PRIMARY KEY (`score_id`),
  KEY `reg_id` (`reg_id`),
  KEY `score_type` (`score_type`),
  CONSTRAINT `reg_id` FOREIGN KEY (`reg_id`) REFERENCES `registration` (`reg_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=681 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `score`
--

LOCK TABLES `score` WRITE;
/*!40000 ALTER TABLE `score` DISABLE KEYS */;
INSERT INTO `score` VALUES (9,20,1,'',193),(10,30,2,'',193),(11,0,3,'',193),(12,0,4,'',193),(13,0,5,'',193),(14,0,6,'',193),(15,0,7,'',193),(16,0,8,'',193),(17,10,1,'',245),(18,10,2,'',245),(19,10,3,'',245),(20,0,4,'',245),(21,0,5,'',245),(22,0,6,'',245),(23,0,7,'',245),(24,0,8,'',245),(25,30,1,NULL,194),(26,0,2,NULL,194),(27,0,3,NULL,194),(28,0,4,NULL,194),(29,0,5,NULL,194),(30,0,6,NULL,194),(31,0,7,NULL,194),(32,0,8,NULL,194),(33,10,1,NULL,195),(34,50,2,NULL,195),(35,9,3,NULL,195),(36,0,4,NULL,195),(37,0,5,NULL,195),(38,0,6,NULL,195),(39,0,7,NULL,195),(40,0,8,NULL,195),(41,25,1,NULL,196),(42,25,2,NULL,196),(43,10,3,NULL,196),(44,15,4,NULL,196),(45,0,5,NULL,196),(46,0,6,NULL,196),(47,0,7,NULL,196),(48,0,8,NULL,196),(49,0,1,NULL,197),(50,0,2,NULL,197),(51,0,3,NULL,197),(52,0,4,NULL,197),(53,0,5,NULL,197),(54,0,6,NULL,197),(55,0,7,NULL,197),(56,0,8,NULL,197),(57,0,1,NULL,198),(58,0,2,NULL,198),(59,0,3,NULL,198),(60,0,4,NULL,198),(61,0,5,NULL,198),(62,0,6,NULL,198),(63,0,7,NULL,198),(64,0,8,NULL,198),(65,0,1,NULL,199),(66,0,2,NULL,199),(67,0,3,NULL,199),(68,0,4,NULL,199),(69,0,5,NULL,199),(70,0,6,NULL,199),(71,0,7,NULL,199),(72,0,8,NULL,199),(73,0,1,NULL,200),(74,0,2,NULL,200),(75,0,3,NULL,200),(76,0,4,NULL,200),(77,0,5,NULL,200),(78,0,6,NULL,200),(79,0,7,NULL,200),(80,0,8,NULL,200),(81,0,1,NULL,201),(82,0,2,NULL,201),(83,0,3,NULL,201),(84,0,4,NULL,201),(85,0,5,NULL,201),(86,0,6,NULL,201),(87,0,7,NULL,201),(88,0,8,NULL,201),(89,0,1,NULL,202),(90,0,2,NULL,202),(91,0,3,NULL,202),(92,0,4,NULL,202),(93,0,5,NULL,202),(94,0,6,NULL,202),(95,0,7,NULL,202),(96,0,8,NULL,202),(97,0,1,NULL,203),(98,0,2,NULL,203),(99,0,3,NULL,203),(100,0,4,NULL,203),(101,0,5,NULL,203),(102,0,6,NULL,203),(103,0,7,NULL,203),(104,0,8,NULL,203),(105,0,1,NULL,204),(106,0,2,NULL,204),(107,0,3,NULL,204),(108,0,4,NULL,204),(109,0,5,NULL,204),(110,0,6,NULL,204),(111,0,7,NULL,204),(112,0,8,NULL,204),(113,0,1,NULL,205),(114,0,2,NULL,205),(115,0,3,NULL,205),(116,0,4,NULL,205),(117,0,5,NULL,205),(118,0,6,NULL,205),(119,0,7,NULL,205),(120,0,8,NULL,205),(121,0,1,NULL,206),(122,0,2,NULL,206),(123,0,3,NULL,206),(124,0,4,NULL,206),(125,0,5,NULL,206),(126,0,6,NULL,206),(127,0,7,NULL,206),(128,0,8,NULL,206),(129,0,1,NULL,207),(130,0,2,NULL,207),(131,0,3,NULL,207),(132,0,4,NULL,207),(133,0,5,NULL,207),(134,0,6,NULL,207),(135,0,7,NULL,207),(136,0,8,NULL,207),(137,0,1,NULL,208),(138,0,2,NULL,208),(139,0,3,NULL,208),(140,0,4,NULL,208),(141,0,5,NULL,208),(142,0,6,NULL,208),(143,0,7,NULL,208),(144,0,8,NULL,208),(145,0,1,NULL,209),(146,0,2,NULL,209),(147,0,3,NULL,209),(148,0,4,NULL,209),(149,0,5,NULL,209),(150,0,6,NULL,209),(151,0,7,NULL,209),(152,0,8,NULL,209),(153,0,1,NULL,210),(154,0,2,NULL,210),(155,0,3,NULL,210),(156,0,4,NULL,210),(157,0,5,NULL,210),(158,0,6,NULL,210),(159,0,7,NULL,210),(160,0,8,NULL,210),(161,0,1,NULL,211),(162,0,2,NULL,211),(163,0,3,NULL,211),(164,0,4,NULL,211),(165,0,5,NULL,211),(166,0,6,NULL,211),(167,0,7,NULL,211),(168,0,8,NULL,211),(169,0,1,NULL,212),(170,0,2,NULL,212),(171,0,3,NULL,212),(172,0,4,NULL,212),(173,0,5,NULL,212),(174,0,6,NULL,212),(175,0,7,NULL,212),(176,0,8,NULL,212),(177,0,1,NULL,213),(178,0,2,NULL,213),(179,0,3,NULL,213),(180,0,4,NULL,213),(181,0,5,NULL,213),(182,0,6,NULL,213),(183,0,7,NULL,213),(184,0,8,NULL,213),(185,0,1,NULL,214),(186,0,2,NULL,214),(187,0,3,NULL,214),(188,0,4,NULL,214),(189,0,5,NULL,214),(190,0,6,NULL,214),(191,0,7,NULL,214),(192,0,8,NULL,214),(193,0,1,NULL,215),(194,0,2,NULL,215),(195,0,3,NULL,215),(196,0,4,NULL,215),(197,0,5,NULL,215),(198,0,6,NULL,215),(199,0,7,NULL,215),(200,0,8,NULL,215),(201,0,1,NULL,216),(202,0,2,NULL,216),(203,0,3,NULL,216),(204,0,4,NULL,216),(205,0,5,NULL,216),(206,0,6,NULL,216),(207,0,7,NULL,216),(208,0,8,NULL,216),(209,0,1,NULL,217),(210,0,2,NULL,217),(211,0,3,NULL,217),(212,0,4,NULL,217),(213,0,5,NULL,217),(214,0,6,NULL,217),(215,0,7,NULL,217),(216,0,8,NULL,217),(217,0,1,NULL,218),(218,0,2,NULL,218),(219,0,3,NULL,218),(220,0,4,NULL,218),(221,0,5,NULL,218),(222,0,6,NULL,218),(223,0,7,NULL,218),(224,0,8,NULL,218),(225,0,1,NULL,219),(226,0,2,NULL,219),(227,0,3,NULL,219),(228,0,4,NULL,219),(229,0,5,NULL,219),(230,0,6,NULL,219),(231,0,7,NULL,219),(232,0,8,NULL,219),(233,0,1,NULL,220),(234,0,2,NULL,220),(235,0,3,NULL,220),(236,0,4,NULL,220),(237,0,5,NULL,220),(238,0,6,NULL,220),(239,0,7,NULL,220),(240,0,8,NULL,220),(241,0,1,NULL,221),(242,0,2,NULL,221),(243,0,3,NULL,221),(244,0,4,NULL,221),(245,0,5,NULL,221),(246,0,6,NULL,221),(247,0,7,NULL,221),(248,0,8,NULL,221),(249,0,1,NULL,222),(250,0,2,NULL,222),(251,0,3,NULL,222),(252,0,4,NULL,222),(253,0,5,NULL,222),(254,0,6,NULL,222),(255,0,7,NULL,222),(256,0,8,NULL,222),(257,0,1,NULL,223),(258,0,2,NULL,223),(259,0,3,NULL,223),(260,0,4,NULL,223),(261,0,5,NULL,223),(262,0,6,NULL,223),(263,0,7,NULL,223),(264,0,8,NULL,223),(265,0,1,NULL,224),(266,0,2,NULL,224),(267,0,3,NULL,224),(268,0,4,NULL,224),(269,0,5,NULL,224),(270,0,6,NULL,224),(271,0,7,NULL,224),(272,0,8,NULL,224),(273,0,1,NULL,225),(274,0,2,NULL,225),(275,0,3,NULL,225),(276,0,4,NULL,225),(277,0,5,NULL,225),(278,0,6,NULL,225),(279,0,7,NULL,225),(280,0,8,NULL,225),(281,0,1,NULL,226),(282,0,2,NULL,226),(283,0,3,NULL,226),(284,0,4,NULL,226),(285,0,5,NULL,226),(286,0,6,NULL,226),(287,0,7,NULL,226),(288,0,8,NULL,226),(289,0,1,NULL,227),(290,0,2,NULL,227),(291,0,3,NULL,227),(292,0,4,NULL,227),(293,0,5,NULL,227),(294,0,6,NULL,227),(295,0,7,NULL,227),(296,0,8,NULL,227),(297,0,1,NULL,228),(298,0,2,NULL,228),(299,0,3,NULL,228),(300,0,4,NULL,228),(301,0,5,NULL,228),(302,0,6,NULL,228),(303,0,7,NULL,228),(304,0,8,NULL,228),(305,0,1,NULL,229),(306,0,2,NULL,229),(307,0,3,NULL,229),(308,0,4,NULL,229),(309,0,5,NULL,229),(310,0,6,NULL,229),(311,0,7,NULL,229),(312,0,8,NULL,229),(313,0,1,NULL,230),(314,0,2,NULL,230),(315,0,3,NULL,230),(316,0,4,NULL,230),(317,0,5,NULL,230),(318,0,6,NULL,230),(319,0,7,NULL,230),(320,0,8,NULL,230),(321,0,1,NULL,231),(322,0,2,NULL,231),(323,0,3,NULL,231),(324,0,4,NULL,231),(325,0,5,NULL,231),(326,0,6,NULL,231),(327,0,7,NULL,231),(328,0,8,NULL,231),(329,0,1,NULL,232),(330,0,2,NULL,232),(331,0,3,NULL,232),(332,0,4,NULL,232),(333,0,5,NULL,232),(334,0,6,NULL,232),(335,0,7,NULL,232),(336,0,8,NULL,232),(337,0,1,NULL,233),(338,0,2,NULL,233),(339,0,3,NULL,233),(340,0,4,NULL,233),(341,0,5,NULL,233),(342,0,6,NULL,233),(343,0,7,NULL,233),(344,0,8,NULL,233),(345,0,1,NULL,234),(346,0,2,NULL,234),(347,0,3,NULL,234),(348,0,4,NULL,234),(349,0,5,NULL,234),(350,0,6,NULL,234),(351,0,7,NULL,234),(352,0,8,NULL,234),(353,0,1,NULL,235),(354,0,2,NULL,235),(355,0,3,NULL,235),(356,0,4,NULL,235),(357,0,5,NULL,235),(358,0,6,NULL,235),(359,0,7,NULL,235),(360,0,8,NULL,235),(361,0,1,NULL,236),(362,0,2,NULL,236),(363,0,3,NULL,236),(364,0,4,NULL,236),(365,0,5,NULL,236),(366,0,6,NULL,236),(367,0,7,NULL,236),(368,0,8,NULL,236),(369,0,1,NULL,237),(370,0,2,NULL,237),(371,0,3,NULL,237),(372,0,4,NULL,237),(373,0,5,NULL,237),(374,0,6,NULL,237),(375,0,7,NULL,237),(376,0,8,NULL,237),(377,0,1,NULL,238),(378,0,2,NULL,238),(379,0,3,NULL,238),(380,0,4,NULL,238),(381,0,5,NULL,238),(382,0,6,NULL,238),(383,0,7,NULL,238),(384,0,8,NULL,238),(385,0,1,NULL,239),(386,0,2,NULL,239),(387,0,3,NULL,239),(388,0,4,NULL,239),(389,0,5,NULL,239),(390,0,6,NULL,239),(391,0,7,NULL,239),(392,0,8,NULL,239),(393,0,1,NULL,240),(394,0,2,NULL,240),(395,0,3,NULL,240),(396,0,4,NULL,240),(397,0,5,NULL,240),(398,0,6,NULL,240),(399,0,7,NULL,240),(400,0,8,NULL,240),(401,0,1,NULL,241),(402,0,2,NULL,241),(403,0,3,NULL,241),(404,0,4,NULL,241),(405,0,5,NULL,241),(406,0,6,NULL,241),(407,0,7,NULL,241),(408,0,8,NULL,241),(409,0,1,NULL,242),(410,0,2,NULL,242),(411,0,3,NULL,242),(412,0,4,NULL,242),(413,0,5,NULL,242),(414,0,6,NULL,242),(415,0,7,NULL,242),(416,0,8,NULL,242),(417,0,1,NULL,243),(418,0,2,NULL,243),(419,0,3,NULL,243),(420,0,4,NULL,243),(421,0,5,NULL,243),(422,0,6,NULL,243),(423,0,7,NULL,243),(424,0,8,NULL,243),(425,0,1,NULL,244),(426,0,2,NULL,244),(427,0,3,NULL,244),(428,0,4,NULL,244),(429,0,5,NULL,244),(430,0,6,NULL,244),(431,0,7,NULL,244),(432,0,8,NULL,244),(433,50,1,NULL,246),(434,0,2,NULL,246),(435,0,3,NULL,246),(436,0,4,NULL,246),(437,0,5,NULL,246),(438,0,6,NULL,246),(439,0,7,NULL,246),(440,0,8,NULL,246),(441,50,1,NULL,247),(442,0,2,NULL,247),(443,0,3,NULL,247),(444,0,4,NULL,247),(445,0,5,NULL,247),(446,0,6,NULL,247),(447,0,7,NULL,247),(448,0,8,NULL,247),(449,0,1,NULL,248),(450,0,2,NULL,248),(451,0,3,NULL,248),(452,0,4,NULL,248),(453,0,5,NULL,248),(454,0,6,NULL,248),(455,0,7,NULL,248),(456,0,8,NULL,248),(457,0,1,NULL,249),(458,0,2,NULL,249),(459,0,3,NULL,249),(460,0,4,NULL,249),(461,0,5,NULL,249),(462,0,6,NULL,249),(463,0,7,NULL,249),(464,0,8,NULL,249),(465,0,1,NULL,250),(466,0,2,NULL,250),(467,0,3,NULL,250),(468,0,4,NULL,250),(469,0,5,NULL,250),(470,0,6,NULL,250),(471,0,7,NULL,250),(472,0,8,NULL,250),(473,0,1,NULL,251),(474,0,2,NULL,251),(475,0,3,NULL,251),(476,0,4,NULL,251),(477,0,5,NULL,251),(478,0,6,NULL,251),(479,0,7,NULL,251),(480,0,8,NULL,251),(481,0,1,NULL,252),(482,0,2,NULL,252),(483,0,3,NULL,252),(484,0,4,NULL,252),(485,0,5,NULL,252),(486,0,6,NULL,252),(487,0,7,NULL,252),(488,0,8,NULL,252),(489,0,1,NULL,253),(490,0,2,NULL,253),(491,0,3,NULL,253),(492,0,4,NULL,253),(493,0,5,NULL,253),(494,0,6,NULL,253),(495,0,7,NULL,253),(496,0,8,NULL,253),(497,0,1,NULL,254),(498,0,2,NULL,254),(499,0,3,NULL,254),(500,0,4,NULL,254),(501,0,5,NULL,254),(502,0,6,NULL,254),(503,0,7,NULL,254),(504,0,8,NULL,254),(505,0,1,NULL,255),(506,0,2,NULL,255),(507,0,3,NULL,255),(508,0,4,NULL,255),(509,0,5,NULL,255),(510,0,6,NULL,255),(511,0,7,NULL,255),(512,0,8,NULL,255),(513,0,1,NULL,256),(514,0,2,NULL,256),(515,0,3,NULL,256),(516,0,4,NULL,256),(517,0,5,NULL,256),(518,0,6,NULL,256),(519,0,7,NULL,256),(520,0,8,NULL,256),(521,0,1,NULL,257),(522,0,2,NULL,257),(523,0,3,NULL,257),(524,0,4,NULL,257),(525,0,5,NULL,257),(526,0,6,NULL,257),(527,0,7,NULL,257),(528,0,8,NULL,257),(529,0,1,NULL,258),(530,0,2,NULL,258),(531,0,3,NULL,258),(532,0,4,NULL,258),(533,0,5,NULL,258),(534,0,6,NULL,258),(535,0,7,NULL,258),(536,0,8,NULL,258),(537,0,1,NULL,259),(538,0,2,NULL,259),(539,0,3,NULL,259),(540,0,4,NULL,259),(541,0,5,NULL,259),(542,0,6,NULL,259),(543,0,7,NULL,259),(544,0,8,NULL,259),(545,0,1,NULL,260),(546,0,2,NULL,260),(547,0,3,NULL,260),(548,0,4,NULL,260),(549,0,5,NULL,260),(550,0,6,NULL,260),(551,0,7,NULL,260),(552,0,8,NULL,260),(553,0,1,NULL,261),(554,0,2,NULL,261),(555,0,3,NULL,261),(556,0,4,NULL,261),(557,0,5,NULL,261),(558,0,6,NULL,261),(559,0,7,NULL,261),(560,0,8,NULL,261),(561,0,1,NULL,262),(562,0,2,NULL,262),(563,0,3,NULL,262),(564,0,4,NULL,262),(565,0,5,NULL,262),(566,0,6,NULL,262),(567,0,7,NULL,262),(568,0,8,NULL,262),(569,0,1,NULL,263),(570,0,2,NULL,263),(571,0,3,NULL,263),(572,0,4,NULL,263),(573,0,5,NULL,263),(574,0,6,NULL,263),(575,0,7,NULL,263),(576,0,8,NULL,263),(577,0,1,NULL,264),(578,0,2,NULL,264),(579,0,3,NULL,264),(580,0,4,NULL,264),(581,0,5,NULL,264),(582,0,6,NULL,264),(583,0,7,NULL,264),(584,0,8,NULL,264),(585,0,1,NULL,265),(586,0,2,NULL,265),(587,0,3,NULL,265),(588,0,4,NULL,265),(589,0,5,NULL,265),(590,0,6,NULL,265),(591,0,7,NULL,265),(592,0,8,NULL,265),(593,0,1,NULL,266),(594,0,2,NULL,266),(595,0,3,NULL,266),(596,0,4,NULL,266),(597,0,5,NULL,266),(598,0,6,NULL,266),(599,0,7,NULL,266),(600,0,8,NULL,266),(601,0,1,NULL,267),(602,0,2,NULL,267),(603,0,3,NULL,267),(604,0,4,NULL,267),(605,0,5,NULL,267),(606,0,6,NULL,267),(607,0,7,NULL,267),(608,0,8,NULL,267),(609,0,1,NULL,268),(610,0,2,NULL,268),(611,0,3,NULL,268),(612,0,4,NULL,268),(613,0,5,NULL,268),(614,0,6,NULL,268),(615,0,7,NULL,268),(616,0,8,NULL,268),(617,0,1,NULL,269),(618,0,2,NULL,269),(619,0,3,NULL,269),(620,0,4,NULL,269),(621,0,5,NULL,269),(622,0,6,NULL,269),(623,0,7,NULL,269),(624,0,8,NULL,269),(625,0,1,NULL,270),(626,0,2,NULL,270),(627,0,3,NULL,270),(628,0,4,NULL,270),(629,0,5,NULL,270),(630,0,6,NULL,270),(631,0,7,NULL,270),(632,0,8,NULL,270),(633,0,1,NULL,271),(634,0,2,NULL,271),(635,0,3,NULL,271),(636,0,4,NULL,271),(637,0,5,NULL,271),(638,0,6,NULL,271),(639,0,7,NULL,271),(640,0,8,NULL,271),(641,0,1,NULL,272),(642,0,2,NULL,272),(643,0,3,NULL,272),(644,0,4,NULL,272),(645,0,5,NULL,272),(646,0,6,NULL,272),(647,0,7,NULL,272),(648,0,8,NULL,272),(649,0,1,NULL,273),(650,0,2,NULL,273),(651,0,3,NULL,273),(652,0,4,NULL,273),(653,0,5,NULL,273),(654,0,6,NULL,273),(655,0,7,NULL,273),(656,0,8,NULL,273),(657,0,1,NULL,274),(658,0,2,NULL,274),(659,0,3,NULL,274),(660,0,4,NULL,274),(661,0,5,NULL,274),(662,0,6,NULL,274),(663,0,7,NULL,274),(664,0,8,NULL,274),(665,0,1,NULL,275),(666,0,2,NULL,275),(667,0,3,NULL,275),(668,0,4,NULL,275),(669,0,5,NULL,275),(670,0,6,NULL,275),(671,0,7,NULL,275),(672,0,8,NULL,275),(673,0,1,NULL,276),(674,0,2,NULL,276),(675,0,3,NULL,276),(676,0,4,NULL,276),(677,0,5,NULL,276),(678,0,6,NULL,276),(679,0,7,NULL,276),(680,0,8,NULL,276);
/*!40000 ALTER TABLE `score` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `student`
--

DROP TABLE IF EXISTS `student`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `student` (
  `std_id` varchar(25) NOT NULL,
  `std_name` varchar(100) NOT NULL,
  `std_major` varchar(10) NOT NULL,
  `std_fp_key` varchar(2000) DEFAULT NULL,
  PRIMARY KEY (`std_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student`
--

LOCK TABLES `student` WRITE;
/*!40000 ALTER TABLE `student` DISABLE KEYS */;
INSERT INTO `student` VALUES ('51370039','เกียรติศักดิ์ ศรียันยงค์','S06','dfdsf'),('51370211','รพีพงษ์ กวีกุลพิพัฒน์','S06',''),('5230250127','ชนัฎดา ช่างไม้','S06',''),('5230250135','ชยินทร์ จันทร์สัมฤทธิ์','S06',''),('5230250143','ชลชาติ นุ่มสารพัดนึก','S06',''),('5230250178','ณัชพล เครือทิม','S06',''),('5230250186','ณัชพล ศรหิรัญ','S06',''),('5230250224','ทอทอง ทองธรรมชาติ','S06',''),('5230250259','นภาวรรณ ไพรวัลย์','S06',''),('5230250291','ปพน เลิศชาคร','S06',''),('5230250313','ปิยภัทร ช่วยชาติ','S06',''),('5230250348','ภิญโญ งามเสถียร','S06',''),('5230250372','ยุวดี แสงเงิน','S06',''),('5230250381','รัฐพล ทรัพย์คล้าย','S06',''),('5230250399','เลิศฤทธิ์ กมลศิลป์','S06',''),('5230250437','สมจินตนา ถนอมศิลป์','S06',''),('5230250445','สมเดช เพิ่มพูล','S06',''),('5230250496','สุพรรษา ทอระหัน','S06',''),('5230250500','สุภัสสรา พึ่งพันธ์','S06',''),('5230250518','ดวงกมล ตั้งกิจธรรมกุล','S06',''),('5230250542','อาชา ยิ้มโสภา','S06',''),('5230250551','อิทธิพล แก้วประเสริฐ','S06',''),('5230250607','ขนิษฐา ทิพย์ศรี','S06',''),('5230250615','ขวัญชนก หนูคง','S06',''),('5230250623','คงศักดิ์ ภาเภา','S06',''),('5230250631','จันทร์จิฬา ชินโท','S06',''),('5230250798','ธีรพล ชาญธนะชัยกุล','S06',''),('5230250810','นิธิพล สากร','S06',''),('5230250844','ปภาวิน เดชดำรง','S06',''),('5230250861','พงศ์สิริ เอี่ยมสำอางค์','S06',''),('5230250879','พนิดา สุราวุธ','S06',''),('5230250925','พูนศักดิ์ ราชกิจ','S06',''),('5230251174','สุวรรณภูมิ คุปตะวาณิช','S06',''),('5230251212','อรรถพงศ์ คล้ายมิตร','S06',''),('5330200041','เครือวัลย์ มุขแก้ว','S05',''),('5330200105','เสาวภา โปร่งอากาศ','S05',''),('5330200121','เอกนรินทร์ ศิริทรัพย์','S05',''),('5330200164','กมลวรรณ ศรีเวียง','S05',''),('5330200245','จีรพร สวัสดิรักษาสิทธิ์','S05',''),('5330200288','ชนิสรา ศรีสมุทร','S05',''),('5330200300','ชลธิชา พุ่มสำเภา','S05',''),('5330200393','ณัฐวดี สารนพคุณ','S05',''),('5330200652','พรพรรณ นิลเทพี','S05',''),('5330200709','ภาคิน ฉั่วเจริญ','S05',''),('5330200903','สิทธิศักดิ์ ศรีสิงห์','S05',''),('5330201004','พัฒณียา ขวัญเต่า','S05',''),('5330250013','ธนพร ผลเจริญ','S06',''),('5330250021','ธนวัตร บัวนุช','S06',''),('5330250030','มนทิรา เรืองศรี','S06',''),('5330250048','กัญจ์นภูมิ พันธ์สุข','S06',''),('5330250056','อนุวัฒน์ กลิ่นประยูร','S06',''),('5330250064','สุรเกียรติ นาใจ','S06',''),('5330250072','สุรางค์รัตน์ คำแหง','S06',''),('5330250102','ธนวัฒน์ มาระวิชะโย','S06',''),('5330250111','ชัยวัฒน์ สอดสี','S06',''),('5330250137','ปรียาพัชร์ อติหฤทัยสุข','S06',''),('5330250145','คมสัน บุญพลบ','S06',''),('5330250153','ฐิติพงศ์ พัฒนโภครัตนา','S06',''),('5330250161','กรกฎ มณีวรรณ','S06',''),('5330250196','ปฏิภาณ ศิริไสย','S06',''),('5330250200','สุภัชชา จารุบุญญากร','S06',''),('5330250218','ธันณภัค สุวะพัฒน์','S06',''),('5330250226','นิรันดร์ เลิศปรัชญากุล','S06',''),('5330250234','ณัฏฐา แพรุ่งโรจน์ทวี','S06',''),('5330250242','นภดล อยู่บุญ','S06',''),('5330250251','พรสวรรค์ ยังมี','S06',''),('5330250277','พลอยไพลิน กำลังหาญ','S06',''),('5330250285','สิทธิพงษ์ พุทธิสารสิชฌน์','S06',''),('5330250315','ธัญธร ครองบุญ','S06',''),('5330250331','อารยา พวงรอด','S06',''),('5330250358','สุรวดี มีสุข','S06',''),('5330250374','นภัสนันท์ วงศ์กระพันธุ์','S06',''),('5330250412','ฉรัฐดา ไชยดี','S06',''),('5330250439','รัฐพล ธนเศรษฐกร','S06',''),('5330250455','ธนโชติ กิตติมหาชัย','S06',''),('5330250463','ศรัณย์ บัวไสว','S06',''),('5330250471','ณัฐชา ชนาวรรธน์สกุล','S06',''),('5330250480','เฉลิมพร ทิพย์เกศสุดา','S06',''),('5330250498','สุนันทา นะวงค์','S06',''),('5330250587','ฐาปกรณ์ ฉั่วบันลือ','S06',''),('5330250650','ภูริพันธ์ สืบเชื้อ','S06',''),('5330250731','ชุติพงศ์ มณีตัน','S06',''),('5330250790','เสกข์ โสดานิล','S06',''),('5330250811','นราวัชร์ จันทร์แสน','S06',''),('5330250889','ภาวินี อรุณผาติ','S06','');
/*!40000 ALTER TABLE `student` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `teacher_branch`
--

DROP TABLE IF EXISTS `teacher_branch`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `teacher_branch` (
  `tech_brch_id` varchar(20) NOT NULL,
  `tech_brch_name` varchar(100) NOT NULL,
  PRIMARY KEY (`tech_brch_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teacher_branch`
--

LOCK TABLES `teacher_branch` WRITE;
/*!40000 ALTER TABLE `teacher_branch` DISABLE KEYS */;
INSERT INTO `teacher_branch` VALUES ('econsrc','คณะเศรษฐศาสตร์ศรีราชา'),('engsrc','คณะวิศวกรรมศาสตร์ศรีราชา'),('imcsrc','วิทยาลัยพาณิชยนาวีนานาชาติ'),('mssrc','คณะวิทยาการจัดการ'),('scisrc','คณะวิทยาศาสตร์ศรีราชา');
/*!40000 ALTER TABLE `teacher_branch` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `teaching`
--

DROP TABLE IF EXISTS `teaching`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `teaching` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tech_id` int(11) NOT NULL,
  `sub_id` int(11) NOT NULL,
  `year` varchar(10) NOT NULL,
  PRIMARY KEY (`id`,`tech_id`,`sub_id`,`year`),
  KEY `tech_id` (`tech_id`),
  KEY `sub_id2` (`sub_id`),
  CONSTRAINT `tech_id` FOREIGN KEY (`tech_id`) REFERENCES `teacher` (`tech_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teaching`
--

LOCK TABLES `teaching` WRITE;
/*!40000 ALTER TABLE `teaching` DISABLE KEYS */;
INSERT INTO `teaching` VALUES (1,9,4,'2555'),(2,9,5,'2555');
/*!40000 ALTER TABLE `teaching` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `teacher`
--

DROP TABLE IF EXISTS `teacher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `teacher` (
  `tech_id` int(11) NOT NULL AUTO_INCREMENT,
  `tech_name` varchar(45) NOT NULL,
  `tech_branch` varchar(20) NOT NULL,
  `tech_username` varchar(45) NOT NULL,
  `tech_password` varchar(45) NOT NULL,
  `tech_fp_key` varchar(500) DEFAULT NULL,
  `tech_type` varchar(10) NOT NULL,
  `tech_question` varchar(200) NOT NULL,
  `tech_answer` varchar(200) NOT NULL,
  PRIMARY KEY (`tech_id`),
  UNIQUE KEY `tech_username_UNIQUE` (`tech_username`),
  KEY `tech_branch` (`tech_branch`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teacher`
--

LOCK TABLES `teacher` WRITE;
/*!40000 ALTER TABLE `teacher` DISABLE KEYS */;
INSERT INTO `teacher` VALUES (1,'admin','','admin','admin','','admin','ชอบสีอะไร','ฟ้า'),(9,'puy tuta','scisrc','puy','puy','','user','ชื่อเล่นชื่ออะไร','puy');
/*!40000 ALTER TABLE `teacher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subject`
--

DROP TABLE IF EXISTS `subject`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `subject` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `sub_id` varchar(25) NOT NULL,
  `sub_title` varchar(100) NOT NULL,
  `sub_lec` varchar(5) DEFAULT NULL,
  `sub_lab` varchar(5) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subject`
--

LOCK TABLES `subject` WRITE;
/*!40000 ALTER TABLE `subject` DISABLE KEYS */;
INSERT INTO `subject` VALUES (4,'01418332','Operating Systems ','870',''),(5,'01418443','Web Technology and Webservice ','870','880');
/*!40000 ALTER TABLE `subject` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-01-07  0:53:32
