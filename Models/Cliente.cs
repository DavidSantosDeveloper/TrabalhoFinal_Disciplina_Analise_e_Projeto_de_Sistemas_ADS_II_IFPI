using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//precisa da anotacao de tipo para que posa usar [key]
using FranciscoDavidSantosSousa.Models;
using System.ComponentModel.DataAnnotations;


namespace FranciscoDavidSantosSousa.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente{get;set;}
        public string? nome { get;set;}

        // RELACIONAMENTOS
        public int? NotaDeVendaId { get;set;}
        public List<NotaDeVenda>? NotaDeVenda { get; set;}
    }
}