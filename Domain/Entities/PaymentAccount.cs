using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PaymentAccount
    {
        public Guid Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public bool IsBlocked { get; set; }
        public ICollection<CreditCard> CreditCards { get; set; }

        public PaymentAccount()
        {
            Id = Guid.NewGuid();
        }
    }
}
