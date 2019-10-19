-- MySQL dump 10.13  Distrib 8.0.17, for Win64 (x86_64)
--
-- Host: localhost    Database: doggis_db
-- ------------------------------------------------------
-- Server version	8.0.17

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
-- Table structure for table `pet`
--

DROP TABLE IF EXISTS `pet`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pet` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_pet_tipo` int(11) NOT NULL,
  `id_cliente` int(11) NOT NULL,
  `nome` varchar(255) NOT NULL,
  `raca` varchar(255) DEFAULT NULL,
  `porte` varchar(255) DEFAULT NULL,
  `alergias` text,
  `observacao` text,
  `autorizacao` varchar(1) DEFAULT NULL,
  `ultima_alteracao` datetime DEFAULT NULL,
  `responsavel` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_pet_pet_tipo_idx` (`id_pet_tipo`),
  KEY `fk_pet_cliente_idx` (`id_cliente`),
  CONSTRAINT `fk_pet_cliente` FOREIGN KEY (`id_cliente`) REFERENCES `cliente` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_pet_pet_tipo` FOREIGN KEY (`id_pet_tipo`) REFERENCES `pet_tipo` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pet`
--

LOCK TABLES `pet` WRITE;
/*!40000 ALTER TABLE `pet` DISABLE KEYS */;
INSERT INTO `pet` VALUES (1,1,3,'NAYA',NULL,NULL,NULL,NULL,'S','2019-09-24 18:25:00','root'),(2,1,3,'POLY',NULL,NULL,NULL,NULL,'S','2019-09-24 18:25:00','root'),(3,1,3,'LUNA',NULL,NULL,NULL,NULL,'S','2019-09-24 18:25:00','root'),(4,2,1,'GATINHO',NULL,NULL,NULL,NULL,'N','2019-09-24 18:25:00','root'),(5,3,2,'PAPA',NULL,NULL,NULL,NULL,'N','2019-09-24 18:25:00','root'),(6,4,2,'HAMIS',NULL,NULL,NULL,NULL,'N','2019-09-24 18:25:00','root'),(7,1,1,'Petinho','Normal','','Sem alergia','Sem observação','N','2019-07-10 00:00:00','FABRÍCIO ANDRE DA COSTA'),(8,3,2,'PIRI','Piriquito','','Sementes de girassol','Não há','N','2019-07-10 00:00:00','FABRÍCIO ANDRE DA COSTA'),(9,1,2,'Dogão','Vira-lata','','Nenhuma','Nenhuma','N','2019-07-10 00:00:00','FABRÍCIO ANDRE DA COSTA');
/*!40000 ALTER TABLE `pet` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-19 19:33:56
