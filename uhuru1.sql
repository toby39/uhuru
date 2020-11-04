-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  mer. 04 nov. 2020 à 22:06
-- Version du serveur :  5.7.26
-- Version de PHP :  7.3.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `uhuru1`
--

-- --------------------------------------------------------

--
-- Structure de la table `agence`
--

DROP TABLE IF EXISTS `agence`;
CREATE TABLE IF NOT EXISTS `agence` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `designation` longtext CHARACTER SET utf8mb4,
  `adresse` longtext CHARACTER SET utf8mb4,
  `username` longtext CHARACTER SET utf8mb4,
  `password` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `approvisionement`
--

DROP TABLE IF EXISTS `approvisionement`;
CREATE TABLE IF NOT EXISTS `approvisionement` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `numero` longtext CHARACTER SET utf8mb4,
  `date` datetime(6) NOT NULL,
  `quantite` int(11) NOT NULL,
  `unite` longtext CHARACTER SET utf8mb4,
  `Revendeurid` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `IX_approvisionement_Revendeurid` (`Revendeurid`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `approvisionement`
--

INSERT INTO `approvisionement` (`id`, `numero`, `date`, `quantite`, `unite`, `Revendeurid`) VALUES
(5, 'TXN03d03594-ebdb-4521-b389-3d2e52aca74c', '2020-09-13 00:00:00.000000', 34, 'GB', 1),
(6, 'TXN548a6cd9-3b49-443d-b58e-b816d8d91d6a', '2020-09-13 00:00:00.000000', 66, 'GB', 2);

-- --------------------------------------------------------

--
-- Structure de la table `client`
--

DROP TABLE IF EXISTS `client`;
CREATE TABLE IF NOT EXISTS `client` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `noms` longtext CHARACTER SET utf8mb4,
  `sexe` longtext CHARACTER SET utf8mb4,
  `telephone` longtext CHARACTER SET utf8mb4,
  `solde` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `client`
--

INSERT INTO `client` (`id`, `noms`, `sexe`, `telephone`, `solde`) VALUES
(1, 'kamala eric', 'm', '243997831578', 0),
(3, 'kalema shango joseph', 'm', '243997854029', 0);

-- --------------------------------------------------------

--
-- Structure de la table `revendeur`
--

DROP TABLE IF EXISTS `revendeur`;
CREATE TABLE IF NOT EXISTS `revendeur` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `noms` longtext CHARACTER SET utf8mb4,
  `sexe` longtext CHARACTER SET utf8mb4,
  `telephone` longtext CHARACTER SET utf8mb4,
  `solde` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `revendeur`
--

INSERT INTO `revendeur` (`id`, `noms`, `sexe`, `telephone`, `solde`) VALUES
(1, 'uhuru butira', 'f', '243 997 831 578', -90),
(2, 'sadiki muhire', 'm', '243 997 831 578', 0);

-- --------------------------------------------------------

--
-- Structure de la table `stat`
--

DROP TABLE IF EXISTS `stat`;
CREATE TABLE IF NOT EXISTS `stat` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `superuser`
--

DROP TABLE IF EXISTS `superuser`;
CREATE TABLE IF NOT EXISTS `superuser` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `noms` longtext CHARACTER SET utf8mb4,
  `username` longtext CHARACTER SET utf8mb4,
  `password` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `tarif`
--

DROP TABLE IF EXISTS `tarif`;
CREATE TABLE IF NOT EXISTS `tarif` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tranfert` longtext CHARACTER SET utf8mb4,
  `uptime` longtext CHARACTER SET utf8mb4,
  `designation` longtext CHARACTER SET utf8mb4,
  `description` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `tarif`
--

INSERT INTO `tarif` (`id`, `tranfert`, `uptime`, `designation`, `description`) VALUES
(5, '5G', '3w', 'eminem', 'slim shady'),
(6, '10G', '2d', 'master', '10BG-2Jours');

-- --------------------------------------------------------

--
-- Structure de la table `user`
--

DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `noms` longtext CHARACTER SET utf8mb4,
  `username` longtext CHARACTER SET utf8mb4,
  `password` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `vente`
--

DROP TABLE IF EXISTS `vente`;
CREATE TABLE IF NOT EXISTS `vente` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `numero` longtext CHARACTER SET utf8mb4,
  `date` datetime(6) NOT NULL,
  `Revendeurid` int(11) NOT NULL,
  `Clientid` int(11) NOT NULL,
  `paquet` longtext CHARACTER SET utf8mb4,
  `password` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`id`),
  KEY `IX_vente_Clientid` (`Clientid`),
  KEY `IX_vente_Revendeurid` (`Revendeurid`)
) ENGINE=MyISAM AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `vente`
--

INSERT INTO `vente` (`id`, `numero`, `date`, `Revendeurid`, `Clientid`, `paquet`, `password`) VALUES
(1, 'TXN118c166e-8aa7-4f3a-9ec8-8c6a66c58ecf', '2020-09-13 00:00:00.000000', 1, 1, NULL, NULL),
(2, 'TXNf63e02ec-9a93-42d9-ac54-b31c10ed5993', '2020-12-12 00:00:00.000000', 1, 1, NULL, NULL),
(3, 'TXNefa2c754-8798-4cf2-b9bf-f865c92dc09d', '2020-12-12 00:00:00.000000', 1, 3, NULL, NULL),
(4, 'TXN1edeadef-47fe-4d08-9f94-822bddb40f36', '2011-11-11 00:00:00.000000', 1, 1, NULL, NULL),
(5, 'TXNd49204a9-aec2-4320-a5ad-d3fa319a189f', '2019-11-11 00:00:00.000000', 1, 1, NULL, NULL),
(6, 'TXNdd2a6ed9-476b-4ca9-9511-74e65386d093', '2020-12-12 00:00:00.000000', 1, 1, 'Token3', NULL),
(9, 'TXN0518ad0a-fe75-411d-9c0d-221cfbb6f163', '2020-10-25 00:00:00.000000', 1, 3, 'master', NULL),
(8, 'TXN00d56b01-c8c9-4866-a1cb-a59701237b44', '2020-10-25 00:00:00.000000', 1, 3, 'master', NULL),
(10, 'TXNccdf26b0-9a6a-45a2-bc5c-3afb33a71208', '2020-10-25 00:00:00.000000', 1, 3, 'master', NULL),
(11, 'TXNc258bf8c-21fa-46de-a2bc-d5c33c7128ee', '2020-12-12 00:00:00.000000', 1, 3, 'eminem', NULL),
(12, 'TXN61f5f26b-beb5-4f40-860b-329b7bbb269d', '2020-12-12 00:00:00.000000', 1, 3, 'eminem', NULL);

-- --------------------------------------------------------

--
-- Structure de la table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20200913032749_dbinit1', '3.1.8'),
('20200913093545_dbinit2', '3.1.8'),
('20201015135057_db_init3', '3.1.8'),
('20201015152623_db_init4', '3.1.8'),
('20201015162527_db_init5', '3.1.8'),
('20201022012853_dbinit6', '3.1.8'),
('20201025131640_dbinit7', '3.1.8'),
('20201025153211_dbinit8', '3.1.8'),
('20201025153357_dbinit9', '3.1.8'),
('20201026150449_dbinit10', '3.1.8');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
