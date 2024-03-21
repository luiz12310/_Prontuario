Use Remissivas;

-- Alunos
Insert into Aluno values (1, 'Felipe Bento Murilo da Luz');
Insert into Aluno values (2, 'Kamilly Sara Rodrigues');
Insert into Aluno values (3, 'Larissa Elaine Stefany Aragão');
Insert into Aluno values (4, 'Eduarda Lorena Isadora Martins');
Insert into Aluno values (5, 'César Marcelo Hugo Almeida');

-- Cursos
Insert into Curso values (1, '3P', 'Eletrônica');
Insert into Curso values (2, '1N', 'Desenvolvimento de Sistemas');
Insert into Curso values (3, '3S', 'Jogos');
Insert into Curso values (4, '3G', 'Edificações');
Insert into Curso values (5, '3R', 'Eletrotécnica');

-- Documentos
Insert into documento values (1, 'RG');
Insert into documento values (2, 'CPF'); 
Insert into documento values (3, 'Foto 3x4');
Insert into documento values (4, 'Lauda');
Insert into documento values (5, 'Visto Confere');
Insert into documento values (6, 'SED e.fundamental');
Insert into documento values (7, 'SED e.medio');
Insert into documento values (8, 'H.E e.fundamental');
Insert into documento values (9, 'H.E e.medio');
Insert into documento values (10, 'H.E de transferencia original');

Insert into documentoAluno values (1, 1, 1);
Insert into documentoAluno values (1, 2, 1);
Insert into documentoAluno values (1, 3, 0);
Insert into documentoAluno values (1, 4, 0);
Insert into documentoAluno values (1, 5, 0);
Insert into documentoAluno values (1, 6, 0);
Insert into documentoAluno values (1, 7, 0);
Insert into documentoAluno values (1, 8, 0);
Insert into documentoAluno values (1, 9, 0);
Insert into documentoAluno values (1, 10, 0);

Insert into documentoAluno values (2, 1, 1);
Insert into documentoAluno values (2, 2, 1);
Insert into documentoAluno values (2, 3, 0);
Insert into documentoAluno values (2, 4, 1);
Insert into documentoAluno values (2, 5, 0);
Insert into documentoAluno values (2, 6, 0);
Insert into documentoAluno values (2, 7, 0);
Insert into documentoAluno values (2, 8, 0);
Insert into documentoAluno values (2, 9, 0);
Insert into documentoAluno values (2, 10, 0);

Insert into documentoAluno values (3, 1, 1);
Insert into documentoAluno values (3, 2, 1);
Insert into documentoAluno values (3, 3, 0);
Insert into documentoAluno values (3, 4, 1);
Insert into documentoAluno values (3, 5, 0);
Insert into documentoAluno values (3, 6, 0);
Insert into documentoAluno values (3, 7, 0);
Insert into documentoAluno values (3, 8, 0);
Insert into documentoAluno values (3, 9, 0);
Insert into documentoAluno values (3, 10, 0);

Insert into documentoAluno values (4, 1, 1);
Insert into documentoAluno values (4, 2, 1);
Insert into documentoAluno values (4, 3, 0);
Insert into documentoAluno values (4, 4, 1);
Insert into documentoAluno values (4, 5, 0);
Insert into documentoAluno values (4, 6, 0);
Insert into documentoAluno values (4, 7, 0);
Insert into documentoAluno values (4, 8, 0);
Insert into documentoAluno values (4, 9, 0);
Insert into documentoAluno values (4, 10, 0);

Insert into documentoAluno values (5, 1, 1);
Insert into documentoAluno values (5, 2, 1);
Insert into documentoAluno values (5, 3, 0);
Insert into documentoAluno values (5, 4, 1);
Insert into documentoAluno values (5, 5, 0);
Insert into documentoAluno values (5, 6, 0);
Insert into documentoAluno values (5, 7, 0);
Insert into documentoAluno values (5, 8, 0);
Insert into documentoAluno values (5, 9, 0);
Insert into documentoAluno values (5, 10, 0);


Insert into Prontuario values (1, 1, 'Acima da média');
Insert into Prontuario values (1, 2, 'Muito bom aluno');
Insert into Prontuario values (2, 2, 'Mediano');
Insert into Prontuario values (3, 3, 'Péssimo');
Insert into Prontuario values (4, 4, 'Muito bom aluno');
Insert into Prontuario values (5, 5, 'Muito bom aluno');

Insert into diploma (cd_aluno, cd_curso, cd_diploma, cd_livro, cd_pagina, dt_conclusao, dt_emissao, dt_retirada)
values (1, 1, 'd11', '55-b', '59-9', "2000-12-12", "2000-12-13", NULL);

Insert into diploma (cd_aluno, cd_curso, cd_diploma, cd_livro, cd_pagina, dt_conclusao, dt_emissao, dt_retirada)
values (2, 2, 'd22', '55-c', '60-0', "2001-12-12", "2001-12-13", "2001-12-14" );

Insert into diploma (cd_aluno, cd_curso, cd_diploma, cd_livro, cd_pagina, dt_conclusao, dt_emissao, dt_retirada)
values (3, 3, 'd33', '55-d', '60-1', "2002-12-12", "2002-12-13", "2002-12-14" );

Insert into diploma (cd_aluno, cd_curso, cd_diploma, cd_livro, cd_pagina, dt_conclusao, dt_emissao, dt_retirada)
values (4, 4, 'd44', '55-e', '60-2', "2003-12-12", "2003-12-13", "2003-12-14" );

Insert into diploma (cd_aluno, cd_curso, cd_diploma, cd_livro, cd_pagina, dt_conclusao, dt_emissao, dt_retirada)
values (5, 5, 'd55', '55-f', '60-3', "2004-12-12", "2004-12-13", "2004-12-14" );