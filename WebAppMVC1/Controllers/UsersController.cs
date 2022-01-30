using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVC1.Models;
using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppMVC1.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UsersController
        public ActionResult Index()
        {
            var userId = HttpContext.Request.Cookies["userId"];
            List<Invoice> inv = _context.Invoices.Where(x => x.UserId == userId).ToList();

            List<long?> totalAm = TotalAmount(inv);
            List<InvoiceLine> invLines = _context.InvoiceLines.ToList();

            ViewData["TotalAmount"] = totalAm;
            ViewBag.InvLines = new SelectList(invLines);

            ViewBag.UserName = HttpContext.Request.Cookies["username"];

            List<string> invN = new List<string>();

            foreach (var item in _context.Invoices)
            {
                invN.Add(item.Name);
            }
            ViewBag.InvNames = invN;

            return View(inv);
        }


        [HttpPost]
        public ActionResult InvoiceLines(IFormCollection frm)
        {
            string button = frm["Invoice"].ToString();
            List<InvoiceLine> invl = new List<InvoiceLine>();
            List<Product> prod = new List<Product>();
            List<long?> total = new List<long?>();

            List<Invoice> invoice = _context.Invoices.Where(x => x.Name == button).ToList();

            foreach (var item in invoice)
            {
                invl = _context.InvoiceLines.Where(x => x.InvoiceId == item.InvoiceId).ToList();

                foreach (var elem in invl)
                {
                    List<Product> prodx = _context.Products.Where(x => x.ProductId == elem.ProductId).ToList();
                    foreach (var pr in prodx)
                    {
                        total.Add(pr.Price * elem.Quantity);
                    }
                    prod.Add(prodx[0]);
                }
            }
            ViewData["ILiness"] = invl;

            ViewBag.InvLin = invl;
            ViewBag.Products = prod;
            ViewBag.Total = total;

            ViewBag.Price = "555888";

            //return RedirectToAction(nameof(Index));
            return View();
        }

        [HttpPost]
        public ActionResult Index(IFormCollection frm)
        {
            string button = frm["Invoice"].ToString();
            List<InvoiceLine> invl = new List<InvoiceLine>();
            List<Product> prod = new List<Product>();
            List<long?> total = new List<long?>();

            List<Invoice> invoice = _context.Invoices.Where(x => x.Name == button).ToList();

            foreach (var item in invoice)
            {
                invl = _context.InvoiceLines.Where(x => x.InvoiceId == item.InvoiceId).ToList();

                foreach (var elem in invl)
                {
                    List<Product> prodx = _context.Products.Where(x => x.ProductId == elem.ProductId).ToList();
                    foreach (var pr in prodx)
                    {
                        total.Add(pr.Price * elem.Quantity);
                    }
                    prod.Add(prodx[0]);
                }
            }
            ViewData["ILiness"] = invl;

            ViewBag.InvLin = invl;
            ViewBag.Products = prod;
            ViewBag.Total = total;

            ViewBag.Price = "555888";

            //return RedirectToAction(nameof(Index));
            return View();
        }

        public List<long?> TotalAmount(List<Invoice> inv)
        {
            long? amount = 0;
            List<long?> totalAm = new List<long?>();

            foreach (var item in inv)
            {
                List<InvoiceLine> invl = _context.InvoiceLines.Where(x => x.InvoiceId == item.InvoiceId).ToList();

                foreach (var elem in invl)
                {
                    List<Product> prod = _context.Products.Where(x => x.ProductId == elem.ProductId).ToList();

                    foreach (var pr in prod)
                    {
                        amount += pr.Price * elem.Quantity;
                    }
                }
                totalAm.Add(amount);

                amount = 0;
            }

            return totalAm;
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Account account)
        {
            try
            {
                foreach (var item in _context.Users)
                {
                    if (item.Username == account.Username && item.Password == account.Password)
                    {
                        HttpContext.Response.Cookies.Append("username", account.Username);
                        HttpContext.Response.Cookies.Append("password", account.Password);
                        HttpContext.Response.Cookies.Append("userId", item.UserId);

                        return RedirectToAction(nameof(Index));
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
