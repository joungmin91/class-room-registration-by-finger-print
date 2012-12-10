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
  `sub_id` varchar(25) NOT NULL,
  `std_id` varchar(25) NOT NULL,
  `chkin_year` varchar(10) NOT NULL,
  `chkin_date` varchar(45) NOT NULL,
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
INSERT INTO `checkin` VALUES ('01418332','51370039','2555','12/10/2012'),('01418332','51370039','2555','12/6/2012'),('01418332','51370211','2555','12/10/2012'),('01418332','51370211','2555','12/7/2012'),('01418332','5330200041','2555','12/10/2012'),('01418332','5330200041','2555','12/6/2012'),('01418332','5330200041','2555','12/7/2012'),('01418332','5330200041','2555','12/8/2012'),('01418332','5330200105','2555','12/10/2012'),('01418332','5330200105','2555','12/5/2012'),('01418332','5330200105','2555','12/8/2012'),('01418332','5330200121','2555','12/10/2012'),('01418332','5330200288','2555','12/10/2012'),('01418332','5330250811','2555','12/9/2012'),('01418332','5330250889','2555','12/9/2012');
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
  `sub_id` varchar(25) NOT NULL,
  `std_id` varchar(25) NOT NULL,
  `year` varchar(10) NOT NULL,
  PRIMARY KEY (`reg_id`,`sub_id`,`std_id`,`year`),
  KEY `sub_id` (`sub_id`),
  KEY `std_id` (`std_id`),
  CONSTRAINT `std_id` FOREIGN KEY (`std_id`) REFERENCES `student` (`std_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `sub_id` FOREIGN KEY (`sub_id`) REFERENCES `subject` (`sub_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=54 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `registration`
--

LOCK TABLES `registration` WRITE;
/*!40000 ALTER TABLE `registration` DISABLE KEYS */;
INSERT INTO `registration` VALUES (1,'01418332','51370039','2555'),(2,'01418332','51370211','2555'),(3,'01418332','5330200041','2555'),(4,'01418332','5330200105','2555'),(5,'01418332','5330200121','2555'),(6,'01418332','5330200164','2555'),(7,'01418332','5330200245','2555'),(8,'01418332','5330200288','2555'),(9,'01418332','5330200300','2555'),(10,'01418332','5330200393','2555'),(11,'01418332','5330200652','2555'),(12,'01418332','5330200709','2555'),(13,'01418332','5330200903','2555'),(14,'01418332','5330201004','2555'),(15,'01418332','5330250013','2555'),(16,'01418332','5330250021','2555'),(17,'01418332','5330250030','2555'),(18,'01418332','5330250048','2555'),(19,'01418332','5330250056','2555'),(20,'01418332','5330250064','2555'),(21,'01418332','5330250072','2555'),(22,'01418332','5330250102','2555'),(23,'01418332','5330250111','2555'),(24,'01418332','5330250137','2555'),(25,'01418332','5330250145','2555'),(26,'01418332','5330250153','2555'),(27,'01418332','5330250161','2555'),(28,'01418332','5330250196','2555'),(29,'01418332','5330250200','2555'),(30,'01418332','5330250218','2555'),(31,'01418332','5330250226','2555'),(32,'01418332','5330250234','2555'),(33,'01418332','5330250242','2555'),(34,'01418332','5330250251','2555'),(35,'01418332','5330250277','2555'),(36,'01418332','5330250285','2555'),(37,'01418332','5330250315','2555'),(38,'01418332','5330250331','2555'),(39,'01418332','5330250358','2555'),(40,'01418332','5330250374','2555'),(41,'01418332','5330250412','2555'),(42,'01418332','5330250439','2555'),(43,'01418332','5330250455','2555'),(44,'01418332','5330250463','2555'),(45,'01418332','5330250471','2555'),(46,'01418332','5330250480','2555'),(47,'01418332','5330250498','2555'),(48,'01418332','5330250587','2555'),(49,'01418332','5330250650','2555'),(50,'01418332','5330250731','2555'),(51,'01418332','5330250790','2555'),(52,'01418332','5330250811','2555'),(53,'01418332','5330250889','2555');
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
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `score`
--

LOCK TABLES `score` WRITE;
/*!40000 ALTER TABLE `score` DISABLE KEYS */;
INSERT INTO `score` VALUES (1,25,1,NULL,1),(2,30,2,'',1),(3,10,3,'',1),(4,5,4,'',1),(5,0,5,'',1),(6,0,6,'',1),(7,0,7,'',1),(8,0,8,'',1),(9,15,1,'',6),(10,20,2,'',6),(11,9,3,'',6),(12,0,4,'',6),(13,0,5,'',6),(14,0,6,'',6),(15,0,7,'',6),(16,0,8,'',6);
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
INSERT INTO `student` VALUES ('51370039','เกียรติศักดิ์ ศรียันยงค์','S06','mspZ1p6WoaE6wRJXLiSBCkKFU8EFDpGGAQSUl2ABBxWgdMEFlxKBQQMfEm1BBh2igEEFKr2HgRJQK3UBB58ONUEG6ZZwQQaTOn4BF7IUWEELf7h3QRWlvnPBN5UckAEEJbxnwQydJVfBD4uyRQELKZJGgQh0qjpBFEEUMwEJZiQogQpTi2kBBowNVkEIgDc9AQgukx+BBty+M0EFL8NUwQQewGMBChfLcwENhNN0AQsEzm2BEAWQLAEJZT09QQQuLiTqEZ20Tx4CE0lLS0pHSEAoIyUmJyksLSsrKwITRUVEQkA+Ny8oKCkpLC4wLy4vAhNPUFFRUlZhDBkgIyQnKSkoKCkBE0JBQT8+OjcyLCgnJyktMTQzMzMCE1NVVlhbYm4DEBkfIiQlJiUmJwETQD8+PTo3NC4qJiUmJy0zNzc2NgITVlhbXWJpcQELFBsfISMkJCUlARM+PTo5NzUxLSklJCMkKzc9PTk4AhNXW15hZ2xydwcPFxsgISIiIyMBEzs6ODY0MjAtKSUjIR0dRkdDPjsCElldYGVqb3MBBw8VGh0gISEiARM4NzUzMjAvKycjIRwUB2lUSUJBAhJcXmJobnJ1AgcPFBgcHR8gIQETNTQzMTAuLCckIh0YDwRvXlFKRgISXmBkam90dwQJDxQXGhwfICIBEzMxLy8uLCklIiAbFg4DcWNYUUwDEmNobHB0AQUKDxMXGhwfISIBEzAuLCwrKSYkIR8aFg4EcWZeV1MDEmRpbHB0AQUKDxMXGhwfISICEyomJyYlIyEfHBkVDQR0a2RdWAQRaWxxdAEFCQ8TFxocHyADEiMkJCIhHx0cGRQOBnZvaGMY+C8ZNKlQFCEyKd2ZS8r136DbXM7o5IvSKxSm8U3FOGdJ6Cz7972ccD7tqmQrCtDTs8PF9/Czn2PtOKvtqiACrnKT8qSZ0NNNUdVKsVGHNCjDP8uNfeGM0qlLOb3hfL++mqBJ6ixhYXQW/VR3xJV5f2Y2CClAdMverxBvQoFmFfq7eqY0O9CAN+nWZqyifQ/erCzTfHBHgBEGZUH2xdBGFYKBborSVUFRxFRWaVNa0FU1oNtRmC4fn5//hR5mLy4FYKsDrASB5JQs7Gzuj3g/4W+ZtjcqR3+MCvgfXwyRIEyUi7Gj7ylttzT2pjbHzZ/eC75C4Siu3mttK4wloPCCq1Z3Lz6htUAJrbN+XsCeFMOxlLHSNQaerAQ+N6By7lbURpdg69wQZLs1auawlA2rFJn8/kNkDsf6LOx3'),('51370211','รพีพงษ์ กวีกุลพิพัฒน์','S06','mspZlqvOpM88wQks0EXBCiNHPcEILshCQQksvFlBGqW9XkEOtD9YASigpj5BEmUpQ0EXYLR1AQcsx4RBEDg9PgEKNhBygQUZnYrBBRiza4EHL0txQRRUJYoBBSEQPkEGAp1oAQSRvngBCjOvk0EEljOKAQgfFVSBBRIkYQEGjrdiAQo3SUqBDCa1UUFTJT+KwQsiwEdBDya8aIEKOTY6gQxEvBxBCkauWcEWiqdSQRR/uiUBCkWmKkEHWR8uwQlnNTEBDUeVQkEIdjVdAROXNFaBIn+YekEBlRMzAQVvRGFBSMGZIgEF4hYcgQPhEx4BBWoKUsEHh4Y4gQl5hmkBBYs6g8EJJy50TRS6xHAXAhNYWVtcXmNsdw4bJCUlJSMhICACE1VWVldYXGFxDSAoKSgmIx8dHQITXF1fYWRqcgMOGiEiIyQiIB8fAhNRUlJTU1NWYhcmLS0rKCMfHBsCE19hZGdrcHYGDhccICEiIR8cGwITT09OTEtKSUQ3MDMyLyolHx0bAhNiZGhrb3MBBw4VGx0fIB0bGRcCE0tLSEZDQT44NTY3NjArJSAdGwISZGZqbnJ1AwgOFBkbHB0bGxoCE0dGQ0E/PTcyMDk7OjQuJyEdGwISaGlsb3N2AwgNExgaGxsaGhoCE0RCPz07ODEqIztAPjcyKyQhHQISa2xvcXN2AwcMERYYGRgYGhsCE0E/PTo5Ni8mHS1GQTs3MiomIgISb29xcnR2AwcNDxQWFxcXGRsCEj87Ojg3NC0iGQpbSEE9NzAqAhFwcnN0dQEECA8QExQVFRYYAhI9Ojk3NjMxLSQPaVNJREE9NwMRcnR1dwMHDBESExQVFhcZAxE0NTQ1MzItJRF2XlRPS0kEEHR3AwYKDRITFBQVFhcEEDQ0NDIyMCoZd1xTUEsY+C8ZNKlQFCEBKsE2a9Kk6x92SSimFcKB1nd0f8nq5j00T4Mrtk8bKO4H6yfduLS9J0DLebnhTbjp/oXuDCgMETbmhID9cks4RaL3vmZM7pbPxPN83vbIFV8NZdKRxdkMXrwY1Z+8WtAZnIkN2HkLBKPdZbrGQ2q9DoPV9tRUQU3g3DGzx3GgoonS/smD9J/GLW8siMo7Mqq2dDuyUgzd8XkFh485VyEwwzCyUmSlZBYW3temsUDBHDbZSj5Xi09UuMke+wrwjY1Axu0f+AjbnPkdEh8MqbHv91L92wnm9GB3C/3yec6vN9o8nlu+alj2AmGu6EECegmq9UMbJnEoHD5ODN+huq6kN9hiqJ/sWDW1IW5EeWIb9TUumxV2OrYcDyqDBfO0a+SwdKRqQ7slb3AV6J6ArQk3IA13'),('5330200041','เครือวัลย์ มุขแก้ว','S05','mspZlpnpuzY/gQctRFEBLhPGTQEgH0pNwSYZTU2BJhpJRoEKq0tFAQmiNFGBF7O1TQETqrZVwQ+8u0xBEKQ8UQEirT1AAQcrQD6BByq6dkEINL1wQQY5QFeBY8LAWsE+wqBRQVtQoVLBQUGoXkEJNjhkQQpBr2YBBztBZ4ELSqBTAWQlpE+BF0lERoEMpBtYASEbJmzBCTGuVsEFRUBIwQakEWDBDBAdfUEGmilTAQw/OkTBBqYaYAEMHtJFwRuiu1NBHMG+PkEIqzBSQQe4mEABDNUkL8EEv6U8gQO8pDhBA0QkKwEERMlJgRMuik5BDgGLdUEGjLQlAQKzyTnBBaYTaQEFhwQ2gQfZC1RBDnmJZ4EIEh0mwQdKBUvBCWiGacEHhpl/gQogSPSHFAIQRUREQkFBQUA9NzUzMTEwAxBCQT8+Pj4+PTs4NjQzMgIQRkVFRENERkM6MS8uLS0tAxBAQD09Ozo9Pz87NzQzMgIQSklIR0ZIS0s3KCgoKCkrAw8+PTo6ODY6QkM+ODY0AxBMS0pJTFJbAx0iIyQlJwMPOzo5NzUyMEFEQDo3NAMQT05NTFBYZXYSGx0fISMDDjg3NTQyMC89REI+OgMQUVFQUlZeanUKFhkbHR8EDjUzMjEwLTFGRUE+AxBTVFRWW2FsdgkSFxkaHAQOMTAwLjArJD1GREMDEFVWV1leY2x3CBAWGRodBA0uLS0tLyggHUVGAw9WV1ldYWZtdgcOFBgaBQstLS4vKCIhAw9VV1ldYmdtdQUMExcaBQswLCsqJB0aBA5XW15jaW51BAwTFwYKKCwkIRkY+C8ZNKlQFCEKJelRZzN0gUKE2JAhoH+uJ0sP1950b5kcwkxq2SYBZMiuvtGg9TvZBwEgWSlpHtCV0mP8W4m8ZY7z+5w3bhuMgsZlRCBDGVB1TxE0mexiKQJGWfAQudY1CPxCSoL1wRGKU0s62uWmh0lsh6o4yTZgnCsBFaTvuPd03na3BzmkHgeb94eo4NOusUpVZInltSwFWJ+jEt85g/O0yYpM+KsvuLiZKcZUwiI5xMPwyXN0w8jBfT4XgwqgLxLxxfQ6Wy17xe/CuWkGXZIxwUrGE5gop/GtM8B//MNsxNHcrFFuoQvZHF6xJ0a5Nb1IBKlzQD2j/S5s1fKMwN1z8WG21v0ApI4EtRTJO8gFzMtwZWd3TppCCranCZb5p3nN8uzROo19ktdwQys2yK6AH81mpHrMirp3'),('5330200105','เสาวภา โปร่งอากาศ','S05','mspZVqGil79KgQ+rwE9BH7nGaIEJWEhwgQZPDGFBCGMWO8EJyLN5wQpELi6BBUI+IkEFQE5YgRR20zqBEJisboEgRslLwSMEU2xBCcydNIEGR6cgwQZJuVHBDblFPsEKLcx5gQVPICaBBMOgRYELyxtzQQsJD1xBB90cY0EQ5wlegQjlLECBA7m3ZUEJvxFtwQnvoDoBBMANS8EHXC+IgQo3w4sBA0eUj0EGERWLAQWBjnhBBwWle8EQJaB3wRAUmY3BCxRKmQEFR5Z+wQYIRjQKHLr0UBQCE0tJSEVEQ0NFSEtRSDQsKyorLQITS0lHREJAQEJERklEPTc0MjEzAhNLSUhGRkVHSk5SWWkVHyIjJScCE0pJRkNAPj5AQUNGRUE+OTc2NgITSklJR0dGS1BVWGNzCBQZGx8hAhNHR0RBPj07PkBDR0dFQT07OjoCE0pKSklISU9VWV5pdAUNEhYYHAETRkZFQj89Ojk7QEZJSUZEQT8+PgITS0tLS0pMU1hdYmpzAggMEBQaARNGRUNAPjo3NTlBSkxLSUZEQ0JBAhJMTE1LS1BVW19ka3IBBgkNDwETRURBPjo3MzA0RFNPTEpJSEZEQwISTE1OTU5TV11gZWtydgQHCg0CE0A+OTY0MCojbF1UTktLSUdFRAISTU1PT1FVWV5iZ2xxdgMHCg0CEzg2My8tKiMTdWRYUU1LSklHRQMST1BRU1dbX2NnbHJ2AwcKDQITMi0qKCclHQt1Z1xUT01LS0lHAxJRUVNVWVxgZGlvdHcEBwsOAhMvJyQiIBwVB3VpYFlTUE5OTUsEEVNUVlldYGRpb3QBBAcLAxIhIB0bFg4Dc2piXFVSUFBPGPgvGTSpUBQhPDfZlTaRm1qyJPMTCGDfWKbqq0jkP2GpBEDVDhvZCLaDJXw7DiHh36JncK5cX3fgNLvg45S5tjtP9DUXRCmfHzYih+baWyIl/mkNQJ1Ftx8ZGVEDYQUvid0U8pjXM7CrRROUSeKX2ycfOyA7kERZS5MTZKZFlDnNrR6BPX1KriHP+jJ179PMjKpocQdyzxVRdhOfz//KmUsHjixzXxD/b7sStEv/Jva7MeorMqv4rdk8PYW8a5K5u9zsO7Qr5S1UJwBVQb15YTk3PIWeY2bD1lLajknRSspkC8DXkiINg7RgKoHiYyKlMjpersSzzbokyeyWuKKKg0hAh9z4RNY4k6C5EYIp5pAywzfSidHi9Gp1x9V26GcdQQZuFIGloLWIYpbRGjVsavRrOByEoSS5L3eGdw=='),('5330200121','เอกนรินทร์ ศิริทรัพย์','S05','mspZVn6BuCJsAQ6KJGaBFIW6WAExRDxbQRs6vlzBDjKaWEEJchw0gQPPI2zBDiA/fUEGLZJKQQ3qHYWBA52bQoEI3pdiQQ5/vnPBAKhHcYEEMiFaQQ8IyFGBAzhSPMEEQMxBQQY9Jk3BE+I4TwEVzaVXwRFwvTqBBkI2QkEGQis9AQjJLEOBCkygQ8EJWKs3AQlKkz/BCFs3XcFWZwhmQQeEm4UBAyU4hK4WAxFESE9QU1dhbwMQGyQmKSgDEURFSktOUlxqAxQgKS0uKwMRSk5SVFZcZXADDxkhJCYnAxFGREVGSEpVYwQaJS0xLy0DEUpQVFdcYGlxAw0XHyIkJgQRSEZDREVNWQgiLDEyMC0DEU5TVVhdYWlyAwsWHCEjJgQRSEZDQUFFRjUtMTMxMC4DEVBTVlldYmtzAwsVGx8gIwQQR0dFQT8/Pjg0MjIwLwMRUlVWWV5jbXUECxMZHB0hBBBCRURCPj07ODY0MS8vAxFTVllcYGVudQQKERYZGyAFEEREQj89Ojg3NDEvLwMQVVhcX2Job3YECQ8UGBwFD0REQT87OTg2NDIxBBBbXmFkanB3BQoPExYdBQ9DQ0E+Ozg2NTMxMAQPW19iZmxyAQcMDxMXBQ5CQT89Ojg2NDEwBQ5gY2hscwIJDQ8TBg1APz06NzUyLxj4Lxk0qVAUIRgu5j7DmCIZjdsENnDc1BZsEpUqGiDKSLs95DNqhImVCxeWcA/3NfbP2t+tI89J7ywv2P+Bd8dWifbnk0wzqlRU8//t7A5RRkuem2ocd7fy0PI+hAWccNzBNbGHCmyrXYwYkeF9Ep0ugII8qMvNR9ddkPkL7NCPslVyyJnCMCS67hVK+SKXfm+WANyndKP6N2mdBoZQGKCAF46kTE6J9SVyQAFrFZZAYq3JlbazkTd7tEstEimHpt9xOflfXvC1c86yn0szELUUThobE7NE8la2HRrGiJrBpzexJRST4swJsgeWYtW5HT23xYcKrcbcHhu4E3PX0YBMJTeGNI+R4+XoiySPu3Ql+EH6QZdAMLWodRcYbNHRd2d8bJvWJmOL4uFqRp9JS8/QNO1x3x6F4sQMc3c='),('5330200164','กมลวรรณ ศรีเวียง','S05','/w=='),('5330200245','จีรพร สวัสดิรักษาสิทธิ์','S05','/w=='),('5330200288','ชนิสรา ศรีสมุทร','S05','mspZFqjpvB9DQRQRPkCBCUM/ScEGQUBNAQk4QESBBkJAUYEKPyYpgRbXJiLBEc6oKgEX3SktQQ3nKh+BFsyxLkEn5bMuQSfuRT5BCEfFOMENQ8hugQg/ymdBBERDaEEsMMNhwSk3HTlBDesgO0ETDDotwQZLuyTBBVQRTEEJCRNIQQsIEV3BDIaTW8EKgxx1QQSSHnWBBY9HQQEEuchCwQe8KGxBBiOxcEEKJz90ARKioVYBCho9aYEgpMk4QQy+Jz6BGRc+QgEIsy00gRgFxCRBBcjGLwEHT0ZUgQRCOxoBDsWsMMEVXRlDwQpym2RBBYwfbcEFHhdogQYalzsBCeyTNEEK4zdewQyhmXVBAhk4PYEMPxoRAQPRxBeBGWo+XoEiEDsRgTPHW2StDAIRS05WZnIGFR8gISEhISIkJAIRS05caHQKHCUlJCMiIyQkJAIRUVRZZnIFEBkbHR8gICAiJAIRR0pPXnAVIiUlJSQlJSUlJAIRUVNXYG0CDBQYGRoaGhwfIQIRTFFTYWEoMi8rKCgqKiclJAIRVFZbYWt1Bw0RFRcaHB0fIAIRU1ZWXVQ2MS4qJygsLSsnJgIRVVdcYmpzAggNERMVGBsbHAIRXFxXVVBDOzcxIyIlJyYkJQIQVVhdY2pxdwULEBMVFhgYAhBfXVdTUEhAOjkyLCcnJSICEFZbX2NqcHYDCg8SFBQWFQIQXlxWTUtFQ0E/OjYtKiYgAxBdYWRpb3UCCA4SExQVFQIQW11bUkxGR0ZEQkA+OzYlAxBhY2ZqcHQBBgwQExQUEwIPV2BdV1RMS0pHRkVFRkIDEGFjZmlvcwEECw8SFBUTAw9mY2FcVlBNTEpLTFFTBA9kZ2lucncECg8SFBUEDmNhYF1UTU5MTlBVGPgvGTSpUBQhGiz128oDKUTePYf/Rqs0ZnCEpUKMprB4CVfWgaeA7nE+PVxVtyPhPgi4jfaQKQqwACS0T7dzVs5wtWnyrjNsKGQpRbUFVzW2qjl5vOJZ8FYcbG5qEN1QtazJMmDiuDqppjMLZwPqqFcdBPqd3ENsl/2DLea3xJFtcskPbIOYxMitOEocEGtpIXlOgH0WebQKsZ9QCHtB1QV/BxnEenoF7JFwECa3pH0N+6rLgnzk/JvQMVFWVUiRxvR2cDHFNhdTVhycZdWijYiqwtH923QRD7xpR+vxhqsAt0pN5tQMUEpN3R38JE6z876iTQ9XFt0W4qOhL5sT2NDpaEb8ETQAYsfeIEY1Q8ZO1xtBCN9Yh10sqkbg5mR4hHjCzk2ktcBuQHjY1x+2zx2e7u3sLRfOAy5Gdw=='),('5330200300','ชลธิชา พุ่มสำเภา','S05',''),('5330200393','ณัฐวดี สารนพคุณ','S05',''),('5330200652','พรพรรณ นิลเทพี','S05',''),('5330200709','ภาคิน ฉั่วเจริญ','S05',''),('5330200903','สิทธิศักดิ์ ศรีสิงห์','S05',''),('5330201004','พัฒณียา ขวัญเต่า','S05',''),('5330250013','ธนพร ผลเจริญ','S06',''),('5330250021','ธนวัตร บัวนุช','S06',''),('5330250030','มนทิรา เรืองศรี','S06',''),('5330250048','กัญจ์นภูมิ พันธ์สุข','S06',''),('5330250056','อนุวัฒน์ กลิ่นประยูร','S06',''),('5330250064','สุรเกียรติ นาใจ','S06',''),('5330250072','สุรางค์รัตน์ คำแหง','S06',''),('5330250102','ธนวัฒน์ มาระวิชะโย','S06',''),('5330250111','ชัยวัฒน์ สอดสี','S06',''),('5330250137','ปรียาพัชร์ อติหฤทัยสุข','S06',''),('5330250145','คมสัน บุญพลบ','S06',''),('5330250153','ฐิติพงศ์ พัฒนโภครัตนา','S06',''),('5330250161','กรกฎ มณีวรรณ','S06',''),('5330250196','ปฏิภาณ ศิริไสย','S06',''),('5330250200','สุภัชชา จารุบุญญากร','S06',''),('5330250218','ธันณภัค สุวะพัฒน์','S06',''),('5330250226','นิรันดร์ เลิศปรัชญากุล','S06',''),('5330250234','ณัฏฐา แพรุ่งโรจน์ทวี','S06',''),('5330250242','นภดล อยู่บุญ','S06',''),('5330250251','พรสวรรค์ ยังมี','S06',''),('5330250277','พลอยไพลิน กำลังหาญ','S06',''),('5330250285','สิทธิพงษ์ พุทธิสารสิชฌน์','S06',''),('5330250315','ธัญธร ครองบุญ','S06',''),('5330250331','อารยา พวงรอด','S06',''),('5330250358','สุรวดี มีสุข','S06',''),('5330250374','นภัสนันท์ วงศ์กระพันธุ์','S06',''),('5330250412','ฉรัฐดา ไชยดี','S06',''),('5330250439','รัฐพล ธนเศรษฐกร','S06',''),('5330250455','ธนโชติ กิตติมหาชัย','S06',''),('5330250463','ศรัณย์ บัวไสว','S06',''),('5330250471','ณัฐชา ชนาวรรธน์สกุล','S06',''),('5330250480','เฉลิมพร ทิพย์เกศสุดา','S06',''),('5330250498','สุนันทา นะวงค์','S06',''),('5330250587','ฐาปกรณ์ ฉั่วบันลือ','S06',''),('5330250650','ภูริพันธ์ สืบเชื้อ','S06',''),('5330250731','ชุติพงศ์ มณีตัน','S06',''),('5330250790','เสกข์ โสดานิล','S06',''),('5330250811','นราวัชร์ จันทร์แสน','S06',''),('5330250889','ภาวินี อรุณผาติ','S06','');
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
  `tech_id` int(11) NOT NULL,
  `sub_id` varchar(25) NOT NULL,
  `year` varchar(10) NOT NULL,
  PRIMARY KEY (`tech_id`,`sub_id`,`year`),
  KEY `tech_id` (`tech_id`),
  KEY `sub_id2` (`sub_id`),
  CONSTRAINT `sub_id2` FOREIGN KEY (`sub_id`) REFERENCES `subject` (`sub_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `tech_id` FOREIGN KEY (`tech_id`) REFERENCES `teacher` (`tech_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teaching`
--

LOCK TABLES `teaching` WRITE;
/*!40000 ALTER TABLE `teaching` DISABLE KEYS */;
INSERT INTO `teaching` VALUES (9,'01418332','2555'),(9,'02156985','2555');
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
INSERT INTO `subject` VALUES ('01418332','Operating Systems'),('02156985','Normal Programming');
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

-- Dump completed on 2012-12-10 13:06:10
