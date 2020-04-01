using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.PaymentStates;
using DataAccess.Context;

namespace DataAccess.Services
{
    public class PaymentService
    {
        public IEnumerable<Payment> GetPaymentsByUserId(string userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Payments.Include("User").Include("State").Where(p => p.User.Id == userId).ToList();
            }
        }

        public List<Payment> GetPaymentsSortedByDateByUserId(string userId, bool byNewerDate = true)
        {
            return byNewerDate == true
            ? GetPaymentsByUserId(userId).OrderByDescending(p => p.PaymentDate).ToList()
            : GetPaymentsByUserId(userId).OrderBy(p => p.PaymentDate).ToList();
        }

        public List<Payment> GetPaymentsSortedByNumberByUserId(string userId)
        {
            return GetPaymentsByUserId(userId).OrderBy(p => p.Number).ToList();
        }

        public void Create(decimal sum, string accountSenderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var account = ctx.PaymentAccounts.Include("User").Where(a => a.Id.ToString() == accountSenderId).FirstOrDefault();
                if (account.Balance >= sum)
                {
                    account.Balance -= sum;
                    
                    ctx.Payments.Add(new Payment() { Amount = sum, User = account.User, State = new PaymentSentState() });
                    ctx.SaveChanges();
                }
            }
        }
    }
}
