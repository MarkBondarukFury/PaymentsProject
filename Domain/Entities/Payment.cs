using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.PaymentStates;

namespace Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Number { get; set; }
        public PaymentState State { get; set; }
        public ApplicationUser User { get; set; }

        public Payment()
        {
            Id = Guid.NewGuid();
            Number = GenerateNumber();
        }
        private string GenerateNumber()
        {
            return PaymentDate == default(DateTime)
                ? DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString()
                : PaymentDate.Year.ToString() + PaymentDate.Month.ToString();
        }
    }
}
