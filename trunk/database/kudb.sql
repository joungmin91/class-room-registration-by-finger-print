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
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `checkin`
--

LOCK TABLES `checkin` WRITE;
/*!40000 ALTER TABLE `checkin` DISABLE KEYS */;
INSERT INTO `checkin` VALUES (2,356,'1/21/2013','normal'),(3,357,'1/23/2013','absence'),(5,358,'1/21/2013','late'),(6,357,'1/21/2013','normal'),(7,358,'1/23/2013','normal'),(8,356,'1/23/2013','normal'),(9,359,'1/23/2013','absence'),(10,360,'1/21/2013','normal');
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
) ENGINE=InnoDB AUTO_INCREMENT=403 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `registration`
--

LOCK TABLES `registration` WRITE;
/*!40000 ALTER TABLE `registration` DISABLE KEYS */;
INSERT INTO `registration` VALUES (356,8,'5230250127','2555','ภาคปลาย'),(357,8,'5230250135','2555','ภาคปลาย'),(358,8,'5230250143','2555','ภาคปลาย'),(359,8,'5230250178','2555','ภาคปลาย'),(360,8,'5230250186','2555','ภาคปลาย'),(361,8,'5230250224','2555','ภาคปลาย'),(362,8,'5230250259','2555','ภาคปลาย'),(363,8,'5230250291','2555','ภาคปลาย'),(364,8,'5230250313','2555','ภาคปลาย'),(365,8,'5230250348','2555','ภาคปลาย'),(366,8,'5230250372','2555','ภาคปลาย'),(367,8,'5230250381','2555','ภาคปลาย'),(368,8,'5230250399','2555','ภาคปลาย'),(369,8,'5230250437','2555','ภาคปลาย'),(370,8,'5230250445','2555','ภาคปลาย'),(371,8,'5230250496','2555','ภาคปลาย'),(372,8,'5230250500','2555','ภาคปลาย'),(373,8,'5230250518','2555','ภาคปลาย'),(374,8,'5230250542','2555','ภาคปลาย'),(375,8,'5230250551','2555','ภาคปลาย'),(376,8,'5230250607','2555','ภาคปลาย'),(377,8,'5230250615','2555','ภาคปลาย'),(378,8,'5230250623','2555','ภาคปลาย'),(379,8,'5230250631','2555','ภาคปลาย'),(380,8,'5230250798','2555','ภาคปลาย'),(381,8,'5230250810','2555','ภาคปลาย'),(382,8,'5230250844','2555','ภาคปลาย'),(383,8,'5230250861','2555','ภาคปลาย'),(384,8,'5230250879','2555','ภาคปลาย'),(385,8,'5230250925','2555','ภาคปลาย'),(386,8,'5230251174','2555','ภาคปลาย'),(387,8,'5230251212','2555','ภาคปลาย'),(388,9,'51370260','2555','ภาคปลาย'),(389,9,'51371078','2555','ภาคปลาย'),(390,9,'51371904','2555','ภาคปลาย'),(391,9,'5230200073','2555','ภาคปลาย'),(392,9,'5230200111','2555','ภาคปลาย'),(393,9,'5230200391','2555','ภาคปลาย'),(394,9,'5230201011','2555','ภาคปลาย'),(395,9,'5230250101','2555','ภาคปลาย'),(396,9,'5230250232','2555','ภาคปลาย'),(397,9,'5230250275','2555','ภาคปลาย'),(398,9,'5230250283','2555','ภาคปลาย'),(399,9,'5230250330','2555','ภาคปลาย'),(400,9,'5230250364','2555','ภาคปลาย'),(401,9,'5230250470','2555','ภาคปลาย'),(402,9,'5230250577','2555','ภาคปลาย');
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
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `score_rating`
--

LOCK TABLES `score_rating` WRITE;
/*!40000 ALTER TABLE `score_rating` DISABLE KEYS */;
INSERT INTO `score_rating` VALUES (1,6,80,70,60,50,30,30,5,5,10,5,5,10,75,65,55,45);
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
) ENGINE=InnoDB AUTO_INCREMENT=760 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `score`
--

LOCK TABLES `score` WRITE;
/*!40000 ALTER TABLE `score` DISABLE KEYS */;
INSERT INTO `score` VALUES (682,356,20,30,5,5,5,5,5),(714,357,30,20,5,5,5,5,5),(715,358,0,0,0,0,0,0,0),(716,359,15,15,5,5,5,5,5),(717,360,0,0,0,0,0,0,0),(718,361,0,0,0,0,0,0,0),(719,362,0,0,0,0,0,0,0),(720,363,0,0,0,0,0,0,0),(721,364,0,0,0,0,0,0,0),(722,365,0,0,0,0,0,0,0),(723,366,0,0,0,0,0,0,0),(724,367,0,0,0,0,0,0,0),(725,368,0,0,0,0,0,0,0),(726,369,0,0,0,0,0,0,0),(727,370,0,0,0,0,0,0,0),(728,371,0,0,0,0,0,0,0),(729,372,0,0,0,0,0,0,0),(730,373,0,0,0,0,0,0,0),(731,374,0,0,0,0,0,0,0),(732,375,0,0,0,0,0,0,0),(733,376,0,0,0,0,0,0,0),(734,377,0,0,0,0,0,0,0),(735,378,0,0,0,0,0,0,0),(736,379,0,0,0,0,0,0,0),(737,380,0,0,0,0,0,0,0),(738,381,0,0,0,0,0,0,0),(739,382,0,0,0,0,0,0,0),(740,383,0,0,0,0,0,0,0),(741,384,0,0,0,0,0,0,0),(742,385,0,0,0,0,0,0,0),(743,386,0,0,0,0,0,0,0),(744,387,0,0,0,0,0,0,0),(745,388,0,0,0,0,0,0,0),(746,389,0,0,0,0,0,0,0),(747,390,0,0,0,0,0,0,0),(748,391,0,0,0,0,0,0,0),(749,392,0,0,0,0,0,0,0),(750,393,0,0,0,0,0,0,0),(751,394,0,0,0,0,0,0,0),(752,395,0,0,0,0,0,0,0),(753,396,0,0,0,0,0,0,0),(754,397,0,0,0,0,0,0,0),(755,398,0,0,0,0,0,0,0),(756,399,0,0,0,0,0,0,0),(757,400,0,0,0,0,0,0,0),(758,401,0,0,0,0,0,0,0),(759,402,0,0,0,0,0,0,0);
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
INSERT INTO `student` VALUES ('51370039','เกียรติศักดิ์ ศรียันยงค์','S06','dfdsf'),('51370211','รพีพงษ์ กวีกุลพิพัฒน์','S06',''),('51370260','วุฒินันท์ คงศรี','S06',''),('51371078','ภาณุกร เพ็ชรดี','S06',''),('51371904','วิระพงษ์ แสงสุวรรณ์','S06',''),('5230200073','กฤษณ์ ศรีสวัสดิ์','S05',''),('5230200111','กุลดิลก เวชประสิทธิ์','S05',''),('5230200391','ทรงพล จันทองทิพย์','S05',''),('5230201011','สุกฤษฏิ์ บุญกาญจน์วนิชา','S05',''),('5230250101','จิราภรณ์ ศุภอรรถสิทธิ์','S06',''),('5230250127','ชนัฎดา ช่างไม้','S06','dfsdfds'),('5230250135','ชยินทร์ จันทร์สัมฤทธิ์','S06',''),('5230250143','ชลชาติ นุ่มสารพัดนึก','S06',''),('5230250178','ณัชพล เครือทิม','S06',''),('5230250186','ณัชพล ศรหิรัญ','S06',''),('5230250224','ทอทอง ทองธรรมชาติ','S06',''),('5230250232','ทิพย์วรรณ นพวรรณ','S06',''),('5230250259','นภาวรรณ ไพรวัลย์','S06',''),('5230250275','เนาวรัตน์ สวัสดิ์พิพัฒน์ผล','S06',''),('5230250283','บุษกร ชักนำ','S06',''),('5230250291','ปพน เลิศชาคร','S06',''),('5230250313','ปิยภัทร ช่วยชาติ','S06',''),('5230250330','ภาณิกา แสนจันทร์','S06',''),('5230250348','ภิญโญ งามเสถียร','S06',''),('5230250364','มัทณา มะโนรมย์','S06',''),('5230250372','ยุวดี แสงเงิน','S06',''),('5230250381','รัฐพล ทรัพย์คล้าย','S06',''),('5230250399','เลิศฤทธิ์ กมลศิลป์','S06',''),('5230250437','สมจินตนา ถนอมศิลป์','S06',''),('5230250445','สมเดช เพิ่มพูล','S06',''),('5230250470','สิทธิศักดิ์ บุญแก้ว','S06',''),('5230250496','สุพรรษา ทอระหัน','S06',''),('5230250500','สุภัสสรา พึ่งพันธ์','S06',''),('5230250518','ดวงกมล ตั้งกิจธรรมกุล','S06',''),('5230250542','อาชา ยิ้มโสภา','S06',''),('5230250551','อิทธิพล แก้วประเสริฐ','S06',''),('5230250577','กษิดิศ ขวัญละมูล','S06',''),('5230250607','ขนิษฐา ทิพย์ศรี','S06',''),('5230250615','ขวัญชนก หนูคง','S06',''),('5230250623','คงศักดิ์ ภาเภา','S06',''),('5230250631','จันทร์จิฬา ชินโท','S06',''),('5230250798','ธีรพล ชาญธนะชัยกุล','S06',''),('5230250810','นิธิพล สากร','S06',''),('5230250844','ปภาวิน เดชดำรง','S06',''),('5230250861','พงศ์สิริ เอี่ยมสำอางค์','S06',''),('5230250879','พนิดา สุราวุธ','S06',''),('5230250925','พูนศักดิ์ ราชกิจ','S06',''),('5230251174','สุวรรณภูมิ คุปตะวาณิช','S06',''),('5230251212','อรรถพงศ์ คล้ายมิตร','S06',''),('5330200041','เครือวัลย์ มุขแก้ว','S05',''),('5330200105','เสาวภา โปร่งอากาศ','S05',''),('5330200121','เอกนรินทร์ ศิริทรัพย์','S05',''),('5330200164','กมลวรรณ ศรีเวียง','S05',''),('5330200245','จีรพร สวัสดิรักษาสิทธิ์','S05',''),('5330200288','ชนิสรา ศรีสมุทร','S05',''),('5330200300','ชลธิชา พุ่มสำเภา','S05',''),('5330200393','ณัฐวดี สารนพคุณ','S05',''),('5330200652','พรพรรณ นิลเทพี','S05',''),('5330200709','ภาคิน ฉั่วเจริญ','S05',''),('5330200903','สิทธิศักดิ์ ศรีสิงห์','S05',''),('5330201004','พัฒณียา ขวัญเต่า','S05',''),('5330250013','ธนพร ผลเจริญ','S06',''),('5330250021','ธนวัตร บัวนุช','S06',''),('5330250030','มนทิรา เรืองศรี','S06',''),('5330250048','กัญจ์นภูมิ พันธ์สุข','S06',''),('5330250056','อนุวัฒน์ กลิ่นประยูร','S06',''),('5330250064','สุรเกียรติ นาใจ','S06',''),('5330250072','สุรางค์รัตน์ คำแหง','S06',''),('5330250102','ธนวัฒน์ มาระวิชะโย','S06',''),('5330250111','ชัยวัฒน์ สอดสี','S06',''),('5330250137','ปรียาพัชร์ อติหฤทัยสุข','S06',''),('5330250145','คมสัน บุญพลบ','S06',''),('5330250153','ฐิติพงศ์ พัฒนโภครัตนา','S06',''),('5330250161','กรกฎ มณีวรรณ','S06',''),('5330250196','ปฏิภาณ ศิริไสย','S06',''),('5330250200','สุภัชชา จารุบุญญากร','S06',''),('5330250218','ธันณภัค สุวะพัฒน์','S06',''),('5330250226','นิรันดร์ เลิศปรัชญากุล','S06',''),('5330250234','ณัฏฐา แพรุ่งโรจน์ทวี','S06',''),('5330250242','นภดล อยู่บุญ','S06',''),('5330250251','พรสวรรค์ ยังมี','S06',''),('5330250277','พลอยไพลิน กำลังหาญ','S06',''),('5330250285','สิทธิพงษ์ พุทธิสารสิชฌน์','S06',''),('5330250315','ธัญธร ครองบุญ','S06',''),('5330250331','อารยา พวงรอด','S06',''),('5330250358','สุรวดี มีสุข','S06',''),('5330250374','นภัสนันท์ วงศ์กระพันธุ์','S06',''),('5330250412','ฉรัฐดา ไชยดี','S06',''),('5330250439','รัฐพล ธนเศรษฐกร','S06',''),('5330250455','ธนโชติ กิตติมหาชัย','S06',''),('5330250463','ศรัณย์ บัวไสว','S06',''),('5330250471','ณัฐชา ชนาวรรธน์สกุล','S06',''),('5330250480','เฉลิมพร ทิพย์เกศสุดา','S06',''),('5330250498','สุนันทา นะวงค์','S06',''),('5330250587','ฐาปกรณ์ ฉั่วบันลือ','S06',''),('5330250650','ภูริพันธ์ สืบเชื้อ','S06',''),('5330250731','ชุติพงศ์ มณีตัน','S06',''),('5330250790','เสกข์ โสดานิล','S06',''),('5330250811','นราวัชร์ จันทร์แสน','S06',''),('5330250889','ภาวินี อรุณผาติ','S06','');
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
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `checkin_date`
--

LOCK TABLES `checkin_date` WRITE;
/*!40000 ALTER TABLE `checkin_date` DISABLE KEYS */;
INSERT INTO `checkin_date` VALUES (7,'1/23/2013',6),(8,'1/21/2013',6),(9,'1/23/2013',7);
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
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teaching`
--

LOCK TABLES `teaching` WRITE;
/*!40000 ALTER TABLE `teaching` DISABLE KEYS */;
INSERT INTO `teaching` VALUES (6,9,8,'2555','ภาคปลาย'),(7,9,9,'2555','ภาคปลาย');
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
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subject`
--

LOCK TABLES `subject` WRITE;
/*!40000 ALTER TABLE `subject` DISABLE KEYS */;
INSERT INTO `subject` VALUES (8,'01418443','Web Technology and Webservice ','870','880'),(9,'01418443','Web Technology and Webservice ','870','881');
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

-- Dump completed on 2013-01-28 23:08:15
