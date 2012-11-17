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
-- Table structure for table `registration`
--

DROP TABLE IF EXISTS `registration`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `registration` (
  `sub_id` varchar(25) NOT NULL,
  `std_id` varchar(25) NOT NULL,
  `year` varchar(10) NOT NULL,
  PRIMARY KEY (`sub_id`,`std_id`,`year`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `registration`
--

LOCK TABLES `registration` WRITE;
/*!40000 ALTER TABLE `registration` DISABLE KEYS */;
/*!40000 ALTER TABLE `registration` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `teacher`
--

DROP TABLE IF EXISTS `teacher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `teacher` (
  `tech_id` int(11) NOT NULL AUTO_INCREMENT,
  `tech_fname` varchar(45) NOT NULL,
  `tech_lname` varchar(45) NOT NULL,
  `tech_addr` varchar(300) DEFAULT NULL,
  `tech_phone` varchar(50) DEFAULT NULL,
  `tech_username` varchar(45) NOT NULL,
  `tech_password` varchar(45) NOT NULL,
  `tech_fp_key` varchar(500) DEFAULT NULL,
  `tech_type` varchar(10) NOT NULL,
  PRIMARY KEY (`tech_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teacher`
--

LOCK TABLES `teacher` WRITE;
/*!40000 ALTER TABLE `teacher` DISABLE KEYS */;
INSERT INTO `teacher` VALUES (1,'patt','tech','xxxxxxxxxx xxxx','0896494533','patt.tech','password','mspZlqGinEg+AQgtTT7BBC8mXYEIFLB9gQUnFE5BBg0eg8EBkpllQQWKH33BAhwwcgEFlqBpgQUdJW0BBJE6dMEInROHwQIbqIxBBCIjVoELfzZVAQyJwkXBCighRIEJdDI5ARRWOzpBEz2jMIEKZZtSwQmBCFMBCoUMegEElCIdgQfbTDTBBy7LiYEPSlOEARxkSX9BFq9NfYFCuch4ARWilhlBBtzMaIEMnFBlAQoWsyjBClE+JkEJP5YkAQVqjyIBCmYdMwEG6x4qgQhlLkTOEZvkMx4CE1VZXWJobnMBCREYGx8hISEhIQITUlZZX2NrcwIMFRsdISIjIiIiAhNXW2BnbHB0AggPFhodICAfICACE1BUVlhbY3AEEhofISQlJiQkJAITW11iaXBzdgMJEBYZHB0dHR0fARNKTE9QUVJXZwsZHyIjJigpJyYmAhNcYGVscnYCBQoQFRgbHB0dHR0BE0VHSUlJR0lBJSEkJSYpLCwq','admin'),(8,'puy','naja','Bangkok','02156489','puy','password','','admin');
/*!40000 ALTER TABLE `teacher` ENABLE KEYS */;
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
  `std_fp_key` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`std_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student`
--

LOCK TABLES `student` WRITE;
/*!40000 ALTER TABLE `student` DISABLE KEYS */;
INSERT INTO `student` VALUES ('51370039','เกียรติศักดิ์ ศรียันยงค์','S06','mspZFpy3nThzAQ6huW1BF5guUwEdYq9cwRJOMl9BHFCpS0EWuKtNQTG/vGuBGXzAckEUfiRVwQ8+NVTBG82qZIEJNR9RAWkrs2MBIDs7R0EPASFkAQwusUDBHgwmXoEKOb5ZQQXuQEBBCYWggcEGKDiPgQmZo0yBD0EwiAEIoZdNgR0BonpBBKDAXAEDeYxtwQYZmVsBER5Gc8EHc0p8wQhzElGBFQWZRUES2jyCwQ6SpTkBCEAaN4EGUI9IAQ9mwItBD4bJjEEIe0g7QQUIQH1BDoWuSgFplKxKAVGsuDdBEBg/lQERjEHkxxO3NMsSFrDtGAMTQUFAPjk4PkA7NTAtLCsqKikDEz8+OzgxK0BJQDYwLSsqKSkoAxNGRURCQEA+OzYxLSwrKignKAMTOzg2MCUYdlhGNi4pJyYmJyYDE0pKSUhHR0E1LSspKCgnJiUmBBMyLiccDnZoYCokIyMiISIiAxNPT09OTlJUIiMlJCUlJCQj'),('51370211','รพีพงษ์ กวีกุลพิพัฒน์','S06',''),('5330200041','เครือวัลย์ มุขแก้ว','S05',''),('5330200105','เสาวภา โปร่งอากาศ','S05',''),('5330200121','เอกนรินทร์ ศิริทรัพย์','S05',''),('5330200164','กมลวรรณ ศรีเวียง','S05',''),('5330200245','จีรพร สวัสดิรักษาสิทธิ์','S05',''),('5330200288','ชนิสรา ศรีสมุทร','S05',''),('5330200300','ชลธิชา พุ่มสำเภา','S05',''),('5330200393','ณัฐวดี สารนพคุณ','S05',''),('5330200652','พรพรรณ นิลเทพี','S05',''),('5330200709','ภาคิน ฉั่วเจริญ','S05',''),('5330200903','สิทธิศักดิ์ ศรีสิงห์','S05',''),('5330201004','พัฒณียา ขวัญเต่า','S05',''),('5330250013','ธนพร ผลเจริญ','S06',''),('5330250021','ธนวัตร บัวนุช','S06',''),('5330250030','มนทิรา เรืองศรี','S06',''),('5330250048','กัญจ์นภูมิ พันธ์สุข','S06',''),('5330250056','อนุวัฒน์ กลิ่นประยูร','S06',''),('5330250064','สุรเกียรติ นาใจ','S06',''),('5330250072','สุรางค์รัตน์ คำแหง','S06',''),('5330250102','ธนวัฒน์ มาระวิชะโย','S06',''),('5330250111','ชัยวัฒน์ สอดสี','S06',''),('5330250137','ปรียาพัชร์ อติหฤทัยสุข','S06',''),('5330250145','คมสัน บุญพลบ','S06',''),('5330250153','ฐิติพงศ์ พัฒนโภครัตนา','S06',''),('5330250161','กรกฎ มณีวรรณ','S06',''),('5330250196','ปฏิภาณ ศิริไสย','S06',''),('5330250200','สุภัชชา จารุบุญญากร','S06',''),('5330250218','ธันณภัค สุวะพัฒน์','S06',''),('5330250226','นิรันดร์ เลิศปรัชญากุล','S06',''),('5330250234','ณัฏฐา แพรุ่งโรจน์ทวี','S06',''),('5330250242','นภดล อยู่บุญ','S06',''),('5330250251','พรสวรรค์ ยังมี','S06',''),('5330250277','พลอยไพลิน กำลังหาญ','S06',''),('5330250285','สิทธิพงษ์ พุทธิสารสิชฌน์','S06',''),('5330250315','ธัญธร ครองบุญ','S06',''),('5330250331','อารยา พวงรอด','S06',''),('5330250358','สุรวดี มีสุข','S06',''),('5330250374','นภัสนันท์ วงศ์กระพันธุ์','S06',''),('5330250412','ฉรัฐดา ไชยดี','S06',''),('5330250439','รัฐพล ธนเศรษฐกร','S06',''),('5330250455','ธนโชติ กิตติมหาชัย','S06',''),('5330250463','ศรัณย์ บัวไสว','S06',''),('5330250471','ณัฐชา ชนาวรรธน์สกุล','S06',''),('5330250480','เฉลิมพร ทิพย์เกศสุดา','S06',''),('5330250498','สุนันทา นะวงค์','S06',''),('5330250587','ฐาปกรณ์ ฉั่วบันลือ','S06',''),('5330250650','ภูริพันธ์ สืบเชื้อ','S06',''),('5330250731','ชุติพงศ์ มณีตัน','S06',''),('5330250790','เสกข์ โสดานิล','S06',''),('5330250811','นราวัชร์ จันทร์แสน','S06',''),('5330250889','ภาวินี อรุณผาติ','S06','');
/*!40000 ALTER TABLE `student` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subject`
--

DROP TABLE IF EXISTS `subject`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `subject` (
  `sub_id` varchar(25) NOT NULL,
  `sub_title` varchar(100) NOT NULL,
  PRIMARY KEY (`sub_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subject`
--

LOCK TABLES `subject` WRITE;
/*!40000 ALTER TABLE `subject` DISABLE KEYS */;
INSERT INTO `subject` VALUES ('01418332','Operating Systems');
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

-- Dump completed on 2012-11-11  0:48:12
