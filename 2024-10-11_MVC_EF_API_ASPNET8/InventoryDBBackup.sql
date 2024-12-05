-- MySQL dump 10.13  Distrib 8.0.39, for Linux (x86_64)
--
-- Host: localhost    Database: InventoryDB
-- ------------------------------------------------------
-- Server version	8.0.39-0ubuntu0.24.04.2

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Product`
--

DROP TABLE IF EXISTS `Product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Product` (
  `ProductId` int NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `Price` decimal(10,2) NOT NULL,
  `StockQuantity` int NOT NULL,
  `DateAdded` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ProductId`),
  CONSTRAINT `Product_chk_1` CHECK ((`StockQuantity` >= 0))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Product`
--

LOCK TABLES `Product` WRITE;
/*!40000 ALTER TABLE `Product` DISABLE KEYS */;
INSERT INTO `Product` VALUES (1,'Laptop','High-performance laptop',999.99,10,'2024-10-10 18:02:46'),(2,'Smartphone','Latest model smartphone',699.99,20,'2024-10-10 18:02:46'),(3,'Headphones','Noise-cancelling headphones',199.99,15,'2024-10-10 18:02:46'),(4,'Smartwatch','Fitness tracking smartwatch',249.99,5,'2024-10-10 18:02:46'),(5,'Tablet','10-inch tablet with stylus',349.99,8,'2024-10-10 18:02:46'),(8,'Product 8','Description for product 8',450.00,4,'2024-10-10 18:06:38'),(9,'Product 9','Description for product 9',500.00,6,'2024-10-10 18:06:38'),(10,'Product 10','Description for product 10',550.00,3,'2024-10-10 18:06:38'),(11,'Product 11','Description for product 11',600.00,10,'2024-10-10 18:06:38'),(12,'Product 12','Description for product 12',650.00,20,'2024-10-10 18:06:38'),(13,'Product 13','Description for product 13',700.00,15,'2024-10-10 18:06:38'),(14,'Product 14','Description for product 14',750.00,8,'2024-10-10 18:06:38'),(15,'Product 15','Description for product 15',800.00,5,'2024-10-10 18:06:38'),(16,'Product 16','Description for product 16',850.00,12,'2024-10-10 18:06:38'),(17,'Product 17','Description for product 17',900.00,9,'2024-10-10 18:06:38'),(18,'Product 18','Description for product 18',950.00,4,'2024-10-10 18:06:38'),(19,'Product 19','Description for product 19',1000.00,6,'2024-10-10 18:06:38'),(20,'Product 20','Description for product 20',1050.00,3,'2024-10-10 18:06:38'),(21,'Product 21','Description for product 21',1100.00,10,'2024-10-10 18:06:38'),(22,'Product 22','Description for product 22',1150.00,20,'2024-10-10 18:06:38'),(23,'Product 23','Description for product 23',1200.00,15,'2024-10-10 18:06:38'),(24,'Product 24','Description for product 24',1250.00,8,'2024-10-10 18:06:38'),(25,'Product 25','Description for product 25',1300.00,5,'2024-10-10 18:06:38'),(26,'Product 26','Description for product 26',1350.00,12,'2024-10-10 18:06:38'),(27,'Product 27','Description for product 27',1400.00,9,'2024-10-10 18:06:38'),(28,'Product 28','Description for product 28',1450.00,4,'2024-10-10 18:06:38'),(29,'Product 29','Description for product 29',1500.00,6,'2024-10-10 18:06:38'),(30,'Product 30','Description for product 30',1550.00,3,'2024-10-10 18:06:38'),(31,'Product 31','Description for product 31',1600.00,10,'2024-10-10 18:06:38'),(32,'Product 32','Description for product 32',1650.00,20,'2024-10-10 18:06:38'),(33,'Product 33','Description for product 33',1700.00,15,'2024-10-10 18:06:38'),(34,'Product 34','Description for product 34',1750.00,8,'2024-10-10 18:06:38'),(35,'Product 35','Description for product 35',1800.00,5,'2024-10-10 18:06:38'),(36,'Product 36','Description for product 36',1850.00,12,'2024-10-10 18:06:38'),(37,'Product 37','Description for product 37',1900.00,9,'2024-10-10 18:06:38'),(38,'Product 38','Description for product 38',1950.00,4,'2024-10-10 18:06:38'),(39,'Product 39','Description for product 39',2000.00,6,'2024-10-10 18:06:38'),(40,'Product 40','Description for product 40',2050.00,3,'2024-10-10 18:06:38'),(41,'Product 41','Description for product 41',2100.00,10,'2024-10-10 18:06:38'),(42,'Product 42','Description for product 42',2150.00,20,'2024-10-10 18:06:38'),(43,'Product 43','Description for product 43',2200.00,15,'2024-10-10 18:06:38'),(44,'Product 44','Description for product 44',2250.00,8,'2024-10-10 18:06:38'),(45,'Product 45','Description for product 45',2300.00,5,'2024-10-10 18:06:38'),(46,'Product 46','Description for product 46',2350.00,12,'2024-10-10 18:06:38'),(47,'Product 47','Description for product 47',2400.00,9,'2024-10-10 18:06:38'),(48,'Product 48','Description for product 48',2450.00,4,'2024-10-10 18:06:38'),(49,'Product 49','Description for product 49',2500.00,6,'2024-10-10 18:06:38'),(50,'Product 50','Description for product 50',2550.00,3,'2024-10-10 18:06:38');
/*!40000 ALTER TABLE `Product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Store`
--

DROP TABLE IF EXISTS `Store`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Store` (
  `StoreId` int NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Location` varchar(255) NOT NULL,
  `DateOpened` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`StoreId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Store`
--

LOCK TABLES `Store` WRITE;
/*!40000 ALTER TABLE `Store` DISABLE KEYS */;
INSERT INTO `Store` VALUES (1,'Tech Store A','123 Main St, City A','2024-10-10 18:02:46'),(2,'Electronics Hub','456 Market St, City B','2024-10-10 18:02:46'),(3,'Gadgets Galore','789 Elm St, City C','2024-10-10 18:02:46'),(4,'Devices Depot','321 Oak St, City D','2024-10-10 18:02:46'),(9,'Store I','Location I','2024-10-10 18:07:51'),(10,'Store J','Location J','2024-10-10 18:07:51'),(11,'Store K','Location K','2024-10-10 18:07:51'),(12,'Store L','Location L','2024-10-10 18:07:51'),(13,'Store M','Location M','2024-10-10 18:07:51'),(14,'Store N','Location N','2024-10-10 18:07:51'),(15,'Store O','Location O','2024-10-10 18:07:51'),(16,'Store P','Location P','2024-10-10 18:07:51'),(17,'Store Q','Location Q','2024-10-10 18:07:51'),(18,'Store R','Location R','2024-10-10 18:07:51'),(19,'Store S','Location S','2024-10-10 18:07:51'),(20,'Store T','Location T','2024-10-10 18:07:51'),(21,'Store U','Location U','2024-10-10 18:07:51'),(22,'Store V','Location V','2024-10-10 18:07:51'),(23,'Store W','Location W','2024-10-10 18:07:51'),(24,'Store X','Location X','2024-10-10 18:07:51'),(25,'Store Y','Location Y','2024-10-10 18:07:51'),(26,'Store Z','Location Z','2024-10-10 18:07:51'),(27,'Store AA','Location AA','2024-10-10 18:07:51'),(28,'Store AB','Location AB','2024-10-10 18:07:51'),(29,'Store AC','Location AC','2024-10-10 18:07:51'),(30,'Store AD','Location AD','2024-10-10 18:07:51'),(31,'Store AE','Location AE','2024-10-10 18:07:51'),(32,'Store AF','Location AF','2024-10-10 18:07:51'),(33,'Store AG','Location AG','2024-10-10 18:07:51'),(34,'Store AH','Location AH','2024-10-10 18:07:51'),(35,'Store AI','Location AI','2024-10-10 18:07:51'),(36,'Store AJ','Location AJ','2024-10-10 18:07:51'),(37,'Store AK','Location AK','2024-10-10 18:07:51'),(38,'Store AL','Location AL','2024-10-10 18:07:51'),(39,'Store AM','Location AM','2024-10-10 18:07:51'),(40,'Store AN','Location AN','2024-10-10 18:07:51'),(41,'Store AO','Location AO','2024-10-10 18:07:51'),(42,'Store AP','Location AP','2024-10-10 18:07:51'),(43,'Store AQ','Location AQ','2024-10-10 18:07:51'),(44,'Store AR','Location AR','2024-10-10 18:07:51'),(45,'Store AS','Location AS','2024-10-10 18:07:51'),(46,'Store AT','Location AT','2024-10-10 18:07:51'),(47,'Store AU','Location AU','2024-10-10 18:07:51'),(48,'Store AV','Location AV','2024-10-10 18:07:51'),(49,'Store AW','Location AW','2024-10-10 18:07:51'),(50,'Store AX','Location AX','2024-10-10 18:07:51');
/*!40000 ALTER TABLE `Store` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `StoreProduct`
--

DROP TABLE IF EXISTS `StoreProduct`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `StoreProduct` (
  `StoreId` int NOT NULL,
  `ProductId` int NOT NULL,
  PRIMARY KEY (`StoreId`,`ProductId`),
  KEY `ProductId` (`ProductId`),
  CONSTRAINT `StoreProduct_ibfk_1` FOREIGN KEY (`StoreId`) REFERENCES `Store` (`StoreId`) ON DELETE CASCADE,
  CONSTRAINT `StoreProduct_ibfk_2` FOREIGN KEY (`ProductId`) REFERENCES `Product` (`ProductId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `StoreProduct`
--

LOCK TABLES `StoreProduct` WRITE;
/*!40000 ALTER TABLE `StoreProduct` DISABLE KEYS */;
INSERT INTO `StoreProduct` VALUES (1,1),(2,1),(3,1),(4,1),(9,1),(16,1),(1,2),(2,2),(4,2),(10,2),(14,2),(16,2),(1,3),(2,3),(3,3),(4,3),(11,3),(15,3),(16,3),(3,4),(12,4),(16,4),(3,5),(4,5),(13,5),(16,5),(2,8),(17,8),(3,9),(17,9),(3,10),(17,10),(4,11),(18,11),(4,12),(18,12),(18,13),(18,14),(18,15),(19,16),(19,17),(19,18),(19,19),(19,20),(20,21),(20,22),(9,23),(20,23),(9,24),(20,24),(9,25),(20,25),(9,26),(10,27),(10,28),(10,29),(10,30),(11,31),(11,32),(11,33),(11,34),(12,35),(12,36),(12,37),(12,38),(13,39),(13,40),(13,41),(13,42),(14,43),(14,44),(14,45),(14,46),(15,47),(15,48),(15,49),(15,50);
/*!40000 ALTER TABLE `StoreProduct` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-10-11 21:07:57
