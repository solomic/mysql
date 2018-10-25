-- MySQL dump 10.13  Distrib 8.0.12, for Win64 (x86_64)
--
-- Host: localhost    Database: cmo
-- ------------------------------------------------------
-- Server version	8.0.12

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `contact`
--

DROP TABLE IF EXISTS `contact`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `contact` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `last_name` varchar(50) DEFAULT NULL,
  `first_name` varchar(50) DEFAULT NULL,
  `second_name` varchar(50) DEFAULT NULL,
  `contact_id` int(11) DEFAULT NULL,
  `birthday` datetime DEFAULT NULL,
  `updated` datetime DEFAULT NULL,
  `updated_by` varchar(45) DEFAULT NULL,
  `status` varchar(15) DEFAULT NULL,
  `nationality` varchar(60) DEFAULT NULL,
  `doc_state` int(11) DEFAULT NULL,
  `expelled_dt` datetime DEFAULT NULL,
  `birth_country` varchar(60) DEFAULT NULL,
  `birth_town` varchar(60) DEFAULT NULL,
  `per_view` varchar(11) DEFAULT NULL,
  `per_ser` varchar(8) DEFAULT NULL,
  `per_num` varchar(10) DEFAULT NULL,
  `per_date_issue` datetime DEFAULT NULL,
  `per_date_validity` datetime DEFAULT NULL,
  `created` datetime DEFAULT CURRENT_TIMESTAMP,
  `created_by` varchar(20) DEFAULT NULL,
  `sex` varchar(10) DEFAULT NULL,
  `postup_year` varchar(20) DEFAULT NULL,
  `form_teach` varchar(20) DEFAULT NULL,
  `form_pay` varchar(30) DEFAULT NULL,
  `comments` text,
  `spec` varchar(250) DEFAULT NULL,
  `facult` varchar(100) DEFAULT NULL,
  `date_of_entry_future` datetime DEFAULT NULL,
  `prog_teach` varchar(40) DEFAULT NULL,
  `sel` varchar(10) DEFAULT NULL,
  `rf` varchar(1) DEFAULT NULL,
  `fio` varchar(150) DEFAULT NULL,
  `last_enu` varchar(50) DEFAULT NULL,
  `first_enu` varchar(50) DEFAULT NULL,
  `route` varchar(50) DEFAULT NULL,
  `address_home` varchar(200) DEFAULT NULL,
  `position` varchar(30) DEFAULT NULL,
  `relatives` varchar(300) DEFAULT NULL,
  `med` varchar(30) DEFAULT NULL,
  `second_enu` varchar(50) DEFAULT NULL,
  `agree_num` varchar(40) DEFAULT NULL,
  `agree_date` datetime DEFAULT NULL,
  `agree_fr` datetime DEFAULT NULL,
  `agree_to` datetime DEFAULT NULL,
  `expelled` varchar(100) DEFAULT NULL,
  `expelled_num` varchar(20) DEFAULT NULL,
  `deduct` varchar(1) DEFAULT NULL,
  `delivery_dt` datetime DEFAULT NULL,
  `graduate` varchar(1) DEFAULT '2',
  `phone` varchar(250) DEFAULT NULL,
  `reg_extend` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=48 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-10-25 16:07:42
