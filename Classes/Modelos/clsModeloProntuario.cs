using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prontuario.Classes.Modelos
{
    public class clsModeloProntuario
    {
        public clsModeloAluno Aluno { get; set; }
        public clsModeloCurso Curso { get; set; }
        public string descricao { get; set; }


        public int codigoCurso { get; set; }
        public int codigoAluno { get; set; }

        public clsModeloProntuario(int codigoAluno, int codigoCurso, string descricao)
        {
            Aluno = new clsModeloAluno(codigoAluno);
            Curso = new clsModeloCurso(codigoCurso);
            this.descricao = descricao;
            this.codigoCurso = codigoCurso;
            this.codigoAluno = codigoAluno;
        }
    }
}