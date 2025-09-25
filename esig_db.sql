CREATE DATABASE esig_db;
USE esig_db;

CREATE TABLE cargo (
    cargo_id INT PRIMARY KEY,
    cargo_nome VARCHAR(100) NOT NULL,
    salario DECIMAL(10,2) NOT NULL
);

CREATE TABLE pessoa (
    pessoa_id INT PRIMARY KEY,
    nome VARCHAR(200) NOT NULL,
    cidade VARCHAR(200),
    email VARCHAR(300),
    cep VARCHAR(40),
    endereco VARCHAR(300),
    pais VARCHAR(100),
    usuario VARCHAR(100),
    telefone VARCHAR(60),
    data_nascimento DATE,
    cargo_id INT NOT NULL,
    FOREIGN KEY (cargo_id) REFERENCES cargo(cargo_id)
);

CREATE TABLE pessoa_salario (
    pessoa_id INT,
    pessoa_nome VARCHAR(100),
    cargo_nome VARCHAR(100),
    salario DECIMAL(10,2)
);

DELIMITER $$
CREATE PROCEDURE calcular_salarios()
BEGIN
  TRUNCATE TABLE pessoa_salario;
  INSERT INTO pessoa_salario (pessoa_id, pessoa_nome, cargo_nome, salario)
  SELECT p.pessoa_id, p.nome, c.cargo_nome, c.salario
  FROM pessoa p
  JOIN cargo c ON p.cargo_id = c.cargo_id;
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE calcular_salarios_com_bonus()
BEGIN
  TRUNCATE TABLE pessoa_salario;
  INSERT INTO pessoa_salario (pessoa_id, pessoa_nome, cargo_nome, salario)
  SELECT 
    p.pessoa_id,
    p.nome,
    c.cargo_nome,
    c.salario +
      CASE
        WHEN TIMESTAMPDIFF(YEAR, p.data_nascimento, CURDATE()) > 50 
          THEN c.salario * 0.20
        WHEN TIMESTAMPDIFF(YEAR, p.data_nascimento, CURDATE()) > 30 
          THEN c.salario * 0.10
        ELSE 0
      END AS salario_final
  FROM pessoa p
  JOIN cargo c ON p.cargo_id = c.cargo_id;
END $$
DELIMITER ;

SELECT * FROM cargo;
SELECT * FROM pessoa;



