using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PaymentStates
{
    public abstract class PaymentState
    {
        public Guid Id { get; set; }
        public PaymentState()
        {
            Id = Guid.NewGuid();
        }
    }
}
