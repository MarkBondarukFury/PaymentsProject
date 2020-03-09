using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using DataAccess.Context;

namespace DataAccess.Services
{
    /*
    public class PaymentAccountService
    {
        public IEnumerable<PaymentAccount> GetPaymentAccountsByUser(ApplicationUser user)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.PaymentAccounts.Where(a => a.User.Equals(user)).ToList();
            }
        }

        public IEnumerable<PaymentAccount> GetPaymentAccountsByUserSortedByNumber(ApplicationUser user)
        {
            return GetPaymentAccountsByUser(user).OrderBy(a => a.AccountNumber);
        }

        public IEnumerable<PaymentAccount> GetPaymentAccountsByUserSortedByBalance(ApplicationUser user)
        {
            return GetPaymentAccountsByUser(user).OrderBy(a => a.Balance);
        }

        public IEnumerable<PaymentAccount> GetPaymentAccountsByUserSortedByName(ApplicationUser user)
        {
            return GetPaymentAccountsByUser(user).OrderBy(a => a.AccountName);
        }
    }
    */
}
