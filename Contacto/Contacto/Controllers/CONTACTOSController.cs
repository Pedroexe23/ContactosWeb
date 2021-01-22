using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Contacto.Models;

namespace Contacto.Controllers
{
    public class CONTACTOSController : Controller
    {
        private ContactoModel db = new ContactoModel();

        // GET: CONTACTOS
        public ActionResult Index()
        {

            return View(db.CONTACTOS.ToList());
        }

        // GET: CONTACTOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTACTOS cONTACTOS = db.CONTACTOS.Find(id);
            if (cONTACTOS == null)
            {
                return HttpNotFound();
            }
            return View(cONTACTOS);
        }

        // GET: CONTACTOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CONTACTOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDContacto,NOMBRE,TELEFONO,EMAIL,DIRECCION")] CONTACTOS cONTACTOS)
        {
            if (ModelState.IsValid)
            {
                db.CONTACTOS.Add(cONTACTOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cONTACTOS);
        }

        // GET: CONTACTOS/Edit/5
       
        public ActionResult Edit(int? id)
        {
        
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CONTACTOS cONTACTOS = db.CONTACTOS.Find(id);
            
            if (cONTACTOS == null)
            {
                return HttpNotFound();
            }
            return View(cONTACTOS);
        }

        // POST: CONTACTOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDContacto,NOMBRE,TELEFONO,EMAIL,DIRECCION")] CONTACTOS cONTACTOS)
         {
             if (ModelState.IsValid)
             {
                 db.Entry(cONTACTOS).State = EntityState.Modified;
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }
             if (TryUpdateModel(cONTACTOS, "", new String[] { " NOMBRE", "TELEFONO", "EMAIL", "DIRECCION" }))
             {
                 try
                 {
                     db.SaveChanges();
                     return RedirectToAction("Index");
                 }
                 catch (Exception)
                 {
                     ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");

                 }
             }
             return View(cONTACTOS);
         }

        // GET: CONTACTOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTACTOS cONTACTOS = db.CONTACTOS.Find(id);

            if (cONTACTOS == null)
            {
                return HttpNotFound();
            }
            return View(cONTACTOS);
        }

        // POST: CONTACTOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CONTACTOS cONTACTOS = db.CONTACTOS.Find(id);
            db.CONTACTOS.Remove(cONTACTOS);
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
