using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Domain.Entities;

namespace WebApplication.Models
{
    public class MakePaymentViewModel
    {
        public IEnumerable<SelectListItem> PaymentAccounts { get; set; }
        public string PaymentAccountId { get; set; }

        //public PaymentAccount PaymentAccount { get; set; }
        
        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

    }

    public class ReplenishAccountViewModel
    {
        [Required]
        [Display(Name = "Счет")]
        public PaymentAccount PaymentAccount { get; set; }

        [Required]
        [Display(Name = "Сумма")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
    }
}