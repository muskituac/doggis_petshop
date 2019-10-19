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
-- Table structure for table `servico`
--

DROP TABLE IF EXISTS `servico`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `servico` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tipo_executante` int(11) NOT NULL,
  `nome` varchar(255) NOT NULL,
  `descricao` text,
  `valor_atual` decimal(10,2) DEFAULT NULL,
  `tempo` int(11) DEFAULT NULL,
  `pataz_bonus` int(11) DEFAULT NULL,
  `pataz_custo` int(11) DEFAULT NULL,
  `ultima_alteracao` datetime DEFAULT NULL,
  `responsavel` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `servico`
--

LOCK TABLES `servico` WRITE;
/*!40000 ALTER TABLE `servico` DISABLE KEYS */;
INSERT INTO `servico` VALUES (1,2,'Tosa Cachorro Pequeno','Tosa em cachorros de pequeno porte            ',50.00,60,15,25,'2019-12-10 00:00:00','FABRÍCIO ANDRE DA COSTA'),(2,2,'Tosa Cachorro Médio','Tosa em cachorros de porte médio            ',60.00,120,15,25,'2019-12-10 00:00:00','FABRÍCIO ANDRE DA COSTA'),(3,2,'Banho Gato','Banho em gatos de todos os portes            ',35.00,60,10,15,'2019-12-10 00:00:00','FABRÍCIO ANDRE DA COSTA'),(4,1,'Penteado ','Penteado',15.00,60,15,25,'2019-10-14 00:00:00','root'),(5,1,'Carinho',' Fazer carinho no pet       ',10.00,60,5,10,'0001-01-01 00:00:00','FABRÍCIO ANDRE DA COSTA'),(6,1,'Adestramento','Adestramento de animais            ',150.00,180,50,100,'0001-01-01 00:00:00','FABRÍCIO ANDRE DA COSTA'),(7,1,'Adestramento intensivo','Adestramento intensivo de animais            ',200.00,180,100,150,'0001-01-01 00:00:00','FABRÍCIO ANDRE DA COSTA');
/*!40000 ALTER TABLE `servico` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-19 19:32:50
