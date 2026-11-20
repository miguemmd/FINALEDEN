-- EDEN - Banco de dados do projeto integrador
-- Rode no phpMyAdmin (aba SQL) ou no prompt do MySQL

CREATE DATABASE IF NOT EXISTS DB_Delivery CHARACTER SET utf8mb4;
USE DB_Delivery;

CREATE TABLE IF NOT EXISTS `produtos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) NOT NULL,
  `preco` decimal(10,2) NOT NULL,
  `categoria` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS `usuarios` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(100) NOT NULL,
  `email` VARCHAR(100) NOT NULL,
  `senha` VARCHAR(50) NOT NULL,
  `endereco` VARCHAR(255) NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `email_UNIQUE` (`email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS pedidos (
  id INT NOT NULL AUTO_INCREMENT,
  codigo_pedido VARCHAR(50) NOT NULL,
  nome_cliente VARCHAR(100) NOT NULL,
  total DECIMAL(10,2) NOT NULL,
  status VARCHAR(50) NOT NULL,
  PRIMARY KEY (id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- administrador para testar o login
INSERT INTO usuarios (nome, email, senha, endereco)
VALUES ('Administrador', 'admin@eden.com', 'admin123', NULL);

-- cardápio inicial (mesmos produtos do site)
INSERT INTO produtos (nome, preco, categoria) VALUES
('Poke Tradicional', 36.90, 'Poke'),
('Poke Atum Spicy', 42.90, 'Poke'),
('Poke Frango Teriyaki', 36.90, 'Poke'),
('Poke Vegano Zen', 34.90, 'Poke'),
('Poke Salmão Fresh', 44.90, 'Poke'),
('Poke Camarão Tropical', 43.90, 'Poke'),
('Poke Vegano Oriental', 32.90, 'Poke'),
('Poke Atum Sesame', 42.90, 'Poke');
