using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using DataAccess.Context;

namespace DataAccess.Services
{
    public class PaymentService
    {
        /*
        public IEnumerable<Payment> GetPaymentsByUser(ApplicationUser user)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Payments.Where(p => p.User.Equals(user)).ToList();
            }
        }

        public IEnumerable<Payment> GetPaymentsByUserSortedByDate(ApplicationUser user, bool byNewerDate = true)
        {
            return byNewerDate == true 
                ? GetPaymentsByUser(user).OrderByDescending(p => p.PaymentDate)
                : GetPaymentsByUser(user).OrderBy(p => p.PaymentDate);
        }

        public IEnumerable<Payment> GetPaymentsByUserSortedByNumber(ApplicationUser user)
        {
            return GetPaymentsByUser(user).OrderBy(p => p.Number);
        }

        public Payment Create(decimal sum, PaymentAccount accountSender, string cardReciever)
        {
            if (accountSender.Balance < sum)
                throw new Exception();
            else return new Payment() { User = accountSender.User };
        }

        public void Pay(Payment payment)
        {
           
        }
        */
    }
}
