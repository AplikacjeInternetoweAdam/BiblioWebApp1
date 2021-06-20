using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BiblioWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BiblioWebApp.Controllers
{
    public class BibliosController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();


        // GET: Biblios
        public ActionResult Index(string Szukaj)
        {
            //return View(db.Biblios.ToList());
            return View(db.Biblios.Where(x => x.Kategoria.Contains(Szukaj) || Szukaj == null).ToList());
        }

        
        // GET: Biblios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biblio biblio = db.Biblios.Find(id);
            if (biblio == null)
            {
                return HttpNotFound();
            }
            return View(biblio);
        }

        // GET: Biblios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Biblios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa,Autor,Opis,Kategoria,Ilosc")] Biblio biblio)
        {
            if (ModelState.IsValid)
            {
                db.Biblios.Add(biblio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(biblio);
        }

        // GET: Biblios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biblio biblio = db.Biblios.Find(id);
            if (biblio == null)
            {
                return HttpNotFound();
            }
            return View(biblio);
        }

        // POST: Biblios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa,Autor,Opis,Kategoria,Ilosc")] Biblio biblio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(biblio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(biblio);
        }

        // GET: Biblios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biblio biblio = db.Biblios.Find(id);
            if (biblio == null)
            {
                return HttpNotFound();
            }
            return View(biblio);
        }

        // POST: Biblios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Biblio biblio = db.Biblios.Find(id);
            db.Biblios.Remove(biblio);
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
