using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using DataAccess.Context;

namespace DataAccess.Services
{
    public class PaymentAccountService
    {
        public PaymentAccount CreatePaymentAccount(string userId)
        {
            var number = Guid.NewGuid().ToString();

            using (var ctx = new ApplicationDbContext())
            {
                var user = ctx.Users.Where(u => u.Id == userId).FirstOrDefault();

                var account = new PaymentAccount()
                {
                    AccountNumber = number,
                    AccountName = "Счет №" + number,
                    User = user
                };

                ctx.PaymentAccounts.Add(account);
                ctx.SaveChanges();

                return account;
            }

        }
        public PaymentAccount GetPaymentAccountById(string paymentAccountId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.PaymentAccounts.Include("User").Include("Cards").Where(a => a.Id.ToString() == paymentAccountId).FirstOrDefault();
            }
        }
        public IEnumerable<PaymentAccount> GetPaymentAccountsByUserId(string userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.PaymentAccounts.Include("User").Include("Cards").Where(a => a.User.Id == userId).ToList();
            }
        }

        public List<PaymentAccount> GetPymentAccountsSortedByNumberByUserId(string userId)
        {
            return GetPaymentAccountsByUserId(userId).OrderBy(a => a.AccountNumber).ToList();
        }

        public List<PaymentAccount> GetPaymentAccountsSortedByBalanceByUserId(string userId)
        {
            return GetPaymentAccountsByUserId(userId).OrderByDescending(a => a.Balance).ToList();
        }

        public List<PaymentAccount> GetPaymentAccountsSortedByNameByUserId(string userId)
        {
            return GetPaymentAccountsByUserId(userId).OrderBy(a => a.AccountName).ToList();
        }

        public void Block(string accountId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var account = ctx.PaymentAccounts.Where(a => a.Id.ToString() == accountId).FirstOrDefault();
                account.IsBlocked = true;

                ctx.SaveChanges();
            }
        }

        public void Unblock(string accountId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var account = ctx.PaymentAccounts.Where(a => a.Id.ToString() == accountId).FirstOrDefault();
                account.IsBlocked = false;
                account.OnUnblocking = false;

                ctx.SaveChanges();
            }
        }

        public void SetOnUnblocking(string accountId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var account = ctx.PaymentAccounts.Where(a => a.Id.ToString() == accountId).FirstOrDefault();
                account.OnUnblocking = true;

                ctx.SaveChanges();
            }
        }

        public void Replenish(string accountId, decimal amount)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var account = ctx.PaymentAccounts.Where(a => a.Id.ToString() == accountId).First();
                account.Balance += amount;

                ctx.SaveChanges();
            }
        }
    }
}
