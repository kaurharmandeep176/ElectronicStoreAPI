using ElectronicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicStore.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff

        ElectronicStoreEntities obj = new ElectronicStoreEntities();

        public ActionResult StaffDetails()
        {
            return View(obj.Staff_Table.ToList());
        }

        // GET: Staff/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "id")] Staff_Table tb)
        {
            if (!ModelState.IsValid)
                return View();
            obj.Staff_Table.Add(tb);
            obj.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("StaffDetails");

        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in obj.Staff_Table where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Staff/Edit/5
        [HttpPost]
        public ActionResult Edit(Staff_Table IdToEdit)
        {
            var orignalRecord = (from m in obj.Staff_Table where m.id == IdToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            obj.Entry(orignalRecord).CurrentValues.SetValues(IdToEdit);

            obj.SaveChanges();
            return RedirectToAction("StaffDetails");


        }

        // GET: Staff/Delete/5
        public ActionResult Delete(Staff_Table IdToDel)
        {
            var d =obj.Staff_Table.Where(x => x.id == IdToDel.id).FirstOrDefault();
            obj.Staff_Table.Remove(d);
            obj.SaveChanges();
            return RedirectToAction("StaffDetails");

        }

        // POST: Staff/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
