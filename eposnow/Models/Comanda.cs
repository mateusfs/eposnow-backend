using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eposnow.Models
{
    public enum SituacaoEnum { INICIADA=1, CONCLUIDA=2 };

    public class Comanda
    {
        public int id { get; set; }
        public string nome { get; set; }

        public Mesa mesa { get; set; }

        public List<Produto> produtos { get; set; } = new List<Produto>();

        public SituacaoEnum situacao = new SituacaoEnum();

    }
}