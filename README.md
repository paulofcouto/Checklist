Projeto com CRUD básico com conexão ao banco de dados MySql.

Para iniciar o projeto, utilizar o script de criação das tabelas:

CREATE DATABASE checklist_teste;
USE checklist_teste;

CREATE TABLE Tarefa (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Nome VARCHAR(255),
    StatusConcluido BOOLEAN
);
