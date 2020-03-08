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
        public PaymentState State { get; set; }

        public Payment()
        {
            //Id = Guid.NewGuid();
        }
    }
}
