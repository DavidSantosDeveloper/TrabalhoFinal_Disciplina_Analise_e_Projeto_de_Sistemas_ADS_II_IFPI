using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FranciscoDavidSantosSousa.Models;
//precisa da anotacao de tipo para que posa usar [key]
using System.ComponentModel.DataAnnotations;


namespace FranciscoDavidSantosSousa.Models
{
    public class Pagamento
    {
        [Key]
        public int IdPagamento {get;set;}
        public DateOnly? dataLimite {get;set;}
        public double? valor {get;set;}
        public bool? pago {get; set;}

        //RELACIONAMENTO
        public int?  NotaDevendaId { get;set;}
        public NotaDeVenda? NotaDeVenda { get;set;}

    }
}