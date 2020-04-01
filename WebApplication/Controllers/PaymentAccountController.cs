using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebApplication.Models;
using DataAccess.Services;
using Domain.Entities;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class PaymentAccountController : Controller
    {
        public ActionResult CreatePaymentAccount()
        {
            return View();
        }

        public ActionResult BlockPaymentAccount(string accountId)
        {
            PaymentAccountService service = new PaymentAccountService();
            service.Block(accountId);

            return RedirectToAction("ViewPaymentAccounts");
        }

        public ActionResult UnblockPaymentAccount(string accountId)
        {
            PaymentAccountService service = new PaymentAccountService();
            service.Unblock(accountId);

            return RedirectToAction("ViewPaymentAccounts");
        }

        public ActionResult ReplenishPaymentAccount(string accountId)
        {
            PaymentAccountService service = new PaymentAccountService();
            ViewBag.Account = service.GetPaymentAccountById(accountId);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReplenishPaymentAccount(ReplenishAccountViewModel model)
        {
            PaymentAccountService service = new PaymentAccountService();
            service.Replenish(model.PaymentAccount.User.Id, model.Amount);

            return RedirectToAction("ViewPaymentAccounts");
        }

        public ActionResult ViewPaymentAccounts()
        {
            PaymentAccountService service = new PaymentAccountService();
            var accounts = service.GetPaymentAccountsByUserId(User.Identity.GetUserId());

            return View(accounts);
        }

        public ActionResult SortPaymentAccountsByName()
        {
            PaymentAccountService service = new PaymentAccountService();
            var sortedAccounts = service.GetPaymentAccountsSortedByNameByUserId(User.Identity.GetUserId());

            return View("ViewPaymentAccounts", sortedAccounts);
        }

        public ActionResult SortPaymentAccountsByNumber()
        {
            PaymentAccountService service = new PaymentAccountService();
            var sortedAccounts = service.GetPymentAccountsSortedByNumberByUserId(User.Identity.GetUserId());

            return View("ViewPaymentAccounts", sortedAccounts);
        }

        public ActionResult SortPaymentAccountsByBalance()
        {
            PaymentAccountService service = new PaymentAccountService();
            var sortedAccounts = service.GetPaymentAccountsSortedByBalanceByUserId(User.Identity.GetUserId());

            return View("ViewPaymentAccounts", sortedAccounts);
        }

        public ActionResult PaymentAccountInfo(string paymentAccountId)
        {
            PaymentAccountService service = new PaymentAccountService();
            var paymentAccount = service.GetPaymentAccountById(paymentAccountId);

            return View(paymentAccount);
        }
    }
}