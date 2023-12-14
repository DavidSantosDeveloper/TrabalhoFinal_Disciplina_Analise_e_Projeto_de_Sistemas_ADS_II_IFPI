using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FranciscoDavidSantosSousa.Models;
//precisa da anotacao de tipo para que posa usar [key]
using System.ComponentModel.DataAnnotations;


namespace FranciscoDavidSantosSousa.Models
{
    public class NotaDeVenda
    {
       

        [Key]
        public int IdNotaDeVenda{get;set;}
        public DateOnly? DataDaVenda{get;set;}
        public bool? tipo{get;set;}

        public bool? cancelado {get;set;}
        public bool? devolvido {get;set;}

        //METODOS
        public bool cancelar() {
            cancelado = true;
            return true;           
        }
        public bool devolver(){
            devolvido = true;
            return true;
        }

        //RELACIONAMENTOS
        public int? TipoDePagamentoId{get;set;}
        public TipoDePagamento? TipoDePagamento{get;set;}

        public int? PagamentoId{get;set;}
        public List<Pagamento>? Pagamento{get;set;}

        public int? TransportadoraId{get;set;}
        public Transportadora? Transportadora{get;set;}

        public int? VendedorId{get;set;}
        public Vendedor? Vendedor{get;set;}

        public int? ClienteId{get;set;}
        public  Cliente? Cliente{get;set;}

        public int? ItemId{get;set;}
        public List<Item>? Item {get;set;}

    }
}