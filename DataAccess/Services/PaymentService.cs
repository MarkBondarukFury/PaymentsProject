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
        public IEnumerable<Payment> GetPaymentsByUserId(string userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var payments = ctx.Payments.Include("User").Include("State").Where(p => p.User.Id == userId).ToList();
                return payments;
            }
        }

        public IEnumerable<Payment> GetPaymentsByUserIdSortedByDate(string userId, bool byNewerDate = true)
        {
            return byNewerDate == true 
                ? GetPaymentsByUserId(userId).OrderByDescending(p => p.PaymentDate).ToList()
                : GetPaymentsByUserId(userId).OrderBy(p => p.PaymentDate).ToList();
        }

        public IEnumerable<Payment> GetPaymentsByUserIdSortedByNumber(string userId)
        {
            return GetPaymentsByUserId(userId).OrderBy(p => p.Number).ToList();
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
    }
}
