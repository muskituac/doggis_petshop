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
-- Table structure for table `agendamento`
--

DROP TABLE IF EXISTS `agendamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `agendamento` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_cliente` int(11) NOT NULL,
  `id_pet` int(11) NOT NULL,
  `id_servico` int(11) NOT NULL,
  `id_funcionario` int(11) NOT NULL,
  `data_inicio` datetime NOT NULL,
  `data_termino` datetime NOT NULL,
  `notificacao_enviada` tinyint(1) NOT NULL DEFAULT '0',
  `cancelamento` tinyint(1) NOT NULL DEFAULT '0',
  `ultima_alteracao` datetime DEFAULT NULL,
  `responsavel` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_agendamento_cliente_idx` (`id_cliente`),
  KEY `fk_agendamento_pet_idx` (`id_pet`),
  KEY `fk_agendamento_funcionario_idx` (`id_funcionario`),
  KEY `fk_agendamento_servico_idx` (`id_servico`),
  CONSTRAINT `fk_agendamento_cliente` FOREIGN KEY (`id_cliente`) REFERENCES `cliente` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_agendamento_funcionario` FOREIGN KEY (`id_funcionario`) REFERENCES `funcionario` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_agendamento_pet` FOREIGN KEY (`id_pet`) REFERENCES `pet` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_agendamento_servico` FOREIGN KEY (`id_servico`) REFERENCES `servico` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agendamento`
--

LOCK TABLES `agendamento` WRITE;
/*!40000 ALTER TABLE `agendamento` DISABLE KEYS */;
INSERT INTO `agendamento` VALUES (3,1,4,3,5,'2019-10-14 13:00:00','2019-10-14 14:00:00',0,0,'2019-10-14 22:51:59','FABRÍCIO ANDRE DA COSTA'),(5,3,3,2,4,'2019-10-15 15:00:00','2019-10-15 17:00:00',0,0,'2019-10-15 19:11:18','FABRÍCIO ANDRE DA COSTA'),(6,1,7,1,4,'2019-10-15 16:30:00','2019-10-15 17:30:00',0,0,'2019-10-15 19:12:14','FABRÍCIO ANDRE DA COSTA'),(7,3,1,2,5,'2019-10-15 15:00:00','2019-10-15 17:00:00',0,0,'2019-10-15 19:13:07','FABRÍCIO ANDRE DA COSTA'),(8,3,2,1,6,'2019-10-15 15:00:00','2019-10-15 16:00:00',0,0,'2019-10-15 19:19:10','FABRÍCIO ANDRE DA COSTA'),(9,3,1,2,6,'2019-10-15 15:00:00','2019-10-15 17:00:00',0,0,'2019-10-15 19:54:03','FABRÍCIO ANDRE DA COSTA');
/*!40000 ALTER TABLE `agendamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `atendente`
--

DROP TABLE IF EXISTS `atendente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `atendente` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_funcionario` int(11) NOT NULL,
  `nome` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_atendente_funcionario_idx` (`id_funcionario`),
  CONSTRAINT `fk_atendente_funcionario` FOREIGN KEY (`id_funcionario`) REFERENCES `funcionario` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `atendente`
--

LOCK TABLES `atendente` WRITE;
/*!40000 ALTER TABLE `atendente` DISABLE KEYS */;
INSERT INTO `atendente` VALUES (1,1,'Atendente 1'),(2,2,'Atendente 2'),(3,3,'Atendente 3');
/*!40000 ALTER TABLE `atendente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cliente` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(255) NOT NULL,
  `identidade` varchar(255) DEFAULT NULL,
  `cpf` varchar(255) NOT NULL,
  `endereco` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `autorizacao` varchar(1) DEFAULT NULL,
  `ultima_alteracao` datetime DEFAULT NULL,
  `responsavel` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` VALUES (1,'CLIENTE 1','123456','987654','ENDERECO 1','EMAIL1@TESTE.COM.BR','S','2019-09-24 18:25:00','root'),(2,'CLIENTE 2','654789','852147','ENDERECO 2','EMAIL2@TESTE.COM.BR','N','2019-09-24 18:25:00','root'),(3,'Gabriela Vilela','MG-123.456.566','123.987.455-65','Av. Centenario, 429 - Bom Pastor','gabi__vile@hotmail.com','N','2019-05-10 00:00:00','FABRÍCIO ANDRE DA COSTA');
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cliente_pataz_entrada_produto`
--

DROP TABLE IF EXISTS `cliente_pataz_entrada_produto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cliente_pataz_entrada_produto` (
  `id` int(11) NOT NULL,
  `id_cliente` int(11) NOT NULL,
  `quantidade` int(11) NOT NULL,
  `id_venda_produto` int(11) NOT NULL,
  `ultima_alteracao` datetime DEFAULT NULL,
  `responsavel` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_cliente_pataz_entrada_produto_cliente_idx` (`id_cliente`),
  KEY `fk_cliente_pataz_entrada_produto_venda_produto_idx` (`id_venda_produto`),
  CONSTRAINT `fk_cliente_pataz_entrada_produto_cliente` FOREIGN KEY (`id_cliente`) REFERENCES `cliente` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_cliente_pataz_entrada_produto_venda_produto` FOREIGN KEY (`id_venda_produto`) REFERENCES `venda_produto` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente_pataz_entrada_produto`
--

LOCK TABLES `cliente_pataz_entrada_produto` WRITE;
/*!40000 ALTER TABLE `cliente_pataz_entrada_produto` DISABLE KEYS */;
/*!40000 ALTER TABLE `cliente_pataz_entrada_produto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cliente_pataz_entrada_servico`
--

DROP TABLE IF EXISTS `cliente_pataz_entrada_servico`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cliente_pataz_entrada_servico` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_cliente` int(11) NOT NULL,
  `quantidade` int(11) NOT NULL,
  `id_venda_servico` int(11) NOT NULL,
  `ultima_alteracao` datetime DEFAULT NULL,
  `responsavel` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_cliente_pataz_entrada_servico_cliente_idx` (`id_cliente`),
  KEY `fk_cliente_pataz_entrada_servico_venda_servico_idx` (`id_venda_servico`),
  CONSTRAINT `fk_cliente_pataz_entrada_servico_cliente` FOREIGN KEY (`id_cliente`) REFERENCES `cliente` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_cliente_pataz_entrada_servico_venda_servico` FOREIGN KEY (`id_venda_servico`) REFERENCES `venda_servico` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente_pataz_entrada_servico`
--

LOCK TABLES `cliente_pataz_entrada_servico` WRITE;
/*!40000 ALTER TABLE `cliente_pataz_entrada_servico` DISABLE KEYS */;
/*!40000 ALTER TABLE `cliente_pataz_entrada_servico` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cliente_pataz_saida_produto`
--

DROP TABLE IF EXISTS `cliente_pataz_saida_produto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cliente_pataz_saida_produto` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_cliente` int(11) NOT NULL,
  `quantidade` int(11) NOT NULL,
  `id_venda_produto_pagamento` int(11) NOT NULL,
  `ultima_alteracao` datetime DEFAULT NULL,
  `responsavel` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_cliente_pataz_saida_produto_cliente_idx` (`id_cliente`),
  KEY `fk_cliente_pataz_saida_produto_venda_produto_pagamento_idx` (`id_venda_produto_pagamento`),
  CONSTRAINT `fk_cliente_pataz_saida_produto_cliente` FOREIGN KEY (`id_cliente`) REFERENCES `cliente` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_cliente_pataz_saida_produto_venda_produto_pagamento` FOREIGN KEY (`id_venda_produto_pagamento`) REFERENCES `venda_produto_pagamento` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente_pataz_saida_produto`
--

LOCK TABLES `cliente_pataz_saida_produto` WRITE;
/*!40000 ALTER TABLE `cliente_pataz_saida_produto` DISABLE KEYS */;
/*!40000 ALTER TABLE `cliente_pataz_saida_produto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cliente_pataz_saida_servico`
--

DROP TABLE IF EXISTS `cliente_pataz_saida_servico`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cliente_pataz_saida_servico` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_cliente` int(11) NOT NULL,
  `quantidade` int(11) NOT NULL,
  `id_venda_servico_pagamento` int(11) NOT NULL,
  `ultima_alteracao` datetime DEFAULT NULL,
  `responsavel` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_cliente_pataz_saida_servico_cliente_idx` (`id_cliente`),
  KEY `fk_cliente_pataz_saida_servico_venda_servico_pagamento_idx` (`id_venda_servico_pagamento`),
  CONSTRAINT `fk_cliente_pataz_saida_servico_cliente` FOREIGN KEY (`id_cliente`) REFERENCES `cliente` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_cliente_pataz_saida_servico_venda_servico_pagamento` FOREIGN KEY (`id_venda_servico_pagamento`) REFERENCES `venda_servico_pagamento` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente_pataz_saida_servico`
--

LOCK TABLES `cliente_pataz_saida_servico` WRITE;
/*!40000 ALTER TABLE `cliente_pataz_saida_servico` DISABLE KEYS */;
/*!40000 ALTER TABLE `cliente_pataz_saida_servico` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `estoque_entrada`
--

DROP TABLE IF EXISTS `estoque_entrada`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `estoque_entrada` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_produto` int(11) NOT NULL,
  `quantidade` int(11) NOT NULL,
  `data` datetime NOT NULL,
  `ultima_alteracao` datetime DEFAULT NULL,
  `responsavel` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_estoque_entrada_produot_idx` (`id_produto`),
  CONSTRAINT `fk_estoque_entrada_produot` FOREIGN KEY (`id_produto`) REFERENCES `produto` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estoque_entrada`
--

LOCK TABLES `estoque_entrada` WRITE;
/*!40000 ALTER TABLE `estoque_entrada` DISABLE KEYS */;
INSERT INTO `estoque_entrada` VALUES (3,1,50,'2019-05-10 00:00:00','2019-05-10 00:00:00','FABRÍCIO ANDRE DA COSTA'),(4,2,10,'2019-05-10 00:00:00','2019-05-10 00:00:00','FABRÍCIO ANDRE DA COSTA'),(5,3,10,'2019-05-10 00:00:00','2019-05-10 00:00:00','FABRÍCIO ANDRE DA COSTA');
/*!40000 ALTER TABLE `estoque_entrada` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `estoque_saida`
--

DROP TABLE IF EXISTS `estoque_saida`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `estoque_saida` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_produto` int(11) NOT NULL,
  `quantidade` int(11) NOT NULL,
  `data` datetime NOT NULL,
  `ultima_alteracao` datetime DEFAULT NULL,
  `responsavel` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_estoque_saida_produto_idx` (`id_produto`),
  CONSTRAINT `fk_estoque_saida_produto` FOREIGN KEY (`id_produto`) REFERENCES `produto` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estoque_saida`
--

LOCK TABLES `estoque_saida` WRITE;
/*!40000 ALTER TABLE `estoque_saida` DISABLE KEYS */;
/*!40000 ALTER TABLE `estoque_saida` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `funcionario`
--

DROP TABLE IF EXISTS `funcionario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `funcionario` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(255) NOT NULL,
  `id_usuario` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_funcionario_usuario_idx` (`id_usuario`),
  CONSTRAINT `fk_funcionario_usuario` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `funcionario`
--

LOCK TABLES `funcionario` WRITE;
/*!40000 ALTER TABLE `funcionario` DISABLE KEYS */;
INSERT INTO `funcionario` VALUES (1,'FUNCIONARIO 1',1),(2,'FUNCIONARIO 2',2),(3,'FUNCIONARIO 3',3),(4,'FUNCIONARIO 4',4),(5,'FUNCIONARIO 5',5),(6,'FUNCIONARIO 6',6),(8,'zezim',5),(9,'lindomar',6);
/*!40000 ALTER TABLE `funcionario` ENABLE KEYS */;
UNLOCK TABLES;

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

--
-- Table structure for table `pet_tipo`
--

DROP TABLE IF EXISTS `pet_tipo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pet_tipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(255) NOT NULL,
  `ultima_alteracao` datetime DEFAULT NULL,
  `responsavel` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pet_tipo`
--

LOCK TABLES `pet_tipo` WRITE;
/*!40000 ALTER TABLE `pet_tipo` DISABLE KEYS */;
INSERT INTO `pet_tipo` VALUES (1,'CACHORRO','2019-09-24 18:25:00','root'),(2,'GATO','2019-09-24 18:25:00','root'),(3,'PAPAGAIO','2019-09-24 18:25:00','root'),(4,'HAMSTER','2019-09-24 18:25:00','root');
/*!40000 ALTER TABLE `pet_tipo` ENABLE KEYS */;
UNLOCK TABLES;

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

--
-- Table structure for table `promocao`
--

DROP TABLE IF EXISTS `promocao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `promocao` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(255) NOT NULL,
  `porcentagem` int(11) NOT NULL,
  `data_inicio` datetime NOT NULL,
  `data_termino` datetime NOT NULL,
  `ultima_alteracao` datetime DEFAULT NULL,
  `responsavel` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `promocao`
--

LOCK TABLES `promocao` WRITE;
/*!40000 ALTER TABLE `promocao` DISABLE KEYS */;
INSERT INTO `promocao` VALUES (1,'Promoção Relâmpago',20,'2019-10-15 00:00:00','2019-10-16 00:00:00','2019-10-15 21:38:00','FABRÍCIO ANDRE DA COSTA'),(2,'Promoção surpresa de final de semana',30,'2019-10-17 00:00:00','2019-10-20 00:00:00','2019-10-15 21:40:52','FABRÍCIO ANDRE DA COSTA');
/*!40000 ALTER TABLE `promocao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `promocao_produto`
--

DROP TABLE IF EXISTS `promocao_produto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `promocao_produto` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_promocao` int(11) NOT NULL,
  `id_produto` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_promocao_produto_promocao_idx` (`id_promocao`),
  KEY `fk_promocao_produto_produto_idx` (`id_produto`),
  CONSTRAINT `fk_promocao_produto_produto` FOREIGN KEY (`id_produto`) REFERENCES `produto` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_promocao_produto_promocao` FOREIGN KEY (`id_promocao`) REFERENCES `promocao` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `promocao_produto`
--

LOCK TABLES `promocao_produto` WRITE;
/*!40000 ALTER TABLE `promocao_produto` DISABLE KEYS */;
INSERT INTO `promocao_produto` VALUES (1,1,1),(2,1,2),(3,2,1),(4,2,3),(5,2,7);
/*!40000 ALTER TABLE `promocao_produto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `promocao_servico`
--

DROP TABLE IF EXISTS `promocao_servico`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `promocao_servico` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_promocao` int(11) NOT NULL,
  `id_servico` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_promocao_servico_promocao_idx` (`id_promocao`),
  KEY `fk_promocao_servico_servico_idx` (`id_servico`),
  CONSTRAINT `fk_promocao_servico_promocao` FOREIGN KEY (`id_promocao`) REFERENCES `promocao` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_promocao_servico_servico` FOREIGN KEY (`id_servico`) REFERENCES `servico` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `promocao_servico`
--

LOCK TABLES `promocao_servico` WRITE;
/*!40000 ALTER TABLE `promocao_servico` DISABLE KEYS */;
INSERT INTO `promocao_servico` VALUES (3,2,3),(4,2,6),(5,2,7);
/*!40000 ALTER TABLE `promocao_servico` ENABLE KEYS */;
UNLOCK TABLES;

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

--
-- Table structure for table `servico_valor`
--

DROP TABLE IF EXISTS `servico_valor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `servico_valor` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_servico` int(11) NOT NULL,
  `valor` decimal(10,2) NOT NULL,
  `ultima_alteracao` datetime DEFAULT NULL,
  `responsavel` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `servico_valor`
--

LOCK TABLES `servico_valor` WRITE;
/*!40000 ALTER TABLE `servico_valor` DISABLE KEYS */;
/*!40000 ALTER TABLE `servico_valor` ENABLE KEYS */;
UNLOCK TABLES;

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

--
-- Table structure for table `usuario_tipo`
--

DROP TABLE IF EXISTS `usuario_tipo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario_tipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario_tipo`
--

LOCK TABLES `usuario_tipo` WRITE;
/*!40000 ALTER TABLE `usuario_tipo` DISABLE KEYS */;
INSERT INTO `usuario_tipo` VALUES (1,'Administrador'),(2,'Atendente'),(3,'Cliente');
/*!40000 ALTER TABLE `usuario_tipo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `venda`
--

DROP TABLE IF EXISTS `venda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `venda` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `data` datetime NOT NULL,
  `id_cliente` int(11) NOT NULL,
  `ultima_alteracao` datetime DEFAULT NULL,
  `responsavel` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venda`
--

LOCK TABLES `venda` WRITE;
/*!40000 ALTER TABLE `venda` DISABLE KEYS */;
/*!40000 ALTER TABLE `venda` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `venda_produto`
--

DROP TABLE IF EXISTS `venda_produto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `venda_produto` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_venda` int(11) NOT NULL,
  `id_produto` int(11) NOT NULL,
  `quantidade` int(11) NOT NULL,
  `valor_unitario` decimal(10,2) NOT NULL,
  `valor_unitario_pataz` int(11) NOT NULL,
  `valor_total` decimal(10,2) NOT NULL,
  `valor_total_pataz` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_venda_produto_venda_idx` (`id_venda`),
  KEY `fk_venda_produto_produto_idx` (`id_produto`),
  CONSTRAINT `fk_venda_produto_produto` FOREIGN KEY (`id_produto`) REFERENCES `produto` (`id`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `fk_venda_produto_venda` FOREIGN KEY (`id_venda`) REFERENCES `venda` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venda_produto`
--

LOCK TABLES `venda_produto` WRITE;
/*!40000 ALTER TABLE `venda_produto` DISABLE KEYS */;
/*!40000 ALTER TABLE `venda_produto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `venda_produto_pagamento`
--

DROP TABLE IF EXISTS `venda_produto_pagamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `venda_produto_pagamento` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_venda_produto` int(11) NOT NULL,
  `valor_total` decimal(10,2) DEFAULT NULL,
  `valor_total_pataz` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_venda_produto_pagamento_venda_produto_idx` (`id_venda_produto`),
  CONSTRAINT `fk_venda_produto_pagamento_venda_produto` FOREIGN KEY (`id_venda_produto`) REFERENCES `venda_produto` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venda_produto_pagamento`
--

LOCK TABLES `venda_produto_pagamento` WRITE;
/*!40000 ALTER TABLE `venda_produto_pagamento` DISABLE KEYS */;
/*!40000 ALTER TABLE `venda_produto_pagamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `venda_servico`
--

DROP TABLE IF EXISTS `venda_servico`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `venda_servico` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_venda` int(11) NOT NULL,
  `id_servico` int(11) NOT NULL,
  `id_pet` int(11) NOT NULL,
  `quantidade` int(11) NOT NULL,
  `valor_unitario` decimal(10,2) NOT NULL,
  `valor_unitario_pataz` int(11) NOT NULL,
  `valor_total` decimal(10,2) NOT NULL,
  `valor_total_pataz` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_venda_servico_venda_idx` (`id_venda`),
  KEY `fk_venda_servico_servico_idx` (`id_servico`),
  KEY `fk_venda_servico_pet_idx` (`id_pet`),
  CONSTRAINT `fk_venda_servico_pet` FOREIGN KEY (`id_pet`) REFERENCES `pet` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_venda_servico_servico` FOREIGN KEY (`id_servico`) REFERENCES `servico` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_venda_servico_venda` FOREIGN KEY (`id_venda`) REFERENCES `venda` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venda_servico`
--

LOCK TABLES `venda_servico` WRITE;
/*!40000 ALTER TABLE `venda_servico` DISABLE KEYS */;
/*!40000 ALTER TABLE `venda_servico` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `venda_servico_pagamento`
--

DROP TABLE IF EXISTS `venda_servico_pagamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `venda_servico_pagamento` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_venda_servico` int(11) NOT NULL,
  `valor_total` decimal(10,2) DEFAULT NULL,
  `valor_total_pataz` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_venda_servico_pagamento_venda_servico_idx` (`id_venda_servico`),
  CONSTRAINT `fk_venda_servico_pagamento_venda_servico` FOREIGN KEY (`id_venda_servico`) REFERENCES `venda_servico` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venda_servico_pagamento`
--

LOCK TABLES `venda_servico_pagamento` WRITE;
/*!40000 ALTER TABLE `venda_servico_pagamento` DISABLE KEYS */;
/*!40000 ALTER TABLE `venda_servico_pagamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `veterinario`
--

DROP TABLE IF EXISTS `veterinario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `veterinario` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_funcionario` int(11) NOT NULL,
  `nome` varchar(255) NOT NULL,
  `cpf` varchar(255) NOT NULL,
  `identidade` varchar(255) DEFAULT NULL,
  `registro` varchar(255) NOT NULL,
  `ultima_alteracao` datetime DEFAULT NULL,
  `responsavel` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_veterinario_funcionario_idx` (`id_funcionario`),
  CONSTRAINT `fk_veterinario_funcionario` FOREIGN KEY (`id_funcionario`) REFERENCES `funcionario` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `veterinario`
--

LOCK TABLES `veterinario` WRITE;
/*!40000 ALTER TABLE `veterinario` DISABLE KEYS */;
INSERT INTO `veterinario` VALUES (1,4,'Vet Altamir','254.987.964-56','MG-46.985.987','MG-456','2019-10-10 00:00:00','FABRÍCIO ANDRE DA COSTA'),(2,5,'Vet Silva','999.999.999-99','MG-12.123.123','MG-123','2019-10-14 00:00:00','root'),(3,6,'Vet Souza','888.888.888-99','MG-99.999.999','MG-999','2019-10-14 00:00:00','root');
/*!40000 ALTER TABLE `veterinario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `veterinario_pet_tipo`
--

DROP TABLE IF EXISTS `veterinario_pet_tipo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `veterinario_pet_tipo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_veterinario` int(11) NOT NULL,
  `id_pet_tipo` int(11) NOT NULL,
  PRIMARY KEY (`id`,`id_veterinario`,`id_pet_tipo`),
  KEY `fk_veterinario_pet_tipo_pet_tipo_idx` (`id_pet_tipo`),
  KEY `fk_veterinario_pet_tipo_veterinario_idx` (`id_veterinario`),
  CONSTRAINT `fk_veterinario_pet_tipo_pet_tipo` FOREIGN KEY (`id_pet_tipo`) REFERENCES `pet_tipo` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_veterinario_pet_tipo_veterinario` FOREIGN KEY (`id_veterinario`) REFERENCES `veterinario` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `veterinario_pet_tipo`
--

LOCK TABLES `veterinario_pet_tipo` WRITE;
/*!40000 ALTER TABLE `veterinario_pet_tipo` DISABLE KEYS */;
INSERT INTO `veterinario_pet_tipo` VALUES (1,1,1),(3,2,1),(6,3,1),(4,2,2),(5,2,3),(2,1,4);
/*!40000 ALTER TABLE `veterinario_pet_tipo` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-19 19:43:34
