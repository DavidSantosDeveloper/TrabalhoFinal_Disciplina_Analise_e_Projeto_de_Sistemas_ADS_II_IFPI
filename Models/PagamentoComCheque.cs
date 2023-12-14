using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace FranciscoDavidSantosSousa.Models
{
    public class PagamentoComCheque:TipoDePagamento
    {
        public int? banco { get;set;}
        public string? nomeDoBanco { get;set;}
    }
}