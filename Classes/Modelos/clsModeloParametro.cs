using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prontuario.Classes.Modelos
{
    public class clsModeloParametro
    {
        public string NomeParametro { get; set; }
        public string ValorParametro { get; set; }

        public clsModeloParametro(string nome, string valor)
        {
            this.NomeParametro = nome;
            this.ValorParametro = valor;

        }
    }
}