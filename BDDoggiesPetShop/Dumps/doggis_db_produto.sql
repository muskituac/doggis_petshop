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
-- Table structure for table `produto`
--

DROP TABLE IF EXISTS `produto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `produto` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(255) DEFAULT NULL,
  `fabricante` varchar(255) DEFAULT NULL,
  `especificacoes` text,
  `valor_atual` decimal(10,2) DEFAULT NULL,
  `pataz_bonus` int(11) DEFAULT NULL,
  `pataz_custo` int(11) DEFAULT NULL,
  `ultima_alteracao` datetime DEFAULT NULL,
  `responsavel` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `produto`
--

LOCK TABLES `produto` WRITE;
/*!40000 ALTER TABLE `produto` DISABLE KEYS */;
INSERT INTO `produto` VALUES (1,'Xampu Doguinho','Doguinho Ltda','Xampu para cães            ',10.00,5,7,'2019-05-10 00:00:00','FABRÍCIO ANDRE DA COSTA'),(2,'Anti Pulgas Pulgotrix','Pulgotrix CO','Xampu ante pulgas            ',15.00,5,7,'2019-05-10 00:00:00','FABRÍCIO ANDRE DA COSTA'),(3,'Escova de pentear Simples','Nenko','Escova de pentear pelos. Simples.            ',5.00,1,2,'2019-05-10 00:00:00','FABRÍCIO ANDRE DA COSTA'),(4,'Ração para Cães Cannino 10Kg','Cannino','Ração para cães. 10 Kg',50.00,10,15,'2019-05-10 00:00:00','FABRÍCIO ANDRE DA COSTA'),(5,'Ração para Cães Cannino 20Kg','Cannino ','Ração para Cães 20Kg     ',85.00,25,30,'2019-05-10 00:00:00','FABRÍCIO ANDRE DA COSTA'),(6,'Sabonete liquido','Sabons','sabonete líquido            ',10.00,5,5,'0001-01-01 00:00:00','FABRÍCIO ANDRE DA COSTA'),(7,'Osso de plástico','Ossinhos Company','Brinquedo de animais            ',15.00,5,7,'2019-10-15 19:07:11','FABRÍCIO ANDRE DA COSTA');
/*!40000 ALTER TABLE `produto` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-19 19:34:03
