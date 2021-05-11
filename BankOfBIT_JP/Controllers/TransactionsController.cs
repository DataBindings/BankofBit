using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BankOfBIT_JP.Data;
using BankOfBIT_JP.Models;

namespace BankOfBIT_JP.Controllers
{
    public class TransactionsController : Controller
    {
        private BankOfBIT_JPContext db = new BankOfBIT_JPContext();

        // GET: Transactions
        public ActionResult Index()
        {
            var transactions = db.Transactions.Include(t => t.BankAccount).Include(t => t.TransactionType);
            return View(transactions.ToList());
        }

        // GET: Transactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {
            // Jeremie - Modified to display AccountNumer instead of BankAccountId
            ViewBag.BankAccountId = new SelectList(db.BankAccounts, "BankAccountId", "AccountNumber");
            ViewBag.TransactionTypeId = new SelectList(db.TransactionTypes, "TransactionTypeId", "Description");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransactionId,TransactionNumber,BankAccountId,TransactionTypeId,Deposit,Withdrawal,DateCreated,Notes")] Transaction transaction)
        {
            // Jeremie - Add set next transaction number to utilize stored procedure
            transaction.SetNextTransactionNumber();

            if (ModelState.IsValid)
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Jeremie - Modified to display AccountNumer instead of BankAccountId
            ViewBag.BankAccountId = new SelectList(db.BankAccounts, "BankAccountId", "AccountNumber", transaction.BankAccountId);
            ViewBag.TransactionTypeId = new SelectList(db.TransactionTypes, "TransactionTypeId", "Description", transaction.TransactionTypeId);
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            // Jeremie - Modified to display AccountNumer instead of BankAccountId
            ViewBag.BankAccountId = new SelectList(db.BankAccounts, "BankAccountId", "AccountNumber", transaction.BankAccountId);
            ViewBag.TransactionTypeId = new SelectList(db.TransactionTypes, "TransactionTypeId", "Description", transaction.TransactionTypeId);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransactionId,TransactionNumber,BankAccountId,TransactionTypeId,Deposit,Withdrawal,DateCreated,Notes")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            // Jeremie - Modified to display AccountNumer instead of BankAccountId
            ViewBag.BankAccountId = new SelectList(db.BankAccounts, "BankAccountId", "AccountNumber", transaction.BankAccountId);
            ViewBag.TransactionTypeId = new SelectList(db.TransactionTypes, "TransactionTypeId", "Description", transaction.TransactionTypeId);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            db.Transactions.Remove(transaction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
