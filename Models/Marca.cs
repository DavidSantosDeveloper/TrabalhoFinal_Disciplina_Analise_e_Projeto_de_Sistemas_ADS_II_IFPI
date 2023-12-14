using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FranciscoDavidSantosSousa.Models;
//precisa da anotacao de tipo para que posa usar [key]
using System.ComponentModel.DataAnnotations;


namespace FranciscoDavidSantosSousa.Models
{
    public class Marca
    {
        [Key]
        public int IdMarca {get;set;}
        public string? descricao {get;set;}
        public int? ProdutoId{get;set;}
        public List<Produto>? Produto {get;set;}
    }
}