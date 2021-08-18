CREATE TABLE usuarios (
id INT(11) AUTO_INCREMENT PRIMARY KEY,
nome VARCHAR(30) NOT NULL,
sobrenome VARCHAR(30) NOT NULL,
email VARCHAR(80),
senha varchar(100),
status varchar(1)
);

CREATE TABLE tarefas (
id INT(11) AUTO_INCREMENT PRIMARY KEY,
titulo VARCHAR(50) NOT NULL,
descricao VARCHAR(5000) NOT NULL,
prioridade int(1),
status varchar(1), 
data date,
idUsuario int(11)
);
ALTER TABLE `tarefas` ADD CONSTRAINT `fk_tarefas_idUsuario` FOREIGN KEY ( `idUsuario` ) REFERENCES `usuarios` ( `id` ) ;


CREATE TABLE anexos (
id INT(11) AUTO_INCREMENT PRIMARY KEY,
url VARCHAR(5000) NOT NULL,
idTarefa int(11) NOT NULL
);
ALTER TABLE `anexos` ADD CONSTRAINT `fk_anexos_idTarefa` FOREIGN KEY ( `idTarefa` ) REFERENCES `tarefas` ( `id` ) ;