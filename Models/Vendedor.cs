using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FranciscoDavidSantosSousa.Models;
//precisa da anotacao de tipo para que posa usar [key]
using System.ComponentModel.DataAnnotations;


namespace FranciscoDavidSantosSousa.Models
{
    public class Vendedor
    {
       [Key]
        public int IdVendedor { get;set;}
        public string? nome { get;set;}

        //RELACIONAMENTOS
        public int? NotaDeVendaId { get;set;}
        public List<NotaDeVenda>? NotaDeVenda { get; set;}

    }
}