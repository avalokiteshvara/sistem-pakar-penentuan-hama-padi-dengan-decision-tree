-- phpMyAdmin SQL Dump
-- version 3.5.2.2
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Feb 05, 2013 at 08:24 AM
-- Server version: 5.5.27
-- PHP Version: 5.4.7

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `deteksihama_1`
--

DELIMITER $$
--
-- Procedures
--
DROP PROCEDURE IF EXISTS `proc_1`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `proc_1`()
BEGIN
	DECLARE done INT DEFAULT FALSE;
	DECLARE a,b INT;
	DECLARE cur1 CURSOR FOR SELECT no_urut FROM pertanyaan ORDER BY no_urut;
	DECLARE CONTINUE HANDLER FOR SQLSTATE '02000' SET done=TRUE;
	
	SET a = 0;
	OPEN cur1;	
	REPEAT
	  FETCH cur1 INTO b;
	  SET a = a + 1;
	  UPDATE pertanyaan SET no_urut = a WHERE no_urut = b;	  
	UNTIL done END REPEAT;
	CLOSE cur1;
END$$

DROP PROCEDURE IF EXISTS `proc_2`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `proc_2`()
BEGIN
	DECLARE done INT DEFAULT FALSE;
	DECLARE a,b INT;
	DECLARE cur1 CURSOR FOR SELECT no_urut FROM solusi ORDER BY no_urut;
	DECLARE CONTINUE HANDLER FOR SQLSTATE '02000' SET done=TRUE;
	
	SET a = 0;
	OPEN cur1;	
	REPEAT
	  FETCH cur1 INTO b;
	  SET a = a + 1;
	  UPDATE solusi SET no_urut = a WHERE no_urut = b;	  
	UNTIL done END REPEAT;
	CLOSE cur1;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `decision_tree`
--

DROP TABLE IF EXISTS `decision_tree`;
CREATE TABLE IF NOT EXISTS `decision_tree` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `node` varchar(50) DEFAULT NULL,
  `parent` varchar(50) DEFAULT NULL,
  `parent_attribute` varchar(50) DEFAULT NULL,
  `child` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=17 ;

--
-- Dumping data for table `decision_tree`
--

INSERT INTO `decision_tree` (`id`, `node`, `parent`, `parent_attribute`, `child`) VALUES
(1, 'isipadi', 'NULL', 'NULL', 5),
(2, 'B3', 'isipadi', 'IP_ABU_ABU', 0),
(3, 'B1', 'isipadi', 'IP_KEHITAMAN', 0),
(4, 'batang', 'isipadi', 'IP_KERING', 5),
(5, 'B1', 'batang', 'B_ADA_ULAT', 0),
(6, 'B2', 'batang', 'B_KECOKLATAN', 0),
(7, 'B2', 'batang', 'B_KEHITAMAN', 0),
(8, 'B2', 'batang', 'B_KEPOMPONG_MUDA', 0),
(9, 'B3', 'batang', 'B_MUDAH_DICABUT', 0),
(10, 'daun', 'isipadi', 'IP_KOSONG', 5),
(11, 'B1', 'daun', 'D_HIJAU', 0),
(12, 'B1', 'daun', 'D_KUNING', 0),
(13, 'B3', 'daun', 'D_MENGERING', 0),
(14, 'B1', 'daun', 'D_MERAH', 0),
(15, 'B1', 'daun', 'D_UJUNG_MATI', 0),
(16, 'B2', 'isipadi', 'IP_MUDAH_DICABUT', 0);

-- --------------------------------------------------------

--
-- Table structure for table `pertanyaan`
--

DROP TABLE IF EXISTS `pertanyaan`;
CREATE TABLE IF NOT EXISTS `pertanyaan` (
  `no_urut` int(11) NOT NULL,
  `id` varchar(50) NOT NULL,
  `isi` text,
  `arr_jawaban` varchar(1000) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pertanyaan`
--

INSERT INTO `pertanyaan` (`no_urut`, `id`, `isi`, `arr_jawaban`) VALUES
(2, 'batang', 'BATANG', 'B_KEHITAMAN,B_KECOKLATAN,B_KEPOMPONG_MUDA,B_ADA_ULAT,B_MUDAH_DICABUT'),
(1, 'daun', 'DAUN', 'D_UJUNG_MATI,D_KUNING,D_MENGERING,D_MERAH,D_HIJAU'),
(3, 'isipadi', 'ISI_PADI', 'IP_KOSONG,IP_KERING,IP_KEHITAMAN,IP_ABU_ABU,IP_MUDAH_DICABUT');

-- --------------------------------------------------------

--
-- Table structure for table `rule`
--

DROP TABLE IF EXISTS `rule`;
CREATE TABLE IF NOT EXISTS `rule` (
  `id` int(10) NOT NULL,
  `arr_fakta` varchar(200) NOT NULL,
  `solusi` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `rule`
--

INSERT INTO `rule` (`id`, `arr_fakta`, `solusi`) VALUES
(1, 'D_UJUNG_MATI,B_KEHITAMAN,IP_KOSONG', 'B1'),
(2, 'D_KUNING,B_KEHITAMAN,IP_KERING', 'B2'),
(3, 'D_KUNING,B_KECOKLATAN,IP_KEHITAMAN', 'B1'),
(4, 'D_KUNING,B_KECOKLATAN,IP_MUDAH_DICABUT', 'B2'),
(5, 'D_KUNING,B_ADA_ULAT,IP_ABU_ABU', 'B3'),
(6, 'D_MENGERING,B_KECOKLATAN,IP_MUDAH_DICABUT', 'B1'),
(7, 'D_MERAH,B_KEPOMPONG_MUDA,IP_KERING', 'B2'),
(8, 'D_MERAH,B_ADA_ULAT,IP_KERING', 'B1'),
(9, 'D_HIJAU,B_MUDAH_DICABUT,IP_KERING', 'B3'),
(10, 'D_KUNING,B_ADA_ULAT,IP_MUDAH_DICABUT', 'B1'),
(11, 'D_MENGERING,B_ADA_ULAT,IP_ABU_ABU', 'B3'),
(12, 'D_UJUNG_MATI,B_ADA_ULAT,IP_KOSONG', 'B2'),
(13, 'D_MERAH,B_KEPOMPONG_MUDA,IP_KOSONG', 'B1'),
(14, 'D_HIJAU,B_ADA_ULAT,IP_ABU_ABU', 'B3'),
(15, 'D_UJUNG_MATI,B_KEPOMPONG_MUDA,IP_KOSONG', 'B1'),
(16, 'D_KUNING,B_KECOKLATAN,IP_KOSONG', 'B1'),
(17, 'D_MENGERING,B_MUDAH_DICABUT,IP_KOSONG', 'B3'),
(18, 'D_HIJAU,B_KEPOMPONG_MUDA,IP_KOSONG', 'B1'),
(19, 'D_MENGERING,B_KECOKLATAN,IP_KERING', 'B2');

-- --------------------------------------------------------

--
-- Table structure for table `solusi`
--

DROP TABLE IF EXISTS `solusi`;
CREATE TABLE IF NOT EXISTS `solusi` (
  `no_urut` int(11) NOT NULL,
  `id` varchar(50) NOT NULL,
  `isi` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `solusi`
--

INSERT INTO `solusi` (`no_urut`, `id`, `isi`) VALUES
(1, 'B1', 'Gunakan pestisida cair. Penyemprotan dilakukan didarat. Penyemprotan pada bagian batang & bagian pucuk padi lebih banyak dari pada bagian yang lain'),
(2, 'B2', 'Gunakan pestisida cair. Penyemprotan dilakukan didarat.Semprotkan pada bagian daun lebih banyak dari pada bagian yang lain'),
(3, 'B3', 'Padi tidak terserang hama wereng. Mungkin terserang hama / Penyakit lain. Disarankan jangan gunakan pestisida terlalu banyak.');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `nama` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL,
  `is_admin` enum('True','False') DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`id`, `nama`, `password`, `is_admin`) VALUES
(1, 'admin', 'admin', 'True'),
(2, 'pengguna1', 'pengguna1', 'False');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
