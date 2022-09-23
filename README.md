# EfCoreDbFirst (Campeonato)

Usando o Scaffold-DbContext dentro da pasta do projeto.

Banco PostgreSql

```
 Scaffold-DbContext "Server=localhost; Database=Campeonato; user id=postgres; password=123;" Npgsql.EntityFrameworkCore.PostgreSQL -Context "Campeonato_DbContext" -OutputDir Infrastructure\DataModels
 
 ```

# Criação da base de dados PostgreSQL

```postgresql
 CREATE TABLE tb_jogador(
 ID integer CONSTRAINT pk_id_jogador PRIMARY KEY,
 Nome varchar(30) NOT NULL, 
 Sobrenome varchar(40) NOT NULL,
 Data_Nasc date
);

 CREATE TABLE tb_instituicao (
 ID integer CONSTRAINT pk_id_instituicao PRIMARY KEY,
 nome varchar(35) UNIQUE NOT NULL
);

 CREATE TABLE tb_genero (
 ID integer CONSTRAINT pk_id_genero PRIMARY KEY,
 genero char(1) NOT NULL,
 UNIQUE(genero)
);

 CREATE TABLE tb_inscrito (
 ID SERIAL CONSTRAINT pk_id_inscrito PRIMARY KEY,
 jogador integer NOT NULL,
 instituicao integer NOT NULL,
 Data_Pub date,
 genero integer NOT NULL,
 FOREIGN KEY (jogador) REFERENCES tb_jogador (ID) ON DELETE CASCADE,
 FOREIGN KEY (instituicao) REFERENCES tb_instituicao (ID) ON DELETE CASCADE,
 FOREIGN KEY (genero) REFERENCES tb_genero (ID) ON DELETE CASCADE
);

```

# Program.cs

Inclusão da linha

```c#
builder.Services.AddDbContext<Campeonato_DbContext>();
```
