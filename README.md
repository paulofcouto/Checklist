# Projeto com CRUD básico com conexão ao banco de dados MySql

Para iniciar o projeto, será necessário criar o banco de dados e para isso você pode utilizar duas formas:

**Solução 1**

1. Acessando a conexão com os seguintes paramêtros:
 
- server: localhost
 - port: 4040
 - user: root
 - password: 123456

![image](https://github.com/paulofcouto/Checklist/assets/22281160/be6b9b60-4a18-4c4a-b039-e9a940d794d0)


2. Rode o script abaixo para criar o banco de dados:

```sql
CREATE DATABASE checklist_teste;
USE checklist_teste;

CREATE TABLE Tarefa (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Descricao VARCHAR(255),
    StatusConcluido BOOLEAN
);

INSERT INTO Tarefa (Descricao, StatusConcluido) VALUES ('Exemplo de tarefa concluída', true);
INSERT INTO Tarefa (Descricao, StatusConcluido) VALUES ('Exemplo de tarefa a fazer', false);
```


**Solução 2**

Abra o projeto no visual studio, clique em 'Tools' > 'NuGet Package Manager' > 'Package Manager Console'.
No console que se abriu, digite o comando 'Update-Database', os arquivos de configuração, irão criar todas as configurações necessárias para iniciar o projeto.


**Solução 3**

Utilizando o Docker, abra um terminal na pasta raiz do projeto e execute o comando
 ```bash
 docker-compose up --build.
 ```
