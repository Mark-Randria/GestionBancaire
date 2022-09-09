-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : ven. 09 sep. 2022 à 21:10
-- Version du serveur : 5.7.36
-- Version de PHP : 7.4.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `bank`
--

-- --------------------------------------------------------

--
-- Structure de la table `client`
--

DROP TABLE IF EXISTS `client`;
CREATE TABLE IF NOT EXISTS `client` (
  `id_client` int(11) NOT NULL,
  `nom` varchar(50) NOT NULL,
  `prenom` varchar(50) NOT NULL,
  `ville` varchar(50) NOT NULL,
  `datenais` varchar(255) NOT NULL,
  `numero` int(11) NOT NULL,
  `nationality` varchar(25) NOT NULL,
  `genre` varchar(10) NOT NULL,
  `email` varchar(100) NOT NULL,
  `date_ins` varchar(255) NOT NULL,
  PRIMARY KEY (`id_client`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `client`
--

INSERT INTO `client` (`id_client`, `nom`, `prenom`, `ville`, `datenais`, `numero`, `nationality`, `genre`, `email`, `date_ins`) VALUES
(200, 'RANDRIA', 'Mark', 'Fianar', 'jeudi 13 juin 2002', 340100154, 'MALAGASY', 'Homme', 'example@gmail.com', 'mardi 5 juillet 2022'),
(10, 'RABE', 'andrea', 'Tana', 'jeudi 13 juin 2002', 911, 'Malagasy', 'Homme', 'example@gmail.com', 'mardi 5 juillet 2022'),
(5000, 'kkjdaklsj', 'jdiwajid', '12312', 'lundi 13 juin 2022', 2545445, 'malagasy', 'Femme', 'example@gmail.com', 'lundi 13 juin 2022'),
(1, 'ythgfds', 'frdqws', 'ewfaew', 'lundi 13 juin 2022', 25062, 'ikuytr', 'Femme', 'kuybtvggybt', 'lundi 13 juin 2022');

-- --------------------------------------------------------

--
-- Structure de la table `compte`
--

DROP TABLE IF EXISTS `compte`;
CREATE TABLE IF NOT EXISTS `compte` (
  `id_compte` int(11) NOT NULL,
  `id_client` int(11) NOT NULL,
  `type` varchar(50) NOT NULL,
  `description` varchar(255) NOT NULL,
  `solde` int(11) NOT NULL,
  PRIMARY KEY (`id_compte`,`id_client`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `compte`
--

INSERT INTO `compte` (`id_compte`, `id_client`, `type`, `description`, `solde`) VALUES
(50, 10, 'Compte Fixe', 'bb', 104700),
(1, 1, 'Compte Epargne', 'evbgtvrfcv', 20022),
(80, 5000, 'Compte Fixe', 'aaaa', 500),
(15, 10, 'Compte Fixe', 'argent de poche', 495100),
(4, 10, 'Compte Fixe', 'bbb', 500500),
(250, 10, 'Compte Epargne', 'bbb', 50000),
(50, 200, 'Compte Fixe', 'Etude', 104700);

-- --------------------------------------------------------

--
-- Structure de la table `transaction`
--

DROP TABLE IF EXISTS `transaction`;
CREATE TABLE IF NOT EXISTS `transaction` (
  `tx_id` int(11) NOT NULL AUTO_INCREMENT,
  `id_compte` int(11) NOT NULL,
  `date` varchar(255) NOT NULL,
  `solde` int(11) NOT NULL,
  `depot` int(11) DEFAULT NULL,
  `retrait` int(11) DEFAULT NULL,
  PRIMARY KEY (`tx_id`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `transaction`
--

INSERT INTO `transaction` (`tx_id`, `id_compte`, `date`, `solde`, `depot`, `retrait`) VALUES
(1, 20, 'lundi 13 juin 2022', 90200, NULL, 200),
(2, 20, 'lundi 13 juin 2022', 90000, NULL, 10000),
(3, 20, 'lundi 13 juin 2022', 80000, 10000, NULL),
(4, 20, 'lundi 13 juin 2022', 1000000, 500, NULL),
(5, 20, 'lundi 13 juin 2022', 1000500, 500, NULL),
(6, 20, 'mardi 5 juillet 2022', 1001000, NULL, 1000),
(7, 20, 'lundi 13 juin 2022', 999900, 100, NULL),
(8, 50, 'lundi 13 juin 2022', 100000, 10000, NULL),
(9, 50, 'lundi 13 juin 2022', 110000, NULL, 10000);

-- --------------------------------------------------------

--
-- Structure de la table `transfert`
--

DROP TABLE IF EXISTS `transfert`;
CREATE TABLE IF NOT EXISTS `transfert` (
  `id_transfert` int(11) NOT NULL AUTO_INCREMENT,
  `account_send` int(11) NOT NULL,
  `account_receiver` int(11) NOT NULL,
  `date` varchar(255) NOT NULL,
  `montant` int(11) NOT NULL,
  PRIMARY KEY (`id_transfert`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `transfert`
--

INSERT INTO `transfert` (`id_transfert`, `account_send`, `account_receiver`, `date`, `montant`) VALUES
(1, 100, 20, 'lundi 13 juin 2022', 10000),
(2, 20, 100, 'lundi 13 juin 2022', 20000),
(3, 100, 20, 'lundi 13 juin 2022', 200),
(4, 20, 20, 'lundi 13 juin 2022', 20000),
(5, 20, 15, 'lundi 13 juin 2022', 100),
(6, 50, 4, 'lundi 13 juin 2022', 500),
(7, 50, 15, 'lundi 13 juin 2022', 5000),
(8, 15, 50, 'lundi 13 juin 2022', 10000),
(9, 1, 50, 'vendredi 9 septembre 2022', 200);

-- --------------------------------------------------------

--
-- Structure de la table `utilisateur`
--

DROP TABLE IF EXISTS `utilisateur`;
CREATE TABLE IF NOT EXISTS `utilisateur` (
  `pseudo` varchar(255) NOT NULL,
  `mdp` varchar(255) NOT NULL,
  PRIMARY KEY (`pseudo`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `utilisateur`
--

INSERT INTO `utilisateur` (`pseudo`, `mdp`) VALUES
('moi', '123123'),
('admin', 'admin'),
('moly', '123123'),
('Antonio', 'antonio');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
