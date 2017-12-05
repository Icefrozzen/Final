using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PessoasWeb.Models
{
    public class Pessoa
    {
        //Campo (field)
        private int pessoaId;

        //Propriedade
        public int PessoaId
        {
            get { return pessoaId; }
            set { pessoaId = value; }
        }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }


    }
}