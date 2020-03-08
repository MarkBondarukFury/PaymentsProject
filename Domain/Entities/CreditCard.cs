using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Entities
{
    public class CreditCard
    {
        public string CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        [MaxLength(3)]
        public string VerificationCode { get; set; }
        public PaymentAccount PaymentAccount { get; set; }

        public CreditCard()
        {
            //ExpiryDate = new DateTime(DateTime.Now.Year + 4, DateTime.Now.Month, DateTime.Now.Day);
        }
    }
}
