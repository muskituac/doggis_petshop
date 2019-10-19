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
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(255) NOT NULL,
  `usuario_tipo` int(11) NOT NULL,
  `login` varchar(255) NOT NULL,
  `senha` varchar(255) NOT NULL,
  `ultimo_acesso` datetime NOT NULL,
  `ultima_alteracao` datetime NOT NULL,
  `responsavel` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_usuario_usuario_tipo_idx` (`usuario_tipo`),
  CONSTRAINT `fk_usuario_usuario_tipo` FOREIGN KEY (`usuario_tipo`) REFERENCES `usuario_tipo` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'FABRÍCIO ANDRE DA COSTA',1,'fcosta','123456','2019-09-24 18:25:00','2019-09-24 18:25:00','root'),(2,'USU ATENDENTE',2,'aendente','123456','2019-09-24 18:25:00','2019-09-24 18:25:00','root'),(3,'USU CLIENTE',3,'cliente','123456','2019-09-24 18:25:00','2019-09-24 18:25:00','root'),(4,'USU_ATENDENTE 2',2,'usu2','123456','2019-09-29 15:00:00','2019-09-29 15:00:00','root'),(5,'USU_ATENDENTE 3',2,'usu3','123456','2019-09-29 15:00:00','2019-09-29 15:00:00','root'),(6,'USU_ATENDENTE 4',2,'usu4','123456','2019-09-29 15:00:00','2019-09-29 15:00:00','root'),(7,'Teste',3,'teste','123456','2019-10-10 00:00:00','2019-10-10 00:00:00','FABRÍCIO ANDRE DA COSTA');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-19 19:33:54
