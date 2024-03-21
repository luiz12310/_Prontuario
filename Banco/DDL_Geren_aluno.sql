DROP SCHEMA IF EXISTS Remissivas;
CREATE SCHEMA Remissivas;
USE Remissivas;

CREATE TABLE Aluno 
(
  cd_aluno INT,
  nm_aluno VARCHAR(200),
  CONSTRAINT pk_Aluno PRIMARY KEY (cd_aluno)
);

CREATE  TABLE Curso 
(
  cd_curso VARCHAR(20),
  sg_curso VARCHAR(5),
  nm_curso VARCHAR(200),
  CONSTRAINT pk_Curso PRIMARY KEY (cd_curso)
);

CREATE  TABLE Prontuario 
(
  cd_aluno INT,
  cd_curso VARCHAR(20),
  ds_obs TEXT,
  CONSTRAINT pk_Prontuario PRIMARY KEY (cd_aluno, cd_curso),
  CONSTRAINT fk_Prontuario_Aluno FOREIGN KEY (cd_aluno)
    REFERENCES Aluno (cd_aluno),
  CONSTRAINT fk_Prontuario_Curso FOREIGN KEY (cd_curso)
    REFERENCES Curso (cd_curso)
);

CREATE  TABLE Diploma 
(
  cd_aluno INT,
  cd_curso VARCHAR(20),
  cd_diploma VARCHAR(20),
  cd_livro VARCHAR(20),
  cd_pagina VARCHAR(20),
  dt_conclusao DATE,
  dt_emissao DATE,
  dt_retirada DATE,
  CONSTRAINT pk_Diploma PRIMARY KEY (cd_diploma, cd_aluno, cd_curso),
  CONSTRAINT fk_Diploma_Prontuario FOREIGN KEY (cd_aluno, cd_curso)
    REFERENCES Prontuario (cd_aluno, cd_curso)
);

CREATE TABLE Documento 
(
  cd_documento INT,
  nm_documento VARCHAR(45),
  CONSTRAINT pk_Documento PRIMARY KEY (cd_documento)
);

CREATE TABLE documentoAluno 
(
  cd_aluno INT,
  cd_documento INT,
  ic_consta BOOL,
  CONSTRAINT pk_documentoAluno PRIMARY KEY (cd_aluno, cd_documento),
  CONSTRAINT fk_documentoAluno_Documento FOREIGN KEY (cd_documento)
    REFERENCES Documento (cd_documento),
  CONSTRAINT fk_documentoAluno FOREIGN KEY (cd_aluno)
    REFERENCES Aluno (cd_aluno)
);