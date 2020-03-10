using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using DataAccess.Context;

namespace DataAccess.Services
{
    public class PaymentAccountService
    {
        public IEnumerable<PaymentAccount> GetPaymentAccountsByUser(string userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.PaymentAccounts.Include("User").Include("CreditCards").Where(a => a.User.Id == userId).ToList();
            }
        }

        public IEnumerable<PaymentAccount> GetPaymentAccountsByUserSortedByNumber(string userId)
        {
            return GetPaymentAccountsByUser(userId).OrderBy(a => a.AccountNumber).ToList();
        }

        public IEnumerable<PaymentAccount> GetPaymentAccountsByUserSortedByBalance(string userId)
        {
            return GetPaymentAccountsByUser(userId).OrderByDescending(a => a.Balance).ToList();
        }

        public IEnumerable<PaymentAccount> GetPaymentAccountsByUserSortedByName(string userId)
        {
            return GetPaymentAccountsByUser(userId).OrderBy(a => a.AccountName).ToList();
        }

        public void BlockAccount(string userId, string accountId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.PaymentAccounts.Where(a => a.User.Id == userId && a.Id.ToString() == accountId);
                var account = query.First();

                account.IsBlocked = true;
            }
        }

        public void UnblockAccount(string userId, string accountId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.PaymentAccounts.Where(a => a.User.Id == userId && a.Id.ToString() == accountId);
                var account = query.First();

                account.IsBlocked = false;
            }
        }
    }
}
