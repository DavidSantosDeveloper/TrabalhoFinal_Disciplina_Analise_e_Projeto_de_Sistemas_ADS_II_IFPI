using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//precisa da anotacao de tipo para que posa usar [key]
using FranciscoDavidSantosSousa.Models;
using System.ComponentModel.DataAnnotations;


namespace FranciscoDavidSantosSousa.Models
{
    public class Item
    {
        [Key]
        public int IdItem {get;set;}
        public double? preco{get;set;}
        public int? percentual {get;set;}
        public int? quantidade {get;set;}

        //RELACIONAMENTOS
        public int? ProdutoId {get;set;}
        public Produto? Produto {get;set;}
        public int? NotaDeVendaId {get;set;}
        public NotaDeVenda? NotaDeVenda {get;set;}

    }

}