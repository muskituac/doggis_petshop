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
-- Table structure for table `servico_produto`
--

DROP TABLE IF EXISTS `servico_produto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `servico_produto` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_servico` int(11) NOT NULL,
  `id_produto` int(11) NOT NULL,
  `quantidade` int(11) NOT NULL,
  `ultima_alteracao` datetime DEFAULT NULL,
  `responsavel` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`,`id_servico`,`id_produto`),
  KEY `fk_servico_produto_servico_idx` (`id_servico`),
  KEY `fk_servico_produto_produto_idx` (`id_produto`),
  CONSTRAINT `fk_servico_produto_produto` FOREIGN KEY (`id_produto`) REFERENCES `produto` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_servico_produto_servico` FOREIGN KEY (`id_servico`) REFERENCES `servico` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `servico_produto`
--

LOCK TABLES `servico_produto` WRITE;
/*!40000 ALTER TABLE `servico_produto` DISABLE KEYS */;
INSERT INTO `servico_produto` VALUES (1,1,2,1,'2019-12-10 00:00:00','FABRÍCIO ANDRE DA COSTA'),(2,1,3,1,'2019-12-10 00:00:00','FABRÍCIO ANDRE DA COSTA'),(3,2,1,2,'2019-12-10 00:00:00','FABRÍCIO ANDRE DA COSTA'),(4,2,2,1,'2019-12-10 00:00:00','FABRÍCIO ANDRE DA COSTA'),(5,2,3,1,'2019-12-10 00:00:00','FABRÍCIO ANDRE DA COSTA'),(6,3,1,1,'2019-12-10 00:00:00','FABRÍCIO ANDRE DA COSTA'),(7,3,2,1,'2019-12-10 00:00:00','FABRÍCIO ANDRE DA COSTA'),(8,3,3,1,'2019-12-10 00:00:00','FABRÍCIO ANDRE DA COSTA'),(9,5,4,1,'0001-01-01 00:00:00','FABRÍCIO ANDRE DA COSTA'),(10,6,4,1,'0001-01-01 00:00:00','FABRÍCIO ANDRE DA COSTA'),(11,7,4,2,'0001-01-01 00:00:00','FABRÍCIO ANDRE DA COSTA');
/*!40000 ALTER TABLE `servico_produto` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-19 19:33:23
