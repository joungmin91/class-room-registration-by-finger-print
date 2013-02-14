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
-- Table structure for table `checkin`
--

DROP TABLE IF EXISTS `checkin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `checkin` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `reg_id` int(11) NOT NULL,
  `date` varchar(20) NOT NULL,
  `status` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `checkin`
--

LOCK TABLES `checkin` WRITE;
/*!40000 ALTER TABLE `checkin` DISABLE KEYS */;
INSERT INTO `checkin` VALUES (6,608,'2/14/2013','normal'),(7,609,'2/14/2013','normal');
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
  `term` varchar(10) NOT NULL,
  PRIMARY KEY (`reg_id`,`sub_id`,`std_id`,`year`,`term`),
  KEY `sub_id` (`sub_id`),
  KEY `std_id` (`std_id`),
  CONSTRAINT `std_id` FOREIGN KEY (`std_id`) REFERENCES `student` (`std_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=700 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `registration`
--

LOCK TABLES `registration` WRITE;
/*!40000 ALTER TABLE `registration` DISABLE KEYS */;
INSERT INTO `registration` VALUES (606,15,'5230250127','2555','ภาคปลาย'),(607,15,'5230250135','2555','ภาคปลาย'),(608,15,'5230250143','2555','ภาคปลาย'),(609,15,'5230250178','2555','ภาคปลาย'),(610,15,'5230250186','2555','ภาคปลาย'),(611,15,'5230250224','2555','ภาคปลาย'),(612,15,'5230250259','2555','ภาคปลาย'),(613,15,'5230250291','2555','ภาคปลาย'),(614,15,'5230250313','2555','ภาคปลาย'),(615,15,'5230250348','2555','ภาคปลาย'),(616,15,'5230250372','2555','ภาคปลาย'),(617,15,'5230250381','2555','ภาคปลาย'),(618,15,'5230250399','2555','ภาคปลาย'),(619,15,'5230250437','2555','ภาคปลาย'),(620,15,'5230250445','2555','ภาคปลาย'),(621,15,'5230250496','2555','ภาคปลาย'),(622,15,'5230250500','2555','ภาคปลาย'),(623,15,'5230250518','2555','ภาคปลาย'),(624,15,'5230250542','2555','ภาคปลาย'),(625,15,'5230250551','2555','ภาคปลาย'),(626,15,'5230250607','2555','ภาคปลาย'),(627,15,'5230250615','2555','ภาคปลาย'),(628,15,'5230250623','2555','ภาคปลาย'),(629,15,'5230250631','2555','ภาคปลาย'),(630,15,'5230250798','2555','ภาคปลาย'),(631,15,'5230250810','2555','ภาคปลาย'),(632,15,'5230250844','2555','ภาคปลาย'),(633,15,'5230250861','2555','ภาคปลาย'),(634,15,'5230250879','2555','ภาคปลาย'),(635,15,'5230250925','2555','ภาคปลาย'),(636,15,'5230251174','2555','ภาคปลาย'),(637,15,'5230251212','2555','ภาคปลาย'),(638,16,'51370260','2555','ภาคปลาย'),(639,16,'51371078','2555','ภาคปลาย'),(640,16,'51371904','2555','ภาคปลาย'),(641,16,'5230200073','2555','ภาคปลาย'),(642,16,'5230200111','2555','ภาคปลาย'),(643,16,'5230200391','2555','ภาคปลาย'),(644,16,'5230201011','2555','ภาคปลาย'),(645,16,'5230250101','2555','ภาคปลาย'),(646,16,'5230250232','2555','ภาคปลาย'),(647,16,'5230250275','2555','ภาคปลาย'),(648,16,'5230250283','2555','ภาคปลาย'),(649,16,'5230250330','2555','ภาคปลาย'),(650,16,'5230250364','2555','ภาคปลาย'),(651,16,'5230250470','2555','ภาคปลาย'),(652,16,'5230250577','2555','ภาคปลาย'),(653,17,'5230250127','2555','ภาคปลาย'),(654,17,'5230250135','2555','ภาคปลาย'),(655,17,'5230250143','2555','ภาคปลาย'),(656,17,'5230250178','2555','ภาคปลาย'),(657,17,'5230250186','2555','ภาคปลาย'),(658,17,'5230250224','2555','ภาคปลาย'),(659,17,'5230250259','2555','ภาคปลาย'),(660,17,'5230250291','2555','ภาคปลาย'),(661,17,'5230250313','2555','ภาคปลาย'),(662,17,'5230250348','2555','ภาคปลาย'),(663,17,'5230250372','2555','ภาคปลาย'),(664,17,'5230250381','2555','ภาคปลาย'),(665,17,'5230250399','2555','ภาคปลาย'),(666,17,'5230250437','2555','ภาคปลาย'),(667,17,'5230250445','2555','ภาคปลาย'),(668,17,'5230250496','2555','ภาคปลาย'),(669,17,'5230250500','2555','ภาคปลาย'),(670,17,'5230250518','2555','ภาคปลาย'),(671,17,'5230250542','2555','ภาคปลาย'),(672,17,'5230250551','2555','ภาคปลาย'),(673,17,'5230250607','2555','ภาคปลาย'),(674,17,'5230250615','2555','ภาคปลาย'),(675,17,'5230250623','2555','ภาคปลาย'),(676,17,'5230250631','2555','ภาคปลาย'),(677,17,'5230250798','2555','ภาคปลาย'),(678,17,'5230250810','2555','ภาคปลาย'),(679,17,'5230250844','2555','ภาคปลาย'),(680,17,'5230250861','2555','ภาคปลาย'),(681,17,'5230250879','2555','ภาคปลาย'),(682,17,'5230250925','2555','ภาคปลาย'),(683,17,'5230251174','2555','ภาคปลาย'),(684,17,'5230251212','2555','ภาคปลาย'),(685,17,'51370260','2555','ภาคปลาย'),(686,17,'51371078','2555','ภาคปลาย'),(687,17,'51371904','2555','ภาคปลาย'),(688,17,'5230200073','2555','ภาคปลาย'),(689,17,'5230200111','2555','ภาคปลาย'),(690,17,'5230200391','2555','ภาคปลาย'),(691,17,'5230201011','2555','ภาคปลาย'),(692,17,'5230250101','2555','ภาคปลาย'),(693,17,'5230250232','2555','ภาคปลาย'),(694,17,'5230250275','2555','ภาคปลาย'),(695,17,'5230250283','2555','ภาคปลาย'),(696,17,'5230250330','2555','ภาคปลาย'),(697,17,'5230250364','2555','ภาคปลาย'),(698,17,'5230250470','2555','ภาคปลาย'),(699,17,'5230250577','2555','ภาคปลาย');
/*!40000 ALTER TABLE `registration` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `score_rating`
--

DROP TABLE IF EXISTS `score_rating`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `score_rating` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tech_id` int(11) NOT NULL,
  `a` int(11) NOT NULL DEFAULT '0',
  `b` int(11) NOT NULL DEFAULT '0',
  `c` int(11) NOT NULL DEFAULT '0',
  `d` int(11) NOT NULL DEFAULT '0',
  `mid` int(11) NOT NULL DEFAULT '0',
  `final` int(11) NOT NULL DEFAULT '0',
  `score1` int(11) NOT NULL DEFAULT '0',
  `score2` int(11) NOT NULL DEFAULT '0',
  `score3` int(11) NOT NULL DEFAULT '0',
  `score4` int(11) NOT NULL DEFAULT '0',
  `score5` int(11) NOT NULL DEFAULT '0',
  `checkin` int(11) NOT NULL,
  `bp` int(11) NOT NULL,
  `cp` int(11) NOT NULL,
  `dp` int(11) NOT NULL,
  `f` int(11) NOT NULL,
  `score1_title` varchar(100) DEFAULT NULL,
  `score2_title` varchar(100) DEFAULT NULL,
  `score3_title` varchar(100) DEFAULT NULL,
  `score4_title` varchar(100) DEFAULT NULL,
  `score5_title` varchar(100) DEFAULT NULL,
  `score_type` varchar(45) DEFAULT NULL,
  `score_lab` int(11) DEFAULT NULL,
  `force_f_checkin` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `score_rating`
--

LOCK TABLES `score_rating` WRITE;
/*!40000 ALTER TABLE `score_rating` DISABLE KEYS */;
INSERT INTO `score_rating` VALUES (1,17,80,70,58,46,30,30,10,5,5,5,5,10,76,64,52,40,'ชิ้นงาน','รายงาน','','','','group',0,1),(2,19,80,70,58,46,30,40,10,0,0,0,0,10,76,64,52,40,'รายงาน','','','','','group',10,0);
/*!40000 ALTER TABLE `score_rating` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `score`
--

DROP TABLE IF EXISTS `score`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `score` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `reg_id` int(11) NOT NULL,
  `mid` int(11) NOT NULL DEFAULT '0',
  `final` int(11) NOT NULL DEFAULT '0',
  `score1` int(11) NOT NULL DEFAULT '0',
  `score2` int(11) NOT NULL DEFAULT '0',
  `score3` int(11) NOT NULL DEFAULT '0',
  `score4` int(11) NOT NULL DEFAULT '0',
  `score5` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `reg_id` (`score1`),
  KEY `score_type` (`mid`)
) ENGINE=InnoDB AUTO_INCREMENT=980 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `score`
--

LOCK TABLES `score` WRITE;
/*!40000 ALTER TABLE `score` DISABLE KEYS */;
INSERT INTO `score` VALUES (901,606,0,0,0,0,0,0,0),(902,607,0,0,0,0,0,0,0),(903,608,30,30,5,0,0,5,5),(904,609,20,20,5,0,0,0,0),(905,610,0,0,0,0,0,0,0),(906,611,0,0,0,0,0,0,0),(907,612,0,0,0,0,0,0,0),(908,613,0,0,0,0,0,0,0),(909,614,0,0,0,0,0,0,0),(910,615,0,0,0,0,0,0,0),(911,616,0,0,0,0,0,0,0),(912,617,0,0,0,0,0,0,0),(913,618,0,0,0,0,0,0,0),(914,619,0,0,0,0,0,0,0),(915,620,0,0,0,0,0,0,0),(916,621,0,0,0,0,0,0,0),(917,622,0,0,0,0,0,0,0),(918,623,0,0,0,0,0,0,0),(919,624,0,0,0,0,0,0,0),(920,625,0,0,0,0,0,0,0),(921,626,0,0,0,0,0,0,0),(922,627,0,0,0,0,0,0,0),(923,628,0,0,0,0,0,0,0),(924,629,0,0,0,0,0,0,0),(925,630,0,0,0,0,0,0,0),(926,631,0,0,0,0,0,0,0),(927,632,0,0,0,0,0,0,0),(928,633,0,0,0,0,0,0,0),(929,634,0,0,0,0,0,0,0),(930,635,0,0,0,0,0,0,0),(931,636,0,0,0,0,0,0,0),(932,637,0,0,0,0,0,0,0),(933,685,0,0,0,0,0,0,0),(934,686,0,0,0,0,0,0,0),(935,687,0,0,0,0,0,0,0),(936,688,0,0,0,0,0,0,0),(937,689,0,0,0,0,0,0,0),(938,690,0,0,0,0,0,0,0),(939,691,0,0,0,0,0,0,0),(940,692,0,0,0,0,0,0,0),(941,653,0,0,0,0,0,0,0),(942,654,0,0,0,0,0,0,0),(943,655,0,0,0,0,0,0,0),(944,656,0,0,0,0,0,0,0),(945,657,0,0,0,0,0,0,0),(946,658,0,0,0,0,0,0,0),(947,693,0,0,0,0,0,0,0),(948,659,0,0,0,0,0,0,0),(949,694,0,0,0,0,0,0,0),(950,695,0,0,0,0,0,0,0),(951,660,0,0,0,0,0,0,0),(952,661,0,0,0,0,0,0,0),(953,696,0,0,0,0,0,0,0),(954,662,0,0,0,0,0,0,0),(955,697,0,0,0,0,0,0,0),(956,663,0,0,0,0,0,0,0),(957,664,0,0,0,0,0,0,0),(958,665,0,0,0,0,0,0,0),(959,666,0,0,0,0,0,0,0),(960,667,0,0,0,0,0,0,0),(961,698,0,0,0,0,0,0,0),(962,668,0,0,0,0,0,0,0),(963,669,0,0,0,0,0,0,0),(964,670,0,0,0,0,0,0,0),(965,671,0,0,0,0,0,0,0),(966,672,0,0,0,0,0,0,0),(967,699,0,0,0,0,0,0,0),(968,673,0,0,0,0,0,0,0),(969,674,0,0,0,0,0,0,0),(970,675,0,0,0,0,0,0,0),(971,676,0,0,0,0,0,0,0),(972,677,0,0,0,0,0,0,0),(973,678,0,0,0,0,0,0,0),(974,679,0,0,0,0,0,0,0),(975,680,0,0,0,0,0,0,0),(976,681,0,0,0,0,0,0,0),(977,682,0,0,0,0,0,0,0),(978,683,0,0,0,0,0,0,0),(979,684,0,0,0,0,0,0,0);
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
INSERT INTO `student` VALUES ('51370260','วุฒินันท์ คงศรี','S06',''),('51371078','ภาณุกร เพ็ชรดี','S06',''),('51371904','วิระพงษ์ แสงสุวรรณ์','S06',''),('5230200073','กฤษณ์ ศรีสวัสดิ์','S05',''),('5230200111','กุลดิลก เวชประสิทธิ์','S05',''),('5230200391','ทรงพล จันทองทิพย์','S05',''),('5230201011','สุกฤษฏิ์ บุญกาญจน์วนิชา','S05',''),('5230250101','จิราภรณ์ ศุภอรรถสิทธิ์','S06',''),('5230250127','ชนัฎดา ช่างไม้','S06','mspZVqKin6xUARRZtz7BCkWXUIEG7RdxwQmDNVRBFELJSQEEMiJ6gQgZrY2BBZudh4EFIQ9uwQcRIosBBZVHJAEFtJA2AQbfH3OBC4ObOsEI3pxhgQh2uIzBCKIKMoEE3ZYqQQXZmEeBCmedTcEKaL1dgQousnABDI3IU8EDMsJUQQYwLUPBCVOZMMEGW8eUgRW1xo4BFKYPQ8EGaUqPwXCiBDjBCmYFcsEKiUuLATebFoQBBY7JfcEMnwhBgQpmzXlBCRjQaQEDIkqSQU2uLvQMGKIUUyQCE09RU1RWWFxgaXIDDRcdISMmKgITS01PUFNUVlhfbwUSHCIkJyksAhNSVFZXWFxgZ250AgkSGR0iJScBE0ZISUpLTk9QT1NbFRwiJScpLS8CE1NVVlhbX2RqcHQBCBAYHCAjJQETREVGRkdISEhGRj8tJigpKi0wMgITVFZYW11gZm1ydgIIDxcaHyEjARNCQ0NDQ0NCQj8+NzArKyssLjEzAhNWWFlcX2NpcHR3BAoRFxkcHyEBE0JCQUFBQD49OjgzLywrKy0wMzUCElhZXF5hZWtxdQIHCxEWGRwdARNBQD8/Pj07Ojg1MC0pKSkrLzM2AhJZW11fYmhtcXUCBwsRFRkbHQETPj49Ozs6OTg3MzArKCYmJy01OwISWVxeYGNnbXF1AgcKEBQYGx0BEzs6ODg4ODc1NDIuKickIiEjN0QCEllcXmFjaG5zdgIGCQ8TFxkcARM4NzY2NjY1NDMwLCglIh0YD2RWAxFcX2JkaW90dwIGCw8TFhkCEzUzMzM0MzIwLSglIx8ZEAVvYQQQXmJla3F1dwIGDBATFgMSMjIyMzMyLysnJCIdFw8DcRj4Lxk0qVAUITcrwbJNIqexO53+S3TjcWi08Mlb8+a2E8bYaeUeHDgYtf3rmxGgg/MnHRldckcySO321yqE4ELonQwqp7l4cbH825cy0SCH6Tif2wLQN//GhDIqqi959jsjqvjZUEjgAueY57wuc56D3yw+F4HyXj7lxzXpyHuttmLkFJDiQm0G3TirCYeoywDLmP0av6Igp0aCRdJ4VkXKojYsU3/iBRRkRy6VhBZgQC20pBLT3rBPt+aMPPJHEBUIs3hzlZPgGgZM1Yacz7SJgq75LFy259h5A4k8FMuQd9PORbb6JqapFmIQSBZjIs3Up5sx6wy+nOjDQNE+k6EIZKdHV+q6WZrSGUG9XA6rJtKdgze76CYAxyRLvAB6o5dKQZJCO6EQhptcRGstx+0qkHE8/bx450CFHHc='),('5230250135','ชยินทร์ จันทร์สัมฤทธิ์','S06','mspZlp/avTNTwQxMNFgBFkY0X8EMQKlNgRjUqlYBIgQtUYEl47x1wQhAvW1BBkAZXIEM6hxewRQJNXyBBzI1gMEJNCJSgR3kIkbBC86lSAEN0KVPQSXmjXyBDYQPf4EMgZwzQQZMpx9BBktAPAEaa6NhQRcXuC8BVLC6YcELRxY0QQPPiTuBBdaTXIEL6RFWgQnfG2ZBEw+1PsELxCYwQQTBC23BBwoPaEELBRdrgQwMqz3BBr8UJUECUq4ogQVAhFEBBWKWZQEKcYwiwQRXlIkBBxjEOoEUaxaHwQeLwnWBBkSdeUELGbc1wTjEQmXBBLs3SEEFUbuEQSGnQSTBJZoqYkEdJbopgSsaLGABJoE2HYEMOz00jBa9NE4MAxJHRkVFR0dWcwcXIyclJSQnAxJEQ0RCRUZPVxUkKCkmJyYrAxJISEZHSEhWcwUQHCEhIiIlAhNBQ0JDREhJUUk2MjIxLSsrLTQDEkxNS0xLT11wAgsYGxwdHyICE0A/PUBGT0xMRD43MjEsLS0xOQMST1BPTU5RW2l0CBIWGBkaGwMTOjg+XV1RTUZCPTU0LCgnLTYDElFSUlBSVl5mcQQMDxMVGRoDEzMpA29jUElGQz80NzYzJik3AxJTU1RTVllfZW8BBgsPERUWBBIBdm9nVk1FQj89PT01JCEDElVVVVRXW2FlbXUECQ8RFRcFEXZwaF9VSURCQ0FAPTUDEVZXV1dZXWFkbHQCCA4RFQUQAXNvaVlQSkhHRUM9AxFXWVhYWV5iZmxzAQcNEBMGD3Z0cmleU1JOSUMDEVZYWFhbX2JmbXN3BQsPEwcIdnUEEFhXV1lfY2dtcncECg8AAP8Y+C8ZNKlQFCEWLMtNhnX60I0k8pnU4CdM7lBm92gL0XgU9C4YV+MzUGa0eaN1NpwAIqpW6o3xy+OUHAPjQ9ukxgTVqyy6U4C6ZyKKPbqZ6nVf/EbVzYcYY8WLj+Ble96v6V6EZ8RaqFJtTlbNMk8ss+GeM+AsT+gl6ibkMaH8RK/OrS0MVih4iloIPWe8/M7E6Nqaua8y4OC307YXFifr+Py43zTbX/cyMIC7tpIAX2meU92jc2pj3MlpCWMvFTbTC6yOANJEOKFf1rvLJFAxnddvxSZD8n7DWd04uV3+EtorjI49hxEKsBGBNhfISSVRfVkFz/LbSGsPcKF3TvUpcTfLf4g4fJOu0TA/lIjkTCKkJrv7pTXHFlPNFL7llAFVfbLfNHSJHMP2Z55nyGBFZ63ptzPHklV8V9t3'),('5230250143','ชลชาติ นุ่มสารพัดนึก','S06','mspZVqC3mLdpQQ+luWQBFZ2rTkEYVa5UgRZQpkFBFLSmRYEUusUtQQWBSDOBBIG5PYESBrxhARuAKV4BBzcvOoEgDiFPgQw9NExBHM0fX0EMML9nwRaBvzZBCoghRwEMQ597AQYrr4CBB6M5hgEJnhRJAR8DoHQBBKIkV0EIO7JbAR4/ojRBCEMuJAEKOJZWgRMhR2cBCHSJa0EFHA9OARcIqkSBVpS9dwEOl040QQh4lzJBBlELRgEPZr+JQQ6QwYABEIjKf0EKfUtvwQh2FUJBFduqQgFlqkYwQQYK0TnBAwAcTAFeMEMERxK4lOoQGnCtFgITQkE/PTg2QEdBOTUyMC8uLSwtAhM+PTo3LyRuU0U6NTEvLi0tLC0CE0NEQ0E+PUBBPTczMTAvLSsqKwITOjY0LiQVd2FPOTEtKyopKiosAhNGR0dGRERBPTYzMC4tLSspKSgCEzcuLCQcDwFsZSUnJyYmJSUmKAMTS0tLSUtGOS0tKysrKignJygCEzYkIhwWDANzcwYZICAgISAhIgMSUFBQT1NYFyElJicoKCYmJgMTGRgWEAkDdnYCChQYGRgYGh8DElNUU1RXYncUHSIkJSUlJCQDEw4PDgoGAwF2dwQLDxAPDxEZAxJUVlZYXGRzCxgfISIjIyMjAxIICQkGBAJ3dnV3BAgJCQkKAxJVV1hcX2dzBxQbHSAhISEhBBIHBwQDAXd1dXV3AwQFBggDEVhbXWBlbXUGERcaHB8gIQQRBgQCAXd3dnV0dXYBAgMDEVteYGNqcXcHDxUYGhwdIAURAnd3dnd2dXRzdHV2dwQQYGJla3MBBw8UFhgaHAYQdnZ3d3d1dHR0dnYY+C8ZNKlQFCEmKMFYlPBw319wUA50Ty/h++CJ3JGzsYgfWKR5/hd7o9yLFjzgs8gesxlEUKTItpohcPK8PRN3YTuud6ZyKEj6uGL8j0XV86TUNjJT+fmIYZbA4IVf6LMUr2LEEJ63eezSZjq32wT14mg3tmkTYbZF3ovBfrFnTV6SgHbFgQZ0HnAAitM8YR62At5dYEk11t32gE26XJrbotutjCU5CoraHhrVmAYQep7xzB7xtDKmaSHlV8eCPxT6/+plF9pLxFuyRe8Na6KNFU9JDzPjoCsw2OmQmWAt1FME/tOg86uHOZRrEyi/ueatWWcOBPZ3auwdOaRXYHmzrg/4q4w4EEhckQagPC5fWR5fyzWP43jfVC18XdIBmbAQIW1tl+7mOVE6Em20MkWDstdYLyXYJ5hs97Z3'),('5230250178','ณัชพล เครือทิม','S06','mspZFol1sytVQRo0rlnBCzGgSEEcUC81gQG2D03BCm6SMEEG1K4uQQI/zVJBCKCKX4EIDyR7wQGjFEpBEusFhEECJCRlgQabuTjBBTSgKcEGS6k4gQVAjDqBC16HZoEKh86FgQmQGykBBk8MiwECmkOFQQibhTjBCWEGeAEIkMpwAQyWTXwBC5BUPgELm1J4AQeEy45BBIwxxKkUAxNEQ0JBPz89MignKisqKSgpKgITRENCQD89Ozk0LissLCooJygoAxNFRUREQ0ZIJSAlKSoqKSgoKwITRENBPz06OTc0MC0tLCooJicnAxNISEhJSVFgChoiJykpJyYmKQITQ0NAPzs6ODY0MS8tLCooJiYmAxNLS0xNT1luCBghJicoJiUkJwITQkA+PTo4NjUzMC4tLCkoJiYlAxNPUFFSVWBxBxUfIyUmJCQjJgMTPTs6ODY0NDIvLSwqKCckJCMDElBSU1VZY3EFEBsgIyMjIyMDEzg4NzY0MjAuKykoKCUkISEgAxJSVFVYX2dyBA0XHCAhISIjBBM2NTMxMC0rKCUkIyEfHBwgBBJWWFxla3QECRIYHB8hIiMEEjMyMC4sKickIB0bGRgYGgQSWV1gaXB3BQkPFhodICIkBBEvLy0qJyYjIBsXFBISFAQRWF5haXABBgoPFRocHyIFESkoJCIgHBgTDw0MDA8FEGBjaHABBwwQFRocHwYQJCEfHBcSDQwJCQkY+C8ZNKlQFCEgIMi5ek5aF8TZ8iLcQagQo2SAS2mBhpfphUJuBbXP6oc0+2dxqBjHxIYoqULZEZcruu53M+AiwhfxnEcL8LZ0SzMBR8eQMAE1xXthilCFWuK03FSZ+9g4XB6VpE+HllAakqq8CWE70JE0Azlg6Ol8qE4WI0H2L+3mSnY9wOoVfQ/FAdpQUVnFu57WTx5Fzt676vLLakqL/GME/N8DR6r6COEz9brWogX+GixyYtOx108ge5Zkxg0J9QtGuWCcJnIVrG3Z3wPbws8naCiX9KXYhe1KRQ8P929wBvw/AFjKv6CZ+4p5LEAZN1HsvAVkqtAQkguVgjBCW+bbi7NqlDyrnGKObrAImI25mu1tIDXEpLicXfN78PuQj70NKcidOurw9vEdS5s/MaNaKchkctYsK153'),('5230250186','ณัชพล ศรหิรัญ','S06',''),('5230250224','ทอทอง ทองธรรมชาติ','S06',''),('5230250232','ทิพย์วรรณ นพวรรณ','S06',''),('5230250259','นภาวรรณ ไพรวัลย์','S06',''),('5230250275','เนาวรัตน์ สวัสดิ์พิพัฒน์ผล','S06',''),('5230250283','บุษกร ชักนำ','S06',''),('5230250291','ปพน เลิศชาคร','S06',''),('5230250313','ปิยภัทร ช่วยชาติ','S06',''),('5230250330','ภาณิกา แสนจันทร์','S06',''),('5230250348','ภิญโญ งามเสถียร','S06',''),('5230250364','มัทณา มะโนรมย์','S06',''),('5230250372','ยุวดี แสงเงิน','S06',''),('5230250381','รัฐพล ทรัพย์คล้าย','S06',''),('5230250399','เลิศฤทธิ์ กมลศิลป์','S06',''),('5230250437','สมจินตนา ถนอมศิลป์','S06',''),('5230250445','สมเดช เพิ่มพูล','S06',''),('5230250470','สิทธิศักดิ์ บุญแก้ว','S06',''),('5230250496','สุพรรษา ทอระหัน','S06',''),('5230250500','สุภัสสรา พึ่งพันธ์','S06',''),('5230250518','ดวงกมล ตั้งกิจธรรมกุล','S06',''),('5230250542','อาชา ยิ้มโสภา','S06',''),('5230250551','อิทธิพล แก้วประเสริฐ','S06',''),('5230250577','กษิดิศ ขวัญละมูล','S06',''),('5230250607','ขนิษฐา ทิพย์ศรี','S06',''),('5230250615','ขวัญชนก หนูคง','S06',''),('5230250623','คงศักดิ์ ภาเภา','S06',''),('5230250631','จันทร์จิฬา ชินโท','S06',''),('5230250798','ธีรพล ชาญธนะชัยกุล','S06',''),('5230250810','นิธิพล สากร','S06',''),('5230250844','ปภาวิน เดชดำรง','S06',''),('5230250861','พงศ์สิริ เอี่ยมสำอางค์','S06',''),('5230250879','พนิดา สุราวุธ','S06',''),('5230250925','พูนศักดิ์ ราชกิจ','S06',''),('5230251174','สุวรรณภูมิ คุปตะวาณิช','S06',''),('5230251212','อรรถพงศ์ คล้ายมิตร','S06','');
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
-- Table structure for table `checkin_date`
--

DROP TABLE IF EXISTS `checkin_date`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `checkin_date` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `date` varchar(45) NOT NULL,
  `tech_id` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `checkin_date`
--

LOCK TABLES `checkin_date` WRITE;
/*!40000 ALTER TABLE `checkin_date` DISABLE KEYS */;
INSERT INTO `checkin_date` VALUES (1,'2/14/2013',17),(2,'2/13/2013',17),(3,'2/12/2013',17),(4,'2/11/2013',17);
/*!40000 ALTER TABLE `checkin_date` ENABLE KEYS */;
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
  `term` varchar(10) NOT NULL,
  PRIMARY KEY (`id`,`tech_id`,`sub_id`,`year`,`term`),
  KEY `tech_id` (`tech_id`),
  KEY `sub_id2` (`sub_id`),
  CONSTRAINT `tech_id` FOREIGN KEY (`tech_id`) REFERENCES `teacher` (`tech_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teaching`
--

LOCK TABLES `teaching` WRITE;
/*!40000 ALTER TABLE `teaching` DISABLE KEYS */;
INSERT INTO `teaching` VALUES (17,9,15,'2555','ภาคปลาย'),(18,9,16,'2555','ภาคปลาย'),(19,9,17,'2555','ภาคปลาย');
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
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teacher`
--

LOCK TABLES `teacher` WRITE;
/*!40000 ALTER TABLE `teacher` DISABLE KEYS */;
INSERT INTO `teacher` VALUES (1,'admin','','admin','admin','','admin','ชอบสีอะไร','ฟ้า'),(9,'puy tuta','scisrc','puy','puy','','user','ชื่อเล่นชื่ออะไร','puy'),(10,'patt','econsrc','patt','patt','','user','ชื่อเล่นชื่ออะไร','patt');
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
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subject`
--

LOCK TABLES `subject` WRITE;
/*!40000 ALTER TABLE `subject` DISABLE KEYS */;
INSERT INTO `subject` VALUES (15,'01418443','Web Technology and Webservice ','870','880'),(16,'01418443','Web Technology and Webservice ','870','881'),(17,'01418443','Web Technology and Webservice ','870','');
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

-- Dump completed on 2013-02-14 17:32:44
