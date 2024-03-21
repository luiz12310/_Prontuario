using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prontuario.Classes.Modelos
{
    public class clsModeloDocumentoAluno
    {
        public clsModeloAluno Aluno { get; set; }
        public clsModeloDocumento Documento { get; set; }
        public bool consta { get; set; }

        public clsModeloDocumentoAluno(int codigoDocumento, int codigoAluno, bool constaDocumento)
        {
            Aluno = new clsModeloAluno(codigoAluno);
            Documento = new clsModeloDocumento(codigoDocumento);
            this.consta = constaDocumento;
        }
    }
}