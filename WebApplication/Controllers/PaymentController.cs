using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DataAccess.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebApplication.Models;


namespace WebApplication.Controllers
{
    public class PaymentController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public PaymentController()
        {
        }

        public PaymentController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult MakePayment()
        {
            PaymentAccountService service = new PaymentAccountService();

            var paymentAccounts = service.GetPaymentAccountsByUserId(User.Identity.GetUserId())
                .Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.AccountName });

            return View(new MakePaymentViewModel { PaymentAccounts = paymentAccounts });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakePayment(MakePaymentViewModel model)
        {
            if (ModelState.IsValid)
            {
                PaymentAccountService service = new PaymentAccountService();
                var paymentAccount = service.GetPaymentAccountById(model.PaymentAccountId);
                
                PaymentService paymentService = new PaymentService();
                paymentService.Create(model.Amount, model.PaymentAccountId);

                var accounts = service.GetPaymentAccountsByUserId(User.Identity.GetUserId());
                var payments = paymentService.GetPaymentsByUserId(User.Identity.GetUserId());
            }

            return RedirectToAction("Index", "Manage");
        }

        public ActionResult ViewPayments()
        {
            PaymentService service = new PaymentService();
            var payments = service.GetPaymentsByUserId(User.Identity.GetUserId());

            return View(payments);
        }

        public ActionResult SortPaymentsByNumber()
        {
            PaymentService service = new PaymentService();
            var sortedPayments = service.GetPaymentsSortedByNumberByUserId(User.Identity.GetUserId());

            return View("ViewPayments", sortedPayments);
        }

        public ActionResult SortPaymentsByDate(bool? reversed)
        {
            if (reversed == null)
                reversed = true;
            else reversed = !reversed;

            PaymentService service = new PaymentService();
            var sortedPayments = service.GetPaymentsSortedByDateByUserId(User.Identity.GetUserId(), (bool)reversed);

            ViewBag.Reversed = reversed;

            return View("ViewPayments", sortedPayments);
        }
    }
}