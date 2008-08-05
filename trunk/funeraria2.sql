-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.0.22-community-nt


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema funeraria
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ funeraria;
USE funeraria;

--
-- Table structure for table `funeraria`.`administradores`
--

DROP TABLE IF EXISTS `administradores`;
CREATE TABLE `administradores` (
  `codigo` char(5) NOT NULL default '',
  `id` varchar(15) NOT NULL default '',
  `clave` varchar(10) NOT NULL default '',
  PRIMARY KEY  (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `funeraria`.`administradores`
--

/*!40000 ALTER TABLE `administradores` DISABLE KEYS */;
INSERT INTO `administradores` (`codigo`,`id`,`clave`) VALUES 
 ('00001','Admimistrador','Valida'),
 ('00002','adm','pwd'),
 ('00003','IrrJ','Password'),
 ('00004','jhoni','jhoni'),
 ('00005','jhoni','jhoni'),
 ('00006','jhoni','jhoni'),
 ('00007','jhoni','jhoni'),
 ('00008','jhoni','jhoni'),
 ('00009','jhoni','jhoni'),
 ('00010','carlos','carlos'),
 ('00011','nuevo','nuevo'),
 ('00012','chepe trompo','chepe'),
 ('00013','rober','rober'),
 ('00014','any','any');
/*!40000 ALTER TABLE `administradores` ENABLE KEYS */;


--
-- Table structure for table `funeraria`.`clientes`
--

DROP TABLE IF EXISTS `clientes`;
CREATE TABLE `clientes` (
  `codigo` char(5) NOT NULL default '',
  `apellidos` varchar(45) NOT NULL default '',
  `nombres` varchar(45) NOT NULL default '',
  `direccion` text NOT NULL,
  `telefono` char(8) NOT NULL default '',
  `estado` int(10) unsigned NOT NULL default '0' COMMENT '0=moroso, 1=atiempo y 2=inactivo',
  `plan_pago` char(5) default NULL,
  `tipo_serv` char(5) NOT NULL default '',
  PRIMARY KEY  (`codigo`),
  KEY `fk_tipo_serv` (`tipo_serv`),
  KEY `fk_plan_pago` (`plan_pago`),
  CONSTRAINT `fk_plan_pago` FOREIGN KEY (`plan_pago`) REFERENCES `planes_pago` (`codigo`),
  CONSTRAINT `fk_tipo_serv` FOREIGN KEY (`tipo_serv`) REFERENCES `servicios` (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `funeraria`.`clientes`
--

/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
INSERT INTO `clientes` (`codigo`,`apellidos`,`nombres`,`direccion`,`telefono`,`estado`,`plan_pago`,`tipo_serv`) VALUES 
 ('an001','apellidos1','nombres1','Direccion1','24400000',0,NULL,'00001'),
 ('an002','apellidos2','nombres2','Direccion2','24400001',0,NULL,'00001'),
 ('an003','apellidos3','nombres3','Direccion3','24400002',0,NULL,'00001'),
 ('an004','apellidos4','nombres4','Direccion4','24400003',1,NULL,'00002'),
 ('an005','apellidos5','nombres5','Direccion5','24400004',1,NULL,'00002');
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;


--
-- Table structure for table `funeraria`.`cuotas`
--

DROP TABLE IF EXISTS `cuotas`;
CREATE TABLE `cuotas` (
  `codigo` char(5) NOT NULL default '',
  `mes` int(10) unsigned NOT NULL default '0',
  `cantidad` decimal(10,2) NOT NULL default '0.00',
  `fecha_limite` date NOT NULL default '0000-00-00',
  `fecha_pago` date default NULL,
  `cancelada` tinyint(1) NOT NULL default '0',
  `plan_pago` char(5) NOT NULL default '',
  PRIMARY KEY  (`codigo`),
  KEY `fk_planes_pago` (`plan_pago`),
  CONSTRAINT `fk_planes_pago` FOREIGN KEY (`plan_pago`) REFERENCES `planes_pago` (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `funeraria`.`cuotas`
--

/*!40000 ALTER TABLE `cuotas` DISABLE KEYS */;
INSERT INTO `cuotas` (`codigo`,`mes`,`cantidad`,`fecha_limite`,`fecha_pago`,`cancelada`,`plan_pago`) VALUES 
 ('00001',1,'1200.00','2001-01-06','2005-01-06',0,'00001'),
 ('00002',2,'1400.00','2001-01-06','2005-01-06',0,'00001'),
 ('00003',3,'1400.00','2001-01-06','2005-01-06',0,'00001'),
 ('00004',4,'2600.00','2001-01-06','2005-01-06',0,'00001'),
 ('00005',5,'100.00','2001-01-06','2005-01-06',0,'00001'),
 ('00006',1,'250.00','2001-01-06','2005-01-06',0,'00002'),
 ('00007',2,'550.00','2001-01-06','2005-01-06',0,'00002'),
 ('00008',3,'750.00','2001-01-06','2005-01-06',0,'00002'),
 ('00009',1,'1750.00','2001-01-06','2005-01-06',0,'00003'),
 ('00010',2,'2125.00','2001-01-06','2005-01-06',0,'00003'),
 ('00011',3,'2300.00','2001-01-06','2005-01-06',0,'00003');
/*!40000 ALTER TABLE `cuotas` ENABLE KEYS */;


--
-- Table structure for table `funeraria`.`gastos`
--

DROP TABLE IF EXISTS `gastos`;
CREATE TABLE `gastos` (
  `codigo` char(5) NOT NULL default '',
  `tipo` char(8) NOT NULL default '' COMMENT 'fijo o variable',
  `concepto` text NOT NULL,
  `monto` decimal(10,2) NOT NULL default '0.00',
  `fecha` datetime NOT NULL default '0000-00-00 00:00:00',
  `saldado` tinyint(1) NOT NULL default '0',
  PRIMARY KEY  (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `funeraria`.`gastos`
--

/*!40000 ALTER TABLE `gastos` DISABLE KEYS */;
INSERT INTO `gastos` (`codigo`,`tipo`,`concepto`,`monto`,`fecha`,`saldado`) VALUES 
 ('00001','variable','Se me acaba de ocurrir','1200.00','2001-01-06 12:00:00',1),
 ('00002','variable','Tenia hambre y compre un pan','3200.00','2001-01-06 12:00:00',1),
 ('00003','variable','Despues de comerme el pan me dio sed y compre un fresco','700.00','2001-01-06 12:00:00',1),
 ('00004','variable','Nada importante','1700.00','2001-01-06 12:00:00',1),
 ('00005','variable','Ya no me acuerdo en que me lo gaste','3500.00','2001-01-07 12:00:00',1),
 ('00006','fijo','Gasto de una entrada al cine','3000.00','2001-01-07 12:00:00',1),
 ('00007','fijo','Gasto de otra entrada al cine','3000.00','2001-01-07 12:00:00',1),
 ('00008','fijo','Un ladron me asalto','12000.00','2001-01-07 12:00:00',1),
 ('00009','fijo','El mismo ladron me asalto otra vez','14700.00','2001-01-07 12:00:00',1),
 ('00010','fijo','Nada importante','600.00','2001-01-08 12:00:00',1),
 ('00011','fijo','compras varias','253.35','2006-09-28 12:00:38',0),
 ('00012','fijo','compras por el ladron que le robo a rober','47000.00','2006-09-28 12:02:17',0);
/*!40000 ALTER TABLE `gastos` ENABLE KEYS */;


--
-- Table structure for table `funeraria`.`planes_pago`
--

DROP TABLE IF EXISTS `planes_pago`;
CREATE TABLE `planes_pago` (
  `codigo` char(5) NOT NULL default '',
  `n_cuotas` int(10) unsigned NOT NULL default '0',
  `total_pagar` decimal(10,2) NOT NULL default '0.00',
  `cliente` char(5) NOT NULL default '',
  PRIMARY KEY  (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `funeraria`.`planes_pago`
--

/*!40000 ALTER TABLE `planes_pago` DISABLE KEYS */;
INSERT INTO `planes_pago` (`codigo`,`n_cuotas`,`total_pagar`,`cliente`) VALUES 
 ('00001',5,'10000.00','an001'),
 ('00002',5,'20000.00','an002'),
 ('00003',4,'12000.00','an003'),
 ('00004',6,'15000.00','an004'),
 ('00005',3,'5000.00','an005');
/*!40000 ALTER TABLE `planes_pago` ENABLE KEYS */;


--
-- Table structure for table `funeraria`.`servicios`
--

DROP TABLE IF EXISTS `servicios`;
CREATE TABLE `servicios` (
  `codigo` char(5) NOT NULL default '',
  `nombre` varchar(20) NOT NULL default '',
  `descripcion` text NOT NULL,
  PRIMARY KEY  (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `funeraria`.`servicios`
--

/*!40000 ALTER TABLE `servicios` DISABLE KEYS */;
INSERT INTO `servicios` (`codigo`,`nombre`,`descripcion`) VALUES 
 ('00001','Jardin Amoroso',''),
 ('00002','Resurreccion',''),
 ('00003','Duquesa',''),
 ('00004','Americano',''),
 ('00005','Ejecutiva',''),
 ('00006','Presidencial','');
/*!40000 ALTER TABLE `servicios` ENABLE KEYS */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
