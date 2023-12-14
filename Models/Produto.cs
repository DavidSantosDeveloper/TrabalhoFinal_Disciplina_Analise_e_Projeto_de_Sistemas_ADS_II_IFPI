using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FranciscoDavidSantosSousa.Models;
//precisa da anotacao de tipo para que posa usar [key]
using System.ComponentModel.DataAnnotations;


namespace FranciscoDavidSantosSousa.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto {get;set;}
        public string? nome {get;set;}
        public int? quantidade {get;set;}
        public double? preco {get;set;}

        //RELACIONAMENTOS 
        public int? ItemId{get;set;}
        public List<Item>? Item {get;set;}

        public int? MarcaId{get;set;}
        public Marca? Marca { get;set;}
    }
}