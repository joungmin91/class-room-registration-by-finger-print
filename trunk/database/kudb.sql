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
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `checkin`
--

LOCK TABLES `checkin` WRITE;
/*!40000 ALTER TABLE `checkin` DISABLE KEYS */;
INSERT INTO `checkin` VALUES (22,450,'2/10/2013','normal'),(23,450,'2/6/2013','normal');
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
) ENGINE=InnoDB AUTO_INCREMENT=544 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `registration`
--

LOCK TABLES `registration` WRITE;
/*!40000 ALTER TABLE `registration` DISABLE KEYS */;
INSERT INTO `registration` VALUES (450,8,'5230250127','2555','ภาคปลาย'),(451,8,'5230250135','2555','ภาคปลาย'),(452,8,'5230250143','2555','ภาคปลาย'),(453,8,'5230250178','2555','ภาคปลาย'),(454,8,'5230250186','2555','ภาคปลาย'),(455,8,'5230250224','2555','ภาคปลาย'),(456,8,'5230250259','2555','ภาคปลาย'),(457,8,'5230250291','2555','ภาคปลาย'),(458,8,'5230250313','2555','ภาคปลาย'),(459,8,'5230250348','2555','ภาคปลาย'),(460,8,'5230250372','2555','ภาคปลาย'),(461,8,'5230250381','2555','ภาคปลาย'),(462,8,'5230250399','2555','ภาคปลาย'),(463,8,'5230250437','2555','ภาคปลาย'),(464,8,'5230250445','2555','ภาคปลาย'),(465,8,'5230250496','2555','ภาคปลาย'),(466,8,'5230250500','2555','ภาคปลาย'),(467,8,'5230250518','2555','ภาคปลาย'),(468,8,'5230250542','2555','ภาคปลาย'),(469,8,'5230250551','2555','ภาคปลาย'),(470,8,'5230250607','2555','ภาคปลาย'),(471,8,'5230250615','2555','ภาคปลาย'),(472,8,'5230250623','2555','ภาคปลาย'),(473,8,'5230250631','2555','ภาคปลาย'),(474,8,'5230250798','2555','ภาคปลาย'),(475,8,'5230250810','2555','ภาคปลาย'),(476,8,'5230250844','2555','ภาคปลาย'),(477,8,'5230250861','2555','ภาคปลาย'),(478,8,'5230250879','2555','ภาคปลาย'),(479,8,'5230250925','2555','ภาคปลาย'),(480,8,'5230251174','2555','ภาคปลาย'),(481,8,'5230251212','2555','ภาคปลาย'),(482,11,'51370260','2555','ภาคปลาย'),(483,11,'51371078','2555','ภาคปลาย'),(484,11,'51371904','2555','ภาคปลาย'),(485,11,'5230200073','2555','ภาคปลาย'),(486,11,'5230200111','2555','ภาคปลาย'),(487,11,'5230200391','2555','ภาคปลาย'),(488,11,'5230201011','2555','ภาคปลาย'),(489,11,'5230250101','2555','ภาคปลาย'),(490,11,'5230250232','2555','ภาคปลาย'),(491,11,'5230250275','2555','ภาคปลาย'),(492,11,'5230250283','2555','ภาคปลาย'),(493,11,'5230250330','2555','ภาคปลาย'),(494,11,'5230250364','2555','ภาคปลาย'),(495,11,'5230250470','2555','ภาคปลาย'),(496,11,'5230250577','2555','ภาคปลาย'),(497,12,'5230250127','2555','ภาคปลาย'),(498,12,'5230250135','2555','ภาคปลาย'),(499,12,'5230250143','2555','ภาคปลาย'),(500,12,'5230250178','2555','ภาคปลาย'),(501,12,'5230250186','2555','ภาคปลาย'),(502,12,'5230250224','2555','ภาคปลาย'),(503,12,'5230250259','2555','ภาคปลาย'),(504,12,'5230250291','2555','ภาคปลาย'),(505,12,'5230250313','2555','ภาคปลาย'),(506,12,'5230250348','2555','ภาคปลาย'),(507,12,'5230250372','2555','ภาคปลาย'),(508,12,'5230250381','2555','ภาคปลาย'),(509,12,'5230250399','2555','ภาคปลาย'),(510,12,'5230250437','2555','ภาคปลาย'),(511,12,'5230250445','2555','ภาคปลาย'),(512,12,'5230250496','2555','ภาคปลาย'),(513,12,'5230250500','2555','ภาคปลาย'),(514,12,'5230250518','2555','ภาคปลาย'),(515,12,'5230250542','2555','ภาคปลาย'),(516,12,'5230250551','2555','ภาคปลาย'),(517,12,'5230250607','2555','ภาคปลาย'),(518,12,'5230250615','2555','ภาคปลาย'),(519,12,'5230250623','2555','ภาคปลาย'),(520,12,'5230250631','2555','ภาคปลาย'),(521,12,'5230250798','2555','ภาคปลาย'),(522,12,'5230250810','2555','ภาคปลาย'),(523,12,'5230250844','2555','ภาคปลาย'),(524,12,'5230250861','2555','ภาคปลาย'),(525,12,'5230250879','2555','ภาคปลาย'),(526,12,'5230250925','2555','ภาคปลาย'),(527,12,'5230251174','2555','ภาคปลาย'),(528,12,'5230251212','2555','ภาคปลาย'),(529,12,'51370260','2555','ภาคปลาย'),(530,12,'51371078','2555','ภาคปลาย'),(531,12,'51371904','2555','ภาคปลาย'),(532,12,'5230200073','2555','ภาคปลาย'),(533,12,'5230200111','2555','ภาคปลาย'),(534,12,'5230200391','2555','ภาคปลาย'),(535,12,'5230201011','2555','ภาคปลาย'),(536,12,'5230250101','2555','ภาคปลาย'),(537,12,'5230250232','2555','ภาคปลาย'),(538,12,'5230250275','2555','ภาคปลาย'),(539,12,'5230250283','2555','ภาคปลาย'),(540,12,'5230250330','2555','ภาคปลาย'),(541,12,'5230250364','2555','ภาคปลาย'),(542,12,'5230250470','2555','ภาคปลาย'),(543,12,'5230250577','2555','ภาคปลาย');
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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `score_rating`
--

LOCK TABLES `score_rating` WRITE;
/*!40000 ALTER TABLE `score_rating` DISABLE KEYS */;
INSERT INTO `score_rating` VALUES (3,11,75,65,55,45,30,40,10,10,0,0,0,10,70,60,50,35,'รายงาน','การบ้าน','','','','grade',0,1),(4,13,80,70,58,46,30,30,10,0,0,0,0,10,76,64,52,40,'รายงาน','','','','','group',20,0);
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
) ENGINE=InnoDB AUTO_INCREMENT=901 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `score`
--

LOCK TABLES `score` WRITE;
/*!40000 ALTER TABLE `score` DISABLE KEYS */;
INSERT INTO `score` VALUES (807,450,30,40,10,10,0,0,0),(808,451,0,0,0,0,0,0,0),(809,452,0,0,0,0,0,0,0),(810,453,0,0,0,0,0,0,0),(811,454,0,0,0,0,0,0,0),(812,455,0,0,0,0,0,0,0),(813,456,0,0,0,0,0,0,0),(814,457,0,0,0,0,0,0,0),(815,458,0,0,0,0,0,0,0),(816,459,0,0,0,0,0,0,0),(817,460,0,0,0,0,0,0,0),(818,461,0,0,0,0,0,0,0),(819,462,0,0,0,0,0,0,0),(820,463,0,0,0,0,0,0,0),(821,464,0,0,0,0,0,0,0),(822,465,0,0,0,0,0,0,0),(823,466,0,0,0,0,0,0,0),(824,467,0,0,0,0,0,0,0),(825,468,0,0,0,0,0,0,0),(826,469,0,0,0,0,0,0,0),(827,470,0,0,0,0,0,0,0),(828,471,0,0,0,0,0,0,0),(829,472,0,0,0,0,0,0,0),(830,473,0,0,0,0,0,0,0),(831,474,0,0,0,0,0,0,0),(832,475,0,0,0,0,0,0,0),(833,476,0,0,0,0,0,0,0),(834,477,0,0,0,0,0,0,0),(835,478,0,0,0,0,0,0,0),(836,479,0,0,0,0,0,0,0),(837,480,0,0,0,0,0,0,0),(838,481,0,0,0,0,0,0,0),(839,497,0,0,0,0,0,0,0),(840,498,0,0,0,0,0,0,0),(841,499,0,0,0,0,0,0,0),(842,500,0,0,0,0,0,0,0),(843,501,0,0,0,0,0,0,0),(844,502,0,0,0,0,0,0,0),(845,503,0,0,0,0,0,0,0),(846,504,0,0,0,0,0,0,0),(847,505,0,0,0,0,0,0,0),(848,506,0,0,0,0,0,0,0),(849,507,0,0,0,0,0,0,0),(850,508,0,0,0,0,0,0,0),(851,509,0,0,0,0,0,0,0),(852,510,0,0,0,0,0,0,0),(853,511,0,0,0,0,0,0,0),(854,512,0,0,0,0,0,0,0),(855,513,0,0,0,0,0,0,0),(856,514,0,0,0,0,0,0,0),(857,515,0,0,0,0,0,0,0),(858,516,0,0,0,0,0,0,0),(859,517,0,0,0,0,0,0,0),(860,518,0,0,0,0,0,0,0),(861,519,0,0,0,0,0,0,0),(862,520,0,0,0,0,0,0,0),(863,521,0,0,0,0,0,0,0),(864,522,0,0,0,0,0,0,0),(865,523,0,0,0,0,0,0,0),(866,524,0,0,0,0,0,0,0),(867,525,0,0,0,0,0,0,0),(868,526,0,0,0,0,0,0,0),(869,527,0,0,0,0,0,0,0),(870,528,0,0,0,0,0,0,0),(871,529,0,0,0,0,0,0,0),(872,530,0,0,0,0,0,0,0),(873,531,0,0,0,0,0,0,0),(874,532,0,0,0,0,0,0,0),(875,533,0,0,0,0,0,0,0),(876,534,0,0,0,0,0,0,0),(877,535,0,0,0,0,0,0,0),(878,536,0,0,0,0,0,0,0),(879,537,0,0,0,0,0,0,0),(880,538,0,0,0,0,0,0,0),(881,539,0,0,0,0,0,0,0),(882,540,0,0,0,0,0,0,0),(883,541,0,0,0,0,0,0,0),(884,542,0,0,0,0,0,0,0),(885,543,0,0,0,0,0,0,0),(886,482,0,0,0,0,0,0,0),(887,483,0,0,0,0,0,0,0),(888,484,0,0,0,0,0,0,0),(889,485,0,0,0,0,0,0,0),(890,486,0,0,0,0,0,0,0),(891,487,0,0,0,0,0,0,0),(892,488,0,0,0,0,0,0,0),(893,489,0,0,0,0,0,0,0),(894,490,0,0,0,0,0,0,0),(895,491,0,0,0,0,0,0,0),(896,492,0,0,0,0,0,0,0),(897,493,0,0,0,0,0,0,0),(898,494,0,0,0,0,0,0,0),(899,495,0,0,0,0,0,0,0),(900,496,0,0,0,0,0,0,0);
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
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `checkin_date`
--

LOCK TABLES `checkin_date` WRITE;
/*!40000 ALTER TABLE `checkin_date` DISABLE KEYS */;
INSERT INTO `checkin_date` VALUES (12,'2/10/2013',11),(13,'2/8/2013',11),(14,'2/7/2013',11),(15,'2/6/2013',11);
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
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teaching`
--

LOCK TABLES `teaching` WRITE;
/*!40000 ALTER TABLE `teaching` DISABLE KEYS */;
INSERT INTO `teaching` VALUES (11,9,8,'2555','ภาคปลาย'),(12,9,11,'2555','ภาคปลาย'),(13,9,12,'2555','ภาคปลาย'),(14,10,8,'2555','ภาคปลาย');
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
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subject`
--

LOCK TABLES `subject` WRITE;
/*!40000 ALTER TABLE `subject` DISABLE KEYS */;
INSERT INTO `subject` VALUES (8,'01418443','Web Technology and Webservice ','870','880'),(11,'01418443','Web Technology and Webservice ','870','881'),(12,'01418443','Web Technology and Webservice ','870','');
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

-- Dump completed on 2013-02-10 15:43:32