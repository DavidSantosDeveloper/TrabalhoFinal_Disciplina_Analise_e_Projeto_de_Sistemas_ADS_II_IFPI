using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FranciscoDavidSantosSousa.Models
{
    public class PagamentoComCartao:TipoDePagamento
    {
        public string? numeroDoCartao { get;set;}
        public string? bandeira { get;set;}
    }
}