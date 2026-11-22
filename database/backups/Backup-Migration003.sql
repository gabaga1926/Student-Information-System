-- MySQL dump 10.13  Distrib 8.0.46, for Win64 (x86_64)
--
-- Host: localhost    Database: student_information_system_db
-- ------------------------------------------------------
-- Server version	8.0.46

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
-- Table structure for table `student`
--

DROP TABLE IF EXISTS `student`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `student` (
  `Student_ID` varchar(20) NOT NULL,
  `Gender` varchar(20) NOT NULL,
  `Year_Level` int NOT NULL,
  `Program` varchar(100) NOT NULL,
  `Contact_Number` varchar(11) NOT NULL,
  `First_Name` varchar(60) NOT NULL,
  `Last_Name` varchar(60) NOT NULL,
  `Full_Name` varchar(121) GENERATED ALWAYS AS (concat(`First_Name`,_utf8mb4' ',`Last_Name`)) STORED,
  `Is_Active` tinyint(1) NOT NULL DEFAULT '1',
  `Deleted_At` datetime DEFAULT NULL,
  PRIMARY KEY (`Student_ID`),
  UNIQUE KEY `Contact_Number` (`Contact_Number`),
  KEY `idx_student_active` (`Is_Active`),
  CONSTRAINT `chk_contact_number` CHECK (regexp_like(`Contact_Number`,_utf8mb4'^[0-9]{11}$')),
  CONSTRAINT `student_chk_1` CHECK ((`Year_Level` between 1 and 4))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student`
--

LOCK TABLES `student` WRITE;
/*!40000 ALTER TABLE `student` DISABLE KEYS */;
INSERT INTO `student` (`Student_ID`, `Gender`, `Year_Level`, `Program`, `Contact_Number`, `First_Name`, `Last_Name`, `Is_Active`, `Deleted_At`) VALUES ('2024-001','Male',2,'BS Computer Science','09935382981','Juan Dela','Cruz',1,NULL),('2024-002','Female',2,'BS Information Technology','09662143078','Maria Clara','Santos',1,NULL);
/*!40000 ALTER TABLE `student` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `v_student_active`
--

DROP TABLE IF EXISTS `v_student_active`;
/*!50001 DROP VIEW IF EXISTS `v_student_active`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `v_student_active` AS SELECT 
 1 AS `Student_ID`,
 1 AS `First_Name`,
 1 AS `Last_Name`,
 1 AS `Full_Name`,
 1 AS `Gender`,
 1 AS `Year_Level`,
 1 AS `Program`,
 1 AS `Contact_Number`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `v_student_active`
--

/*!50001 DROP VIEW IF EXISTS `v_student_active`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `v_student_active` AS select `student`.`Student_ID` AS `Student_ID`,`student`.`First_Name` AS `First_Name`,`student`.`Last_Name` AS `Last_Name`,`student`.`Full_Name` AS `Full_Name`,`student`.`Gender` AS `Gender`,`student`.`Year_Level` AS `Year_Level`,`student`.`Program` AS `Program`,`student`.`Contact_Number` AS `Contact_Number` from `student` where (`student`.`Is_Active` = 1) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-11-22 18:35:46
