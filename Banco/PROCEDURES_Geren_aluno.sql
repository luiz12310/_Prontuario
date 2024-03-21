DELIMITER $$

DROP PROCEDURE IF EXISTS ListarAlunos$$
CREATE PROCEDURE ListarAlunos(vPesquisa VARCHAR(200))
BEGIN
	IF vPesquisa <> '' THEN
		SELECT cd_aluno, nm_aluno FROM aluno WHERE nm_aluno LIKE CONCAT('%', vPesquisa, '%')
        OR cd_aluno LIKE CONCAT('%', vPesquisa, '%');
	ELSE
		SELECT cd_aluno, nm_aluno FROM aluno;
    END IF;
END$$

DROP PROCEDURE IF EXISTS PreencherDadosAluno$$
CREATE PROCEDURE PreencherDadosAluno(vCodigo INT)
BEGIN
	SELECT nm_aluno FROM aluno WHERE cd_aluno = vCodigo;
END$$

DROP PROCEDURE IF EXISTS ListarDocumentos$$
CREATE PROCEDURE ListarDocumentos(vCodigo INT)
BEGIN
	SELECT da.cd_documento, da.cd_aluno, da.ic_consta FROM documento doc 
    JOIN documentoAluno da ON(da.cd_documento = doc.cd_documento) WHERE da.cd_aluno = vCodigo;
END$$

DROP PROCEDURE IF EXISTS PreencherDocumento$$
CREATE PROCEDURE PreencherDocumento(vCodigo INT)
BEGIN
	SELECT nm_documento FROM documento WHERE cd_documento = vCodigo;
END$$

DROP PROCEDURE IF EXISTS ListarProntuario$$
CREATE PROCEDURE ListarProntuario(vCodigo INT)
BEGIN
	SELECT cd_aluno, cd_curso, ds_obs FROM Prontuario
    WHERE cd_aluno = vCodigo;
END$$

DROP PROCEDURE IF EXISTS PreencherCurso$$
CREATE PROCEDURE PreencherCurso(vCodigo INT)
BEGIN
	SELECT nm_curso, sg_curso FROM curso 
    WHERE cd_curso = vCodigo;
END$$

DROP PROCEDURE IF EXISTS ListarDadosCurso$$
CREATE PROCEDURE ListarDadosCurso(vCodigoCurso INT, vCodigoAluno INT)
BEGIN
	SELECT cd_aluno, cd_curso FROM diploma
    WHERE cd_aluno = vCodigoAluno AND cd_curso = vCodigoCurso;
END$$

DROP PROCEDURE IF EXISTS PreencherTipoDiploma$$
CREATE PROCEDURE PreencherTipoDiploma(vCodigo INT)
BEGIN
	SELECT cd_tipo_diploma, nm_tipo_diploma FROM tipo_diploma
    WHERE cd_tipo_diploma = vCodigo;
END$$

DROP PROCEDURE IF EXISTS PreencherDiploma$$
CREATE PROCEDURE PreencherDiploma(vCodigoAluno INT, vCodigoCurso INT)
BEGIN
	SELECT * FROM diploma WHERE cd_aluno = vCodigoAluno AND cd_curso = vCodigoCurso;
END$$

DROP PROCEDURE IF EXISTS AtualizarDocumentos$$
CREATE PROCEDURE AtualizarDocumentos(vCodigoAluno INT, vCodigoDocumento INT, vConsta VARCHAR(5))
BEGIN
	DECLARE BOOLRESULTADO INT DEFAULT 0; 
	IF vConsta = 'true' THEN
		SET BOOLRESULTADO = 1;
	ELSE
		SET BOOLRESULTADO = 0;
	END IF;
    
	UPDATE documentoAluno SET ic_consta = BOOLRESULTADO 
    WHERE cd_aluno = vCodigoAluno AND cd_documento = vCodigoDocumento;
END$$

DROP PROCEDURE IF EXISTS RetirarDiploma$$
CREATE PROCEDURE RetirarDiploma(vCodigoAluno INT, vCodigoDiploma VARCHAR(200), vCodigoCurso INT)
BEGIN
	UPDATE diploma SET dt_retirada = CURRENT_DATE() 
    WHERE cd_aluno = vCodigoAluno AND cd_curso = vCodigoCurso
	AND cd_diploma = vCodigoDiploma;
END$$

DROP PROCEDURE IF EXISTS CriarDiploma$$
CREATE PROCEDURE CriarDiploma(vCodigoAluno INT, vCodigoCurso INT, vCodigoDiploma VARCHAR(20), vCodigoLivro VARCHAR(20), vCodigoPagina VARCHAR(20), vDataConclusao VARCHAR(20), vDataEmissao VARCHAR(20))
BEGIN
	INSERT INTO diploma(cd_aluno, cd_curso, cd_diploma, cd_livro, cd_pagina, dt_conclusao, dt_emissao, dt_retirada) VALUES (vCodigoAluno, vCodigoCurso, vCodigoDiploma, vCodigoLivro, vCodigoPagina, vDataConclusao, vDataEmissao, NULL);
END$$

DELIMITER ;